<p align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="GameFrameX Logo" width="160" />
</p>

<h1 align="center">GameFrameX ShareSDK</h1>

<p align="center">
  <a href="https://github.com/GameFrameX/com.gameframex.unity.sharesdk/releases">
    <img src="https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.sharesdk?style=flat-square" alt="Version" />
  </a>
  <a href="https://github.com/GameFrameX/com.gameframex.unity.sharesdk/blob/main/LICENSE">
    <img src="https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.sharesdk?style=flat-square" alt="License" />
  </a>
  <a href="https://gameframex.doc.alianblank.com">
    <img src="https://img.shields.io/badge/Documentation-online-blue?style=flat-square" alt="Documentation" />
  </a>
</p>

<p align="center">
  独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使
</p>

<p align="center">
  <a href="https://gameframex.doc.alianblank.com">文档</a> ·
  <a href="#快速开始">快速开始</a> ·
  <a href="https://qm.qq.com/q/3dIpogITg">QQ群</a> ·
  语言: <a href="README.md">English</a> ·
  **简体中文** ·
  <a href="README.zh-TW.md">繁體中文</a> ·
  <a href="README.ja.md">日本語</a> ·
  <a href="README.ko.md">한국어</a>
</p>

---

## 项目简介

GameFrameX.ShareSDK 是 GameFrameX 框架的 ShareSDK 组件。它提供了跨多个平台的社交分享和授权统一接口。

## 功能特性

- 初始化 SDK
- 授权
- 获取用户信息
- 分享内容
- 显示分享菜单
- 显示分享视图
- 获取 Token
- 移除授权

## 平台支持

新浪微博、腾讯微博、豆瓣、QQ空间、人人网、开心网、朋友网、Facebook、Twitter、Evernote、Foursquare、GooglePlus、Instagram、LinkedIn、Tumblr、邮件、短信、打印、复制、微信、微信朋友圈、QQ、Instapaper、Pocket、有道云笔记、Pinterest、Flickr、Dropbox、VKontakte、微信收藏、易信会话、易信朋友圈、易信收藏、明道、Line、WhatsApp、KakaoTalk、KakaoStory、FacebookMessenger、Telegram、蓝牙、阿里社交、阿里社交朋友圈、钉钉、Youtube、美拍、CMCC、Reddit、天翼、FacebookAccount、抖音、企业微信、绿洲、快手、TikTok、小红书、Apple、SnapChat、西瓜视频

## 快速开始

### 1. 挂载组件

将 `ShareSDK` 组件挂载到 `GameEntry` 游戏入口对象上。

### 2. 设置参数

在 `ShareSDK` 组件上设置 `AppKey` 和 `AppSecret`。

### 3. 调用方法

```csharp
// 获取 ShareSDK 组件
var shareSdkComponent = GameEntry.GetComponent<ShareSDK>();

// 初始化
shareSdkComponent.InitSDK("Your AppKey", "Your AppSecret");

// 授权
shareSdkComponent.Authorize(PlatformType.WeChat);

// 获取用户信息
shareSdkComponent.GetUserInfo(PlatformType.WeChat);

// 分享内容
ShareContent content = new ShareContent();
content.SetText("this is a test string.");
content.SetImageUrl("http://ww3.sinaimg.cn/mw690/be159dedgw1evgxdt9h3fj218g0xctod.jpg");
content.SetTitle("test title");
content.SetTitleUrl("http://www.mob.com");
content.SetSite("Mob-ShareSDK");
content.SetSiteUrl("http://www.mob.com");
content.SetUrl("http://www.mob.com");
content.SetComment("test description");
content.SetMusicUrl("http://mp3.mwap8.com/destdir/Music/2009/20090601/ZuiXuanMinZuFeng20090601119.mp3");
content.SetShareType(ContentType.Image);
shareSdkComponent.ShareContent(PlatformType.WeChat, content);
```

## Android 配置

### 1. 配置 AndroidManifest.xml

在 `AndroidManifest.xml` 文件的 `application` 节点中添加以下配置：

```xml
<activity
    android:name="com.mob.tools.MobUIShell"
    android:theme="@android:style/Theme.Translucent.NoTitleBar"
    android:configChanges="keyboardHidden|orientation|screenSize"
    android:windowSoftInputMode="stateHidden|adjustResize" >
    <intent-filter>
        <data android:scheme="tencent100371282" />
        <action android:name="android.intent.action.VIEW" />
        <category android:name="android.intent.category.BROWSABLE" />
        <category android:name="android.intent.category.DEFAULT" />
    </intent-filter>
</activity>
```

### 2. 添加库引用

在 `build.gradle` 文件中添加以下库引用：

```groovy
implementation 'com.google.android.gms:play-services-games-v2:+'
implementation 'com.google.android.gms:play-services-auth:19.0.0'
```

## 文档与资源

- [官方文档](https://gameframex.doc.alianblank.com)

## 社区与支持

- QQ群: [加入](https://qm.qq.com/q/3dIpogITg)

## 更新日志

查看 [Releases](https://github.com/GameFrameX/com.gameframex.unity.sharesdk/releases) 了解更新日志。

## 开源协议

本项目基于 MIT 协议开源 - 详见 [LICENSE](https://github.com/GameFrameX/com.gameframex.unity.sharesdk/blob/main/LICENSE) 文件。
