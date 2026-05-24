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
  インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援
</p>

<p align="center">
  <a href="https://gameframex.doc.alianblank.com">ドキュメント</a> ·
  <a href="#クイックスタート">クイックスタート</a> ·
  <a href="https://qm.qq.com/q/3dIpogITg">QQグループ</a> ·
  言語: <a href="README.md">English</a> ·
  <a href="README.zh-CN.md">简体中文</a> ·
  <a href="README.zh-TW.md">繁體中文</a> ·
  **日本語** ·
  <a href="README.ko.md">한국어</a>
</p>

---

## プロジェクト概要

GameFrameX.ShareSDK は GameFrameX フレームワークの ShareSDK コンポーネントです。複数プラットフォームに対応したソーシャルシェアと認証の統一インターフェースを提供します。

## 機能

- SDK の初期化
- 認証
- ユーザー情報の取得
- コンテンツのシェア
- シェアメニューの表示
- シェアビューの表示
- トークンの取得
- 認証の解除

## プラットフォーム対応

SinaWeibo、TencentWeibo、DouBan、QZone、Renren、Kaixin、Pengyou、Facebook、Twitter、Evernote、Foursquare、GooglePlus、Instagram、LinkedIn、Tumblr、メール、SMS、印刷、コピー、WeChat、WeChatMoments、QQ、Instapaper、Pocket、YouDaoNote、Pinterest、Flickr、Dropbox、VKontakte、WeChatFavorites、YiXinSession、YiXinTimeline、YiXinFav、MingDao、Line、WhatsApp、KakaoTalk、KakaoStory、FacebookMessenger、Telegram、Bluetooth、AliSocial、AliSocialMoments、Dingding、Youtube、MeiPai、CMCC、Reddit、ESurfing、FacebookAccount、Douyin、WeWork、Oasis、KuaiShou、TikTok、Littleredbook、Apple、SnapChat、WatermelonVideo

## クイックスタート

### 1. コンポーネントのマウント

`ShareSDK` コンポーネントを `GameEntry` ゲームエントリオブジェクトにマウントします。

### 2. パラメータの設定

`ShareSDK` コンポーネントに `AppKey` と `AppSecret` を設定します。

### 3. メソッドの呼び出し

```csharp
// ShareSDK コンポーネントを取得
var shareSdkComponent = GameEntry.GetComponent<ShareSDK>();

// 初期化
shareSdkComponent.InitSDK("Your AppKey", "Your AppSecret");

// 認証
shareSdkComponent.Authorize(PlatformType.WeChat);

// ユーザー情報の取得
shareSdkComponent.GetUserInfo(PlatformType.WeChat);

// コンテンツのシェア
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

## Android 設定

### 1. AndroidManifest.xml の設定

`AndroidManifest.xml` ファイルの `application` ノードに以下の設定を追加します：

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

### 2. ライブラリ参照の追加

`build.gradle` ファイルに以下のライブラリ参照を追加します：

```groovy
implementation 'com.google.android.gms:play-services-games-v2:+'
implementation 'com.google.android.gms:play-services-auth:19.0.0'
```

## ドキュメントとリソース

- [公式ドキュメント](https://gameframex.doc.alianblank.com)

## コミュニティとサポート

- QQグループ: [参加](https://qm.qq.com/q/3dIpogITg)

## 変更履歴

変更履歴は [Releases](https://github.com/GameFrameX/com.gameframex.unity.sharesdk/releases) をご覧ください。

## ライセンス

このプロジェクトは MIT ライセンスの下で公開されています - 詳細は [LICENSE](https://github.com/GameFrameX/com.gameframex.unity.sharesdk/blob/main/LICENSE) ファイルをご覧ください。
