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
  獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使
</p>

<p align="center">
  <a href="https://gameframex.doc.alianblank.com">文檔</a> ·
  <a href="#快速開始">快速開始</a> ·
  <a href="https://qm.qq.com/q/3dIpogITg">QQ群</a> ·
  語言: <a href="README.md">English</a> ·
  <a href="README.zh-CN.md">简体中文</a> ·
  **繁體中文** ·
  <a href="README.ja.md">日本語</a> ·
  <a href="README.ko.md">한국어</a>
</p>

---

## 項目簡介

GameFrameX.ShareSDK 是 GameFrameX 框架的 ShareSDK 組件。它提供了跨多個平台的社交分享和授權統一接口。

## 功能特性

- 初始化 SDK
- 授權
- 獲取用戶資訊
- 分享內容
- 顯示分享選單
- 顯示分享視圖
- 獲取 Token
- 移除授權

## 平台支援

新浪微博、騰訊微博、豆瓣、QQ空間、人人網、開心網、朋友網、Facebook、Twitter、Evernote、Foursquare、GooglePlus、Instagram、LinkedIn、Tumblr、郵件、簡訊、列印、複製、微信、微信朋友圈、QQ、Instapaper、Pocket、有道雲筆記、Pinterest、Flickr、Dropbox、VKontakte、微信收藏、易信會話、易信朋友圈、易信收藏、明道、Line、WhatsApp、KakaoTalk、KakaoStory、FacebookMessenger、Telegram、藍牙、阿里社交、阿里社交朋友圈、釘釘、Youtube、美拍、CMCC、Reddit、天翼、FacebookAccount、抖音、企業微信、綠洲、快手、TikTok、小紅書、Apple、SnapChat、西瓜視頻

## 快速開始

### 1. 掛載組件

將 `ShareSDK` 組件掛載到 `GameEntry` 遊戲入口物件上。

### 2. 設定參數

在 `ShareSDK` 組件上設定 `AppKey` 和 `AppSecret`。

### 3. 呼叫方法

```csharp
// 獲取 ShareSDK 組件
var shareSdkComponent = GameEntry.GetComponent<ShareSDK>();

// 初始化
shareSdkComponent.InitSDK("Your AppKey", "Your AppSecret");

// 授權
shareSdkComponent.Authorize(PlatformType.WeChat);

// 獲取用戶資訊
shareSdkComponent.GetUserInfo(PlatformType.WeChat);

// 分享內容
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

在 `AndroidManifest.xml` 檔案的 `application` 節點中加入以下配置：

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

### 2. 添加庫引用

在 `build.gradle` 檔案中加入以下庫引用：

```groovy
implementation 'com.google.android.gms:play-services-games-v2:+'
implementation 'com.google.android.gms:play-services-auth:19.0.0'
```

## 文檔與資源

- [官方文檔](https://gameframex.doc.alianblank.com)

## 社區與支援

- QQ群: [加入](https://qm.qq.com/q/3dIpogITg)

## 更新日誌

查看 [Releases](https://github.com/GameFrameX/com.gameframex.unity.sharesdk/releases) 了解更新日誌。

## 開源協議

本專案基於 MIT 協議開源 - 詳見 [LICENSE](https://github.com/GameFrameX/com.gameframex.unity.sharesdk/blob/main/LICENSE) 檔案。
