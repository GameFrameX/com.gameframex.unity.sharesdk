// ==========================================================================================
//  GameFrameX 组织及其衍生项目的版权、商标、专利及其他相关权利
//  GameFrameX organization and its derivative projects' copyrights, trademarks, patents, and related rights
//  均受中华人民共和国及相关国际法律法规保护。
//  are protected by the laws of the People's Republic of China and relevant international regulations.
// 
//  使用本项目须严格遵守相应法律法规及开源许可证之规定。
//  Usage of this project must strictly comply with applicable laws, regulations, and open-source licenses.
// 
//  本项目采用 MIT 许可证与 Apache License 2.0 双许可证分发，
//  This project is dual-licensed under the MIT License and Apache License 2.0,
//  完整许可证文本请参见源代码根目录下的 LICENSE 文件。
//  please refer to the LICENSE file in the root directory of the source code for the full license text.
// 
//  禁止利用本项目实施任何危害国家安全、破坏社会秩序、
//  It is prohibited to use this project to engage in any activities that endanger national security, disrupt social order,
//  侵犯他人合法权益等法律法规所禁止的行为！
//  or infringe upon the legitimate rights and interests of others, as prohibited by laws and regulations!
//  因基于本项目二次开发所产生的一切法律纠纷与责任，
//  Any legal disputes and liabilities arising from secondary development based on this project
//  本项目组织与贡献者概不承担。
//  shall be borne solely by the developer; the project organization and contributors assume no responsibility.
// 
//  GitHub 仓库：https://github.com/GameFrameX
//  GitHub Repository: https://github.com/GameFrameX
//  Gitee  仓库：https://gitee.com/GameFrameX
//  Gitee Repository:  https://gitee.com/GameFrameX
//  官方文档：https://gameframex.doc.alianblank.com/
//  Official Documentation: https://gameframex.doc.alianblank.com/
// ==========================================================================================

using System;
using System.IO;
using System.Text;
using UnityEngine;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using GameFrameX.Event.Runtime;
using GameFrameX.Runtime;
using GameFrameX.ShareSdk.Runtime;

namespace cn.sharesdk.unity3d
{
    public delegate void sendWXRequestToken(string uid, string token);

    public delegate void sendWXRefreshToken(string token);

    public class ShareSDK : MonoBehaviour
    {
        //版本号，每次发布新版本都需要更新
        public static string version = "3.0.4";
#if UNITY_IPHONE || UNITY_IOS
		public string mobNetLater = "2";
		public string mobTwitterVer = "2";

		public List<string> customAssociatedDomains = new List<string>();
		public GetWXRequestTokenHanlerEvent wxRequestHandler;
		public GetWXRefreshTokenHanlerEvent wxRefreshTokenHandler;
		public GetShareCommandHanlerEvent shareCommandHandler;
#endif
        private int reqID;
        public DevInfoSet devInfo;
        public ShareSDKImpl sdk;
        private Action<int, ResponseState, PlatformType, Hashtable> authHandler;
        private Action<int, ResponseState, PlatformType, Hashtable> shareHandler;
        private Action<int, ResponseState, PlatformType, Hashtable> showUserHandler;
        private Action<int, ResponseState, PlatformType, Hashtable> getFriendsHandler;
        private Action<int, ResponseState, PlatformType, Hashtable> followFriendHandler;
        private Action<int, ResponseState, PlatformType, Hashtable> clientValidForAndroidHandler;
        private Hashtable platformConfigs;

        void DevInfoHandler()
        {
            Type type = devInfo.GetType();
            platformConfigs = new Hashtable();
            FieldInfo[] devInfoFields = type.GetFields();
            foreach (FieldInfo devInfoField in devInfoFields)
            {
                DevInfo info = (DevInfo)devInfoField.GetValue(devInfo);
                int platformId = (int)info.GetType().GetField("type").GetValue(info);
                FieldInfo[] fields = info.GetType().GetFields();
                Hashtable table = new Hashtable();
                foreach (FieldInfo field in fields)
                {
                    if ("type".EndsWith(field.Name))
                    {
                        continue;
                    }
                    else if ("Enable".EndsWith(field.Name) || "ShareByAppClient".EndsWith(field.Name) || "BypassApproval".EndsWith(field.Name) || "WithShareTicket".EndsWith(field.Name))
                    {
                        table.Add(field.Name, Convert.ToString(field.GetValue(info)).ToLower());
                    }
                    else
                    {
                        table.Add(field.Name, Convert.ToString(field.GetValue(info)));
                    }
                }

                platformConfigs.Add(platformId, table);
            }
        }

        void Awake()
        {
#if UNITY_ANDROID
            sdk = new AndroidImpl(gameObject);
            sdk.PrepareLoopShare();
            sdk.setChannelId();
#elif UNITY_IPHONE
			sdk = new iOSImpl(gameObject);
#endif
        }

        private EventComponent _eventComponent;

        private void Start()
        {
            authHandler = AuthHandler;
            shareHandler = ShareHandler;
            followFriendHandler = FollowFriendHandler;
            getFriendsHandler = GetFriendsHandler;
            showUserHandler = ShowUserHandler;
            DevInfoHandler();
            sdk.SetPlatformConfig(platformConfigs);

            _eventComponent = GameEntry.GetComponent<EventComponent>();
            if (_eventComponent == null)
            {
                Log.Error("eventComponent is null");
            }
        }

        private void ShowUserHandler(int requestId, ResponseState state, PlatformType type, Hashtable data)
        {
            _eventComponent.Fire(this, ShowUserEventArgs.Create(state, type, data));
        }

        private void GetFriendsHandler(int requestId, ResponseState state, PlatformType type, Hashtable data)
        {
            _eventComponent.Fire(this, GetFriendsEventArgs.Create(state, type, data));
        }

        private void FollowFriendHandler(int requestId, ResponseState state, PlatformType type, Hashtable data)
        {
            _eventComponent.Fire(this, FollowFriendEventArgs.Create(state, type, data));
        }

        private void ShareHandler(int requestId, ResponseState state, PlatformType type, Hashtable data)
        {
            _eventComponent.Fire(this, ShareEventArgs.Create(state, type, data));
        }

        private void AuthHandler(int requestId, ResponseState state, PlatformType type, Hashtable data)
        {
            _eventComponent.Fire(this, AuthEventArgs.Create(state, type, data));
        }

        private void _Callback(string data)
        {
            if (data == null)
            {
                return;
            }

            Hashtable res = (Hashtable)MiniJSON.jsonDecode(data);
            if (res == null || res.Count <= 0)
            {
                return;
            }

            int status = Convert.ToInt32(res["status"]);
            int reqID = Convert.ToInt32(res["reqID"]);
            PlatformType platform = (PlatformType)Convert.ToInt32(res["platform"]);
            int action = Convert.ToInt32(res["action"]);

            switch (status)
            {
                case 1:
                {
                    Console.WriteLine(data);
                    Hashtable resp = (Hashtable)res["res"];
                    OnComplete(reqID, platform, action, resp);
                    break;
                }
                case 2:
                {
                    Console.WriteLine(data);
                    Hashtable throwable = (Hashtable)res["res"];
                    OnError(reqID, platform, action, throwable);
                    break;
                }
                case 3:
                {
                    OnCancel(reqID, platform, action);
                    break;
                }
            }
        }

        public void OnError(int reqID, PlatformType platform, int action, Hashtable throwable)
        {
            switch (action)
            {
                case 1:
                {
                    if (authHandler != null)
                    {
                        authHandler(reqID, ResponseState.Fail, platform, throwable);
                    }

                    break;
                }
                case 2:
                {
                    if (getFriendsHandler != null)
                    {
                        getFriendsHandler(reqID, ResponseState.Fail, platform, throwable);
                    }

                    break;
                }
                case 6:
                {
                    if (followFriendHandler != null)
                    {
                        followFriendHandler(reqID, ResponseState.Fail, platform, throwable);
                    }

                    break;
                }
                case 9:
                {
                    if (shareHandler != null)
                    {
                        shareHandler(reqID, ResponseState.Fail, platform, throwable);
                    }

                    break;
                }
                case 8:
                {
                    if (showUserHandler != null)
                    {
                        showUserHandler(reqID, ResponseState.Fail, platform, throwable);
                    }

                    break;
                }
            }
        }

        public void OnComplete(int reqID, PlatformType platform, int action, Hashtable res)
        {
            switch (action)
            {
                case 1:
                {
                    if (authHandler != null)
                    {
                        authHandler(reqID, ResponseState.Success, platform, res);
                    }

                    break;
                }
                case 2:
                {
                    if (getFriendsHandler != null)
                    {
                        getFriendsHandler(reqID, ResponseState.Success, platform, res);
                    }

                    break;
                }
                case 6:
                {
                    if (followFriendHandler != null)
                    {
                        followFriendHandler(reqID, ResponseState.Success, platform, res);
                    }

                    break;
                }
                case 9:
                {
                    if (shareHandler != null)
                    {
                        shareHandler(reqID, ResponseState.Success, platform, res);
                    }

                    break;
                }
                case 8:
                {
                    if (showUserHandler != null)
                    {
                        showUserHandler(reqID, ResponseState.Success, platform, res);
                    }

                    break;
                }
                case 12:
                {
                    if (clientValidForAndroidHandler != null)
                    {
                        clientValidForAndroidHandler(reqID, ResponseState.Success, platform, res);
                    }

                    break;
                }
#if UNITY_IPHONE
				case 11: {
					shareCommandHandler(res);
					break;
				}
				case 10: {
					int isRefresh = Convert.ToInt32(res["isRefreshToken"]);
					if (isRefresh == 1) {
						String uid = Convert.ToString(res["uid"]);
						wxRefreshTokenHandler(uid, sendWXRefreshTokenMethod);
					} else {
						String authCode = Convert.ToString(res["authCode"]);
						wxRequestHandler(authCode, sendWXRequestTokenMehtod);
					}
					break;
				}
#endif
            }
        }

        public void OnCancel(int reqID, PlatformType platform, int action)
        {
            switch (action)
            {
                case 1:
                {
                    if (authHandler != null)
                    {
                        authHandler(reqID, ResponseState.Cancel, platform, null);
                    }

                    break;
                }
                case 2:
                {
                    if (getFriendsHandler != null)
                    {
                        getFriendsHandler(reqID, ResponseState.Cancel, platform, null);
                    }

                    break;
                }
                case 6:
                {
                    if (followFriendHandler != null)
                    {
                        followFriendHandler(reqID, ResponseState.Cancel, platform, null);
                    }

                    break;
                }
                case 9:
                {
                    if (shareHandler != null)
                    {
                        shareHandler(reqID, ResponseState.Cancel, platform, null);
                    }

                    break;
                }
                case 8:
                {
                    if (showUserHandler != null)
                    {
                        showUserHandler(reqID, ResponseState.Cancel, platform, null);
                    }

                    break;
                }
            }
        }

        public void InitSDK(string appKey)
        {
            sdk.InitSDK(appKey);
        }

        public void InitSDK(string appKey, string appSecret)
        {
            sdk.InitSDK(appKey, appSecret);
        }

        public void SetPlatformConfig(Hashtable configInfo)
        {
            sdk.SetPlatformConfig(configInfo);
        }

        public int Authorize(PlatformType platform)
        {
            reqID++;
            sdk.Authorize(reqID, platform);
            return reqID;
        }

        public void CancelAuthorize(PlatformType platform)
        {
            sdk.CancelAuthorize(platform);
        }

        public bool IsAuthorized(PlatformType platform)
        {
            return sdk.IsAuthorized(platform);
        }

        public bool IsClientValid(PlatformType platform)
        {
            return sdk.IsClientValid(platform);
        }

        public int GetUserInfo(PlatformType platform)
        {
            reqID++;
            sdk.GetUserInfo(reqID, platform);
            return reqID;
        }

        public int ShareContent(PlatformType platform, ShareContent content)
        {
            reqID++;
            sdk.ShareContent(reqID, platform, content);
            return reqID;
        }

        public int ShareContent(PlatformType[] platforms, ShareContent content)
        {
            reqID++;
            sdk.ShareContent(reqID, platforms, content);
            return reqID;
        }

        public int ShareContentWithActivity(PlatformType platform, ShareContent content)
        {
            reqID++;
#if UNITY_IPHONE
			sdk.ShareContentWithActivity(reqID, platform, content);
#endif
            return reqID;
        }

        public int ShowPlatformList(PlatformType[] platforms, ShareContent content, int x, int y)
        {
            reqID++;
            sdk.ShowPlatformList(reqID, platforms, content, x, y);
            return reqID;
        }

        public int ShowShareContentEditor(PlatformType platform, ShareContent content)
        {
            reqID++;
            sdk.ShowShareContentEditor(reqID, platform, content);
            return reqID;
        }

        public int ShareWithContentName(PlatformType platform, string contentName, Hashtable customFields)
        {
            reqID++;
            sdk.ShareWithContentName(reqID, platform, contentName, customFields);
            return reqID;
        }

        public int ShowPlatformListWithContentName(string contentName, Hashtable customFields, PlatformType[] platforms, int x, int y)
        {
            reqID++;
            sdk.ShowPlatformListWithContentName(reqID, contentName, customFields, platforms, x, y);
            return reqID;
        }

        public int ShowShareContentEditorWithContentName(PlatformType platform, string contentName, Hashtable customFields)
        {
            reqID++;
            sdk.ShowShareContentEditorWithContentName(reqID, platform, contentName, customFields);
            return reqID;
        }

        public int GetFriendList(PlatformType platform, int count, int page)
        {
            reqID++;
            sdk.GetFriendList(reqID, platform, count, page);
            return reqID;
        }

        public int AddFriend(PlatformType platform, string account)
        {
            reqID++;
            sdk.AddFriend(reqID, platform, account);
            return reqID;
        }

        public Hashtable GetAuthInfo(PlatformType platform)
        {
            return sdk.GetAuthInfo(platform);
        }

        public void DisableSSO(bool open)
        {
            sdk.DisableSSO(open);
        }

        public void openMiniProgram(string userName, string path, int miniProgramType)
        {
            sdk.openMiniProgram(userName, path, miniProgramType);
        }

        public int isClientValidForAndroid(PlatformType platform)
        {
            reqID++;

#if UNITY_ANDROID
            sdk.isClientValidForAndroid(reqID, platform);
#endif

            return reqID;
        }
#if UNITY_IPHONE || UNITY_IOS
		public delegate void GetWXRequestTokenHanlerEvent(string authCode, sendWXRequestToken send);

		public delegate void GetWXRefreshTokenHanlerEvent(string authCode, sendWXRefreshToken send);

		public delegate void GetShareCommandHanlerEvent(Hashtable data);

		public void ShareWithCommand(Hashtable customFields) {
			sdk.shareSDKWithCommand(customFields);
		}
#endif

        public void getWXRequestToken()
        {
            sdk.getWXRequestToken();
        }

        public void getWXRefreshToken()
        {
            sdk.getWXRefreshToken();
        }

        public void sendWXRequestTokenMehtod(string uid, string token)
        {
            sdk.sendWXRequestToken(uid, token);
        }

        public void sendWXRefreshTokenMethod(string token)
        {
            sdk.sendWXRefreshToken(token);
        }
    }
}