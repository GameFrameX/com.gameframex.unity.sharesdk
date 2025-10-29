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

namespace cn.sharesdk.unity3d
{
    public abstract class ShareSDKRestoreSceneImpl
    {
        public virtual void setRestoreSceneListener()
        {
        }
    }

    public abstract class ShareSDKImpl
    {
        /// <summary>
        /// Init the ShareSDK.
        /// </summary>
        public abstract void InitSDK(string appKey);

        public abstract void InitSDK(string appKey, string secret);
        public abstract void SetDebug(bool isDebug);

        /// <summary>
        /// add listener for loopshare
        /// </summary>
        public abstract void PrepareLoopShare();

        /// <summary>
        /// set channel Id
        /// </summary>
        public abstract void setChannelId();

        /// <summary>
        /// Sets the platform config.
        /// </summary>
        public abstract void SetPlatformConfig(Hashtable configs);

        /// <summary>
        /// Authorize the specified platform.
        /// </summary>
        public abstract void Authorize(int reqId, PlatformType platform);

        /// <summary>
        /// Removes the account of the specified platform.
        /// </summary>
        public abstract void CancelAuthorize(PlatformType platform);

        /// <summary>
        /// Determine weather the account of the specified platform is valid.
        /// </summary>
        public abstract bool IsAuthorized(PlatformType platform);

        /// <summary>
        /// Determine weather the APP-Client of platform is valid.
        /// </summary>
        public abstract bool IsClientValid(PlatformType platform);

        /// <summary>
        /// Request the user info of the specified platform.
        /// </summary>
        public abstract void GetUserInfo(int reqId, PlatformType platform);

        /// <summary>
        /// Share the content to the specified platform with api.
        /// </summary>
        public abstract void ShareContent(int reqId, PlatformType platform, ShareContent content);

        /// <summary>
        /// Share the content to the specified platform with api.
        /// </summary>
        public abstract void ShareContent(int reqId, PlatformType[] platforms, ShareContent content);

        /// <summary>
        /// Show the platform list to share.
        /// </summary>
        public abstract void ShowPlatformList(int reqId, PlatformType[] platforms, ShareContent content, int x, int y);

        /// <summary>
        /// OGUI share to the specified platform. 
        /// </summary>
        public abstract void ShowShareContentEditor(int reqId, PlatformType platform, ShareContent content);

        /// <summary>
        /// share according to the name of node<Content> in ShareContent.xml(in ShareSDKConfigFile.bunle,you can find it in xcode - ShareSDK folider) [only valid in iOS temporarily)]
        /// </summary>
        public abstract void ShareWithContentName(int reqId, PlatformType platform, string contentName, Hashtable customFields);

        /// <summary>
        /// show share platform list according to the name of node<Content> in ShareContent.xml file(in ShareSDKConfigFile.bunle,you can find it in xcode - ShareSDK folider) [only valid in iOS temporarily)] 
        /// </summary>
        public abstract void ShowPlatformListWithContentName(int reqId, string contentName, Hashtable customFields, PlatformType[] platforms, int x, int y);

        /// <summary>
        /// show share content editor according to the name of node<Content> in ShareContent.xml file(in ShareSDKConfigFile.bunle,you can find it in xcode - ShareSDK folider) [only valid in iOS temporarily)]
        /// </summary>
        public abstract void ShowShareContentEditorWithContentName(int reqId, PlatformType platform, string contentName, Hashtable customFields);

        /// <summary>
        /// Gets the friend list.
        /// </summary>
        public abstract void GetFriendList(int reqID, PlatformType platform, int count, int page);

        /// <summary>
        /// Follows the friend.
        /// </summary>
        public abstract void AddFriend(int reqID, PlatformType platform, string account);

        /// <summary>
        /// Gets the auth info.
        /// </summary>
        public abstract Hashtable GetAuthInfo(PlatformType platform);

        /// <summary>
        /// the setting of SSO
        /// </summary>
        public abstract void DisableSSO(bool disable);

        /// <summary>
        /// Open Wechat miniProgram
        /// </summary>
        public abstract bool openMiniProgram(string userName, string path, int miniProgramType);

        public abstract void getWXRequestToken();

        public abstract void getWXRefreshToken();

        public abstract void sendWXRefreshToken(string token);

        public abstract void sendWXRequestToken(string uid, string token);

#if UNITY_ANDROID
        public abstract void isClientValidForAndroid(int reqID, PlatformType platform);
#endif

#if UNITY_IPHONE || UNITY_IOS
		/// <summary>
		/// 获取MobSDK隐私协议内容, url为true时返回MobTech隐私协议链接，false返回协议的内容
		/// <summary>
		public abstract void shareSDKWithCommand(Hashtable content);

		/// <summary>
		/// Share the content to the specified platform with api.
		/// <summary>
		public abstract void ShareContentWithActivity(int reqID, PlatformType platform, ShareContent content);


#endif

#if UNITY_ANDROID
        /// <summary>
        /// 获取MobSDK隐私协议内容, url为true时返回MobTech隐私协议链接，false返回协议的内容
        /// </summary>
        public abstract void setDisappearShareToast(bool url);
#endif
    }
}