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
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace cn.sharesdk.unity3d
{
#if UNITY_IPHONE || UNITY_IOS
	public class iOSImpl : ShareSDKImpl {
		private string _callbackObjectName = "Main Camera";
		private string _appKey;
		
		[DllImport("__Internal")]
		private static extern void __iosShareSDKRegisterAppAndSetPltformsConfig(string appKey, string configInfo);
		
		[DllImport("__Internal")]
		private static extern void __iosShareSDKAuthorize(int reqID, int platType, string observer);
		
		[DllImport("__Internal")]
		private static extern void __iosShareSDKCancelAuthorize(int platType);
		
		[DllImport("__Internal")]
		private static extern bool __iosShareSDKHasAuthorized(int platType);
		
		[DllImport("__Internal")]
		private static extern void __iosShareSDKGetUserInfo(int reqID, int platType, string observer);
		
		[DllImport("__Internal")]
		private static extern void __iosShareSDKShare(int reqID, int platType, string content, string observer);

		[DllImport("__Internal")]
		private static extern void __iosShareSDKShareWithActivity(int reqID, int platType, string content, string observer);

		[DllImport("__Internal")]
		private static extern void __iosShareSDKOneKeyShare(int reqID, string platTypes, string content, string observer);
		
		[DllImport("__Internal")]
		private static extern void __iosShareSDKShowShareMenu(int reqID, string platTypes, string content, int x, int y, string observer);
		
		[DllImport("__Internal")]
		private static extern void __iosShareSDKShowShareView(int reqID, int platType, string content, string observer);
		
		[DllImport("__Internal")]
		private static extern void __iosShareSDKGetFriendsList(int reqID, int platType,int count, int page, string observer);
		
		[DllImport("__Internal")]
		private static extern void __iosShareSDKFollowFriend(int reqID, int platform,string account, string observer);
		
		[DllImport("__Internal")]
		private static extern string __iosShareSDKGetCredential(int platType);
		
		[DllImport("__Internal")]
		private static extern bool __iosShareSDKIsClientInstalled(int platType);

		[DllImport("__Internal")]
		private static extern void __iosShareSDKShareWithContentName(int reqID, int platform, string contentName, string customFields, string observer);

		[DllImport("__Internal")]
		private static extern void __iosShareSDKShowShareMenuWithContentName(int reqID, string contentName, string customFields, string platTypes, int x, int y, string observer);

		[DllImport("__Internal")]
		private static extern void __iosShareSDKShowShareViewWithContentName(int reqID, int platform, string contentName, string customFields, string observer);

		[DllImport("__Internal")]
		private static extern bool __iosShareSDKOpenMiniProgram(String userName, String path, int miniProgramType);

        [DllImport("__Internal")]
        private static extern bool __iosShareSDKWXRequestSendTokenToGetUser(String uid, String token);

        [DllImport("__Internal")]
        private static extern bool __iosShareSDKWXRequestToken(String observer);

        [DllImport("__Internal")]
        private static extern bool __iosShareSDKWXRefreshSendTokenToGetUser(String token);

        [DllImport("__Internal")]
        private static extern bool __iosShareSDKWXRefreshRequestToken(String observer);

		[DllImport("__Internal")]
		private static extern void __iosShareSDKShareWithCommand(string customFields, string observer);

		public iOSImpl(GameObject go) {
			try {
				_callbackObjectName = go.name;
			} catch(Exception e) {
				Console.WriteLine("{0} Exception caught.", e);
			}
		}

		public override void InitSDK(string appKey) {
			_appKey = appKey;
		}

		public override void InitSDK(string appKey, string secret) {
			_appKey = appKey;
		}

		public override void PrepareLoopShare() {
			throw new NotImplementedException();
		}

		public override void setChannelId() {
			throw new NotImplementedException();
		}

		public override void SetPlatformConfig(Hashtable configs) {
			String json = MiniJSON.jsonEncode(configs);

			if(Application.platform == RuntimePlatform.IPhonePlayer)
			{
				__iosShareSDKRegisterAppAndSetPltformsConfig(_appKey, json);
			}
		}

		public override void Authorize(int reqId, PlatformType platform) {
			__iosShareSDKAuthorize(reqId, (int)platform, _callbackObjectName);
		}

		public override void CancelAuthorize(PlatformType platform) {
			__iosShareSDKCancelAuthorize((int)platform);
		}

		public override bool IsAuthorized(PlatformType platform) {
			return __iosShareSDKHasAuthorized((int)platform);
		}

		public override bool IsClientValid(PlatformType platform) {
			return __iosShareSDKIsClientInstalled((int)platform);
		}

		public override void GetUserInfo(int reqId, PlatformType platform) {
			__iosShareSDKGetUserInfo(reqId, (int)platform, _callbackObjectName);
		}

		public override void ShareContent(int reqId, PlatformType platform, ShareContent content) {
			__iosShareSDKShare(reqId, (int)platform, content.GetShareParamsStr(), _callbackObjectName);
		}

		public override void ShareContent(int reqId, PlatformType[] platforms, ShareContent content) {
			string platTypesStr = null;
			if (platforms != null) {
				List<int> platTypesArr = new List<int>();
				foreach (PlatformType type in platforms) {
					platTypesArr.Add((int)type);
				}
				platTypesStr = MiniJSON.jsonEncode(platTypesArr.ToArray());
			}

			__iosShareSDKOneKeyShare(reqId, platTypesStr, content.GetShareParamsStr(), _callbackObjectName);
		}

		public override void ShowPlatformList(int reqId, PlatformType[] platforms, ShareContent content, int x, int y) {
			Debug.Log("ShowPlatformList Called");
			string platTypesStr = null;
			if (platforms != null) {
				List<int> platTypesArr = new List<int>();
				foreach (PlatformType type in platforms) {
					platTypesArr.Add((int)type);
				}
				platTypesStr = MiniJSON.jsonEncode(platTypesArr.ToArray());
			}

			__iosShareSDKShowShareMenu(reqId, platTypesStr, content.GetShareParamsStr(), x, y, _callbackObjectName);
		}

		public override void ShowShareContentEditor(int reqId, PlatformType platform, ShareContent content) {
			__iosShareSDKShowShareView(reqId, (int)platform, content.GetShareParamsStr(), _callbackObjectName);
		}

		public override void ShareWithContentName(int reqId, PlatformType platform, string contentName, Hashtable customFields) {
			String customFieldsStr = MiniJSON.jsonEncode(customFields);
			__iosShareSDKShareWithContentName(reqId, (int)platform, contentName, customFieldsStr,  _callbackObjectName);
		}

		public override void ShowPlatformListWithContentName(int reqId, string contentName, Hashtable customFields, PlatformType[] platforms, int x, int y) {
			String customFieldsStr = MiniJSON.jsonEncode(customFields);
			string platTypesStr = null;
			if (platforms != null) {
				List<int> platTypesArr = new List<int>();
				foreach (PlatformType type in platforms) {
					platTypesArr.Add((int)type);
				}
				platTypesStr = MiniJSON.jsonEncode(platTypesArr.ToArray());
			}

			__iosShareSDKShowShareMenuWithContentName(reqId, contentName, customFieldsStr, platTypesStr, x, y, _callbackObjectName);
		}

		public override void ShowShareContentEditorWithContentName(int reqId, PlatformType platform, string contentName, Hashtable customFields) {
			String customFieldsStr = MiniJSON.jsonEncode(customFields);
			__iosShareSDKShowShareViewWithContentName(reqId, (int)platform, contentName, customFieldsStr, _callbackObjectName);
		}

		public override void GetFriendList(int reqID, PlatformType platform, int count, int page) {
			__iosShareSDKGetFriendsList(reqID, (int)platform, count, page, _callbackObjectName);
		}

		public override void AddFriend(int reqID, PlatformType platform, string account) {
			__iosShareSDKFollowFriend(reqID, (int)platform, account, _callbackObjectName);
		}

		public override Hashtable GetAuthInfo(PlatformType platform) {
			string credStr = __iosShareSDKGetCredential((int)platform);
			return (Hashtable)MiniJSON.jsonDecode(credStr);
		}

		public override void DisableSSO(bool disable) {
			Console.WriteLine ("#waring : no this interface on iOS");
		}

		public override bool openMiniProgram(string userName, string path, int miniProgramType) {
			return __iosShareSDKOpenMiniProgram(userName, path, miniProgramType);
		}

		public override void getWXRequestToken() {
            __iosShareSDKWXRequestToken(_callbackObjectName);
		}

		public override void getWXRefreshToken() {
            __iosShareSDKWXRefreshRequestToken(_callbackObjectName);
		}

		public override void sendWXRefreshToken(string token) {
            __iosShareSDKWXRefreshSendTokenToGetUser(token);
		}

		public override void sendWXRequestToken(string uid, string token) {
            __iosShareSDKWXRequestSendTokenToGetUser(uid, token);
		}

		public override void shareSDKWithCommand(Hashtable content) {
			String customFieldsStr = MiniJSON.jsonEncode(content);
			__iosShareSDKShareWithCommand(customFieldsStr, _callbackObjectName);
		}
		
		public override void ShareContentWithActivity(int reqID, PlatformType platform, ShareContent content) {
			__iosShareSDKShareWithActivity(reqID, (int)platform, content.GetShareParamsStr(), _callbackObjectName);
		}
	}
#endif
}