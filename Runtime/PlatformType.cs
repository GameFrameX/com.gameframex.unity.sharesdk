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

namespace cn.sharesdk.unity3d
{
    /// <summary>
    /// Platform type.
    /// </summary>
#if UNITY_IPHONE
	public enum HostType {
		sandbox = 1,
		china = 2,
		product = 3
	}
#endif

    public enum PlatformType
    {
        Unknown = 0,
        SinaWeibo = 1, //Sina Weibo         
        TencentWeibo = 2, //Tencent Weibo          
        DouBan = 5, //Dou Ban           
        QZone = 6, //QZone           
        Renren = 7, //Ren Ren           
        Kaixin = 8, //Kai Xin          
        Pengyou = 9, //Friends          
        Facebook = 10, //Facebook         
        Twitter = 11, //Twitter         
        Evernote = 12, //Evernote        
        Foursquare = 13, //Foursquare      
        GooglePlus = 14, //Google+       
        Instagram = 15, //Instagram      
        LinkedIn = 16, //LinkedIn       
        Tumblr = 17, //Tumblr         
        Mail = 18, //Mail          
        SMS = 19, //SMS           
        Print = 20, //Print       
        Copy = 21, //Copy             
        WeChat = 22, //WeChat Friends    
        WeChatMoments = 23, //WeChat WechatMoments   
        QQ = 24, //QQ              
        Instapaper = 25, //Instapaper       
        Pocket = 26, //Pocket           
        YouDaoNote = 27, //You Dao Note           
        Pinterest = 30, //Pinterest    
        Flickr = 34, //Flickr          
        Dropbox = 35, //Dropbox          
        VKontakte = 36, //VKontakte       
        WeChatFavorites = 37, //WeChat Favorited        
        YiXinSession = 38, //YiXin Session   
        YiXinTimeline = 39, //YiXin Timeline   
        YiXinFav = 40, //YiXin Favorited  
        MingDao = 41, //明道
        Line = 42, //Line
        WhatsApp = 43, //Whats App
        KakaoTalk = 44, //KakaoTalk
        KakaoStory = 45, //KakaoStory 
        FacebookMessenger = 46, //FacebookMessenger
        Telegram = 47, //Telegram
        Bluetooth = 48, //Bluetooth
        AliSocial = 50, //AliSocial
        AliSocialMoments = 51, //AliSocialMoments
        Dingding = 52, //DingTalk 钉钉
        Youtube = 53, //youtube
        MeiPai = 54, //美拍
        CMCC = 55, //中国移动
        Reddit = 56, //Reddit
        ESurfing = 57, //天翼
        FacebookAccount = 58, //FacebookAccount
        Douyin = 59, //抖音
        WeWork = 60, //企业微信
        Oasis = 64, //绿洲
        KuaiShou = 68, //快手
        TikTok = 70, //TikTok
        Littleredbook = 67,
#if UNITY_ANDROID
        KakaoPlatform = 44,
        EvernoteInternational = 12,
        WechatPlatform = 22,
        QQPlatform = 24,
        YixinPlatform = 38,

#elif UNITY_IPHONE
        //Reddit = 56,			//Reddit
        Apple = 61,            //苹果登录
        SnapChat = 66,         //Snapchat
		WatermelonVideo = 69,   //西瓜视频
		YixinPlatform = 994,    //Yixin series
		KakaoPlatform = 995,    //Kakao series
		EvernoteInternational = 996,//Evernote InternationaL Edition
		WechatPlatform = 997,   //Wechat Series
		QQPlatform = 998,		//QQ Series
		DingdingShare = 999,    //钉钉share
#endif
    }
}