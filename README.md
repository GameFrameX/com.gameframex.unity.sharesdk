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
  All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams
</p>

<p align="center">
  <a href="https://gameframex.doc.alianblank.com">Documentation</a> ·
  <a href="#quick-start">Quick Start</a> ·
  <a href="https://qm.qq.com/q/3dIpogITg">QQ Group</a> ·
  Language: **English** ·
  <a href="README.zh-CN.md">简体中文</a> ·
  <a href="README.zh-TW.md">繁體中文</a> ·
  <a href="README.ja.md">日本語</a> ·
  <a href="README.ko.md">한국어</a>
</p>

---

## Project Overview

GameFrameX.ShareSDK is the ShareSDK component for the GameFrameX framework. It provides a unified interface for social sharing and authorization across multiple platforms.

## Features

- Initialize SDK
- Authorize
- Get User Info
- Share Content
- Show Share Menu
- Show Share View
- Get Token
- Remove Authorize

## Supported Platforms

SinaWeibo, TencentWeibo, DouBan, QZone, Renren, Kaixin, Pengyou, Facebook, Twitter, Evernote, Foursquare, GooglePlus, Instagram, LinkedIn, Tumblr, Mail, SMS, Print, Copy, WeChat, WeChatMoments, QQ, Instapaper, Pocket, YouDaoNote, Pinterest, Flickr, Dropbox, VKontakte, WeChatFavorites, YiXinSession, YiXinTimeline, YiXinFav, MingDao, Line, WhatsApp, KakaoTalk, KakaoStory, FacebookMessenger, Telegram, Bluetooth, AliSocial, AliSocialMoments, Dingding, Youtube, MeiPai, CMCC, Reddit, ESurfing, FacebookAccount, Douyin, WeWork, Oasis, KuaiShou, TikTok, Littleredbook, Apple, SnapChat, WatermelonVideo

## Quick Start

### 1. Mount the Component

Mount the `ShareSDK` component on the `GameEntry` game entry object.

### 2. Set Parameters

Set the `AppKey` and `AppSecret` on the `ShareSDK` component.

### 3. Call Methods

```csharp
// Get the ShareSDK component
var shareSdkComponent = GameEntry.GetComponent<ShareSDK>();

// Initialize
shareSdkComponent.InitSDK("Your AppKey", "Your AppSecret");

// Authorize
shareSdkComponent.Authorize(PlatformType.WeChat);

// Get User Info
shareSdkComponent.GetUserInfo(PlatformType.WeChat);

// Share Content
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

## Android Configuration

### 1. Configure AndroidManifest.xml

Add the following configuration to the `application` node of the `AndroidManifest.xml` file:

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

### 2. Add Library References

Add the following library references to the `build.gradle` file:

```groovy
implementation 'com.google.android.gms:play-services-games-v2:+'
implementation 'com.google.android.gms:play-services-auth:19.0.0'
```

## Documentation & Resources

- [Official Documentation](https://gameframex.doc.alianblank.com)

## Community & Support

- QQ Group: [Join](https://qm.qq.com/q/3dIpogITg)

## Changelog

See [Releases](https://github.com/GameFrameX/com.gameframex.unity.sharesdk/releases) for changelog.

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/GameFrameX/com.gameframex.unity.sharesdk/blob/main/LICENSE) file for details.
