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
using System.Collections;
using UnityEngine;

namespace cn.sharesdk.unity3d
{
#if UNITY_ANDROID
    public class AndroidImpl : ShareSDKImpl
    {
        private AndroidJavaObject ssdk;

        public AndroidImpl(GameObject go)
        {
            Debug.Log("AndroidImpl  ===>>>  AndroidImpl");
            try
            {
                ssdk = new AndroidJavaObject("cn.sharesdk.unity3d.ShareSDKUtils", go.name, "_Callback");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        public override void InitSDK(String appKey)
        {
            Debug.Log("AndroidImpl  ===>>>  InitSDK === " + appKey);
            if (ssdk != null)
            {
                ssdk.Call("initSDK", appKey);
            }
        }

        public override void InitSDK(String appKey, String appSecret)
        {
            Debug.Log("AndroidImpl  ===>>>  InitSDK === " + appKey);
            if (ssdk != null)
            {
                ssdk.Call("initSDK", appKey, appSecret);
            }
        }

        public override void PrepareLoopShare()
        {
            Debug.Log("AndroidImpl  ===>>>  PrepareLoopShare ");
            if (ssdk != null)
            {
                ssdk.Call("prepareLoopShare");
            }
        }

        public override void setChannelId()
        {
            Debug.Log("AndroidImpl  ===>>>  SetChannelId ");
            if (ssdk != null)
            {
                ssdk.Call("setChannelId");
            }
        }

        public override void SetPlatformConfig(Hashtable configs)
        {
            var json = MiniJSON.jsonEncode(configs);
            Debug.Log("AndroidImpl  ===>>>  SetPlatformConfig === " + json);
            if (ssdk != null)
            {
                ssdk.Call("setPlatformConfig", json);
            }
        }

        public override void Authorize(int reqID, PlatformType platform)
        {
            Debug.Log("AndroidImpl  ===>>>  Authorize");
            if (ssdk != null)
            {
                Debug.Log("AndroidImpl  ===>>>  Authorize === " + reqID + " === " + platform);
                ssdk.Call("authorize", reqID, (int)platform);
            }
        }

        public override void CancelAuthorize(PlatformType platform)
        {
            if (ssdk != null)
            {
                ssdk.Call("removeAccount", (int)platform);
            }
        }

        public override bool IsAuthorized(PlatformType platform)
        {
            if (ssdk != null)
            {
                return ssdk.Call<bool>("isAuthValid", (int)platform);
            }

            return false;
        }

        public override bool IsClientValid(PlatformType platform)
        {
            if (ssdk != null)
            {
                return ssdk.Call<bool>("isClientValid", (int)platform);
            }

            return false;
        }

        public override void GetUserInfo(int reqID, PlatformType platform)
        {
            Debug.Log("AndroidImpl  ===>>>  ShowUser");
            if (ssdk != null)
            {
                ssdk.Call("showUser", reqID, (int)platform);
            }
        }

        public override void ShareContent(int reqID, PlatformType platform, ShareContent content)
        {
            Debug.Log("AndroidImpl  ===>>>  ShareContent to one platform");
            ShareContent(reqID, new PlatformType[] { platform }, content);
        }

        public override void ShareContent(int reqID, PlatformType[] platforms, ShareContent content)
        {
            Debug.Log("AndroidImpl  ===>>>  Share");
            if (ssdk != null)
            {
                foreach (PlatformType platform in platforms)
                {
                    ssdk.Call("shareContent", reqID, (int)platform, content.GetShareParamsStr());
                }
            }
        }

        public override void ShowPlatformList(int reqID, PlatformType[] platforms, ShareContent content, int x, int y)
        {
            ShowShareContentEditor(reqID, 0, content);
        }

        public override void ShowShareContentEditor(int reqID, PlatformType platform, ShareContent content)
        {
            Debug.Log("AndroidImpl  ===>>>  OnekeyShare platform ===" + (int)platform);
            if (ssdk != null)
            {
                ssdk.Call("onekeyShare", reqID, (int)platform, content.GetShareParamsStr());
            }
        }

        public override void GetFriendList(int reqID, PlatformType platform, int count, int page)
        {
            Debug.Log("AndroidImpl  ===>>>  GetFriendList");
            if (ssdk != null)
            {
                ssdk.Call("getFriendList", reqID, (int)platform, count, page);
            }
        }

        public override void AddFriend(int reqID, PlatformType platform, String account)
        {
            Debug.Log("AndroidImpl  ===>>>  FollowFriend");
            if (ssdk != null)
            {
                ssdk.Call("followFriend", reqID, (int)platform, account);
            }
        }

        public override Hashtable GetAuthInfo(PlatformType platform)
        {
            Debug.Log("AndroidImpl  ===>>>  GetAuthInfo");
            if (ssdk != null)
            {
                String result = ssdk.Call<String>("getAuthInfo", (int)platform);
                return (Hashtable)MiniJSON.jsonDecode(result);
            }

            return new Hashtable();
        }

        public override void DisableSSO(Boolean disable)
        {
            Debug.Log("AndroidImpl  ===>>>  DisableSSOWhenAuthorize");
            if (ssdk != null)
            {
                ssdk.Call("disableSSOWhenAuthorize", disable);
            }
        }

        public override void setDisappearShareToast(Boolean isShow)
        {
            Debug.Log("AndroidImpl  ===>>>  setDisappearShareToast");
            if (ssdk != null)
            {
                ssdk.Call("setDisappearShareToast", isShow);
            }
        }


        public override void ShareWithContentName(int reqId, PlatformType platform, string contentName, Hashtable customFields)
        {
            Debug.Log("#WARING : Do not support this feature in Android ");
        }

        public override void ShowPlatformListWithContentName(int reqId, string contentName, Hashtable customFields, PlatformType[] platforms, int x, int y)
        {
            Debug.Log("#WARING : Do not support this feature in Android ");
        }

        public override void ShowShareContentEditorWithContentName(int reqId, PlatformType platform, string contentName, Hashtable customFields)
        {
            Debug.Log("#WARING : Do not support this feature in Android ");
        }

        public override bool openMiniProgram(String userName, String path, int miniProgramType)
        {
            // wait for implementation
            return false;
        }

        public override void getWXRequestToken()
        {
            Debug.Log("#WARING : Do not support this feature in Android");
        }

        public override void getWXRefreshToken()
        {
            Debug.Log("#WARING : Do not support this feature in Android");
        }

        public override void sendWXRefreshToken(String token)
        {
            Debug.Log("#WARING : Do not support this feature in Android");
        }

        public override void sendWXRequestToken(String uid, String token)
        {
            Debug.Log("#WARING : Do not support this feature in Android");
        }

        public override void isClientValidForAndroid(int reqID, PlatformType platform)
        {
            Debug.Log("AndroidImpl  ===>>>  isClientValidForAndroid");
            if (ssdk != null)
            {
                ssdk.Call("isClientValidForAndroid", reqID, (int)platform);
            }
        }
    }
#endif
}