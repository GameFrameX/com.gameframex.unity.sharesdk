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
  인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현
</p>

<p align="center">
  <a href="https://gameframex.doc.alianblank.com">문서</a> ·
  <a href="#빠른-시작">빠른 시작</a> ·
  <a href="https://qm.qq.com/q/3dIpogITg">QQ 그룹</a> ·
  언어: <a href="README.md">English</a> ·
  <a href="README.zh-CN.md">简体中文</a> ·
  <a href="README.zh-TW.md">繁體中文</a> ·
  <a href="README.ja.md">日本語</a> ·
  **한국어**
</p>

---

## 프로젝트 개요

GameFrameX.ShareSDK는 GameFrameX 프레임워크의 ShareSDK 컴포넌트입니다. 여러 플랫폼에서 소셜 공유 및 인증을 위한 통합 인터페이스를 제공합니다.

## 기능

- SDK 초기화
- 인증
- 사용자 정보 가져오기
- 콘텐츠 공유
- 공유 메뉴 표시
- 공유 보기 표시
- 토큰 가져오기
- 인증 제거

## 플랫폼 지원

SinaWeibo, TencentWeibo, DouBan, QZone, Renren, Kaixin, Pengyou, Facebook, Twitter, Evernote, Foursquare, GooglePlus, Instagram, LinkedIn, Tumblr, 메일, SMS, 인쇄, 복사, WeChat, WeChatMoments, QQ, Instapaper, Pocket, YouDaoNote, Pinterest, Flickr, Dropbox, VKontakte, WeChatFavorites, YiXinSession, YiXinTimeline, YiXinFav, MingDao, Line, WhatsApp, KakaoTalk, KakaoStory, FacebookMessenger, Telegram, Bluetooth, AliSocial, AliSocialMoments, Dingding, Youtube, MeiPai, CMCC, Reddit, ESurfing, FacebookAccount, Douyin, WeWork, Oasis, KuaiShou, TikTok, Littleredbook, Apple, SnapChat, WatermelonVideo

## 빠른 시작

### 1. 컴포넌트 마운트

`ShareSDK` 컴포넌트를 `GameEntry` 게임 엔트리 객체에 마운트합니다.

### 2. 매개변수 설정

`ShareSDK` 컴포넌트에 `AppKey`와 `AppSecret`을 설정합니다.

### 3. 메서드 호출

```csharp
// ShareSDK 컴포넌트 가져오기
var shareSdkComponent = GameEntry.GetComponent<ShareSDK>();

// 초기화
shareSdkComponent.InitSDK("Your AppKey", "Your AppSecret");

// 인증
shareSdkComponent.Authorize(PlatformType.WeChat);

// 사용자 정보 가져오기
shareSdkComponent.GetUserInfo(PlatformType.WeChat);

// 콘텐츠 공유
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

## Android 설정

### 1. AndroidManifest.xml 구성

`AndroidManifest.xml` 파일의 `application` 노드에 다음 설정을 추가합니다:

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

### 2. 라이브러리 참조 추가

`build.gradle` 파일에 다음 라이브러리 참조를 추가합니다:

```groovy
implementation 'com.google.android.gms:play-services-games-v2:+'
implementation 'com.google.android.gms:play-services-auth:19.0.0'
```

## 문서 및 자료

- [공식 문서](https://gameframex.doc.alianblank.com)

## 커뮤니티 및 지원

- QQ 그룹: [가입](https://qm.qq.com/q/3dIpogITg)

## 변경 로그

변경 로그는 [Releases](https://github.com/GameFrameX/com.gameframex.unity.sharesdk/releases)에서 확인하세요.

## 라이선스

이 프로젝트는 MIT 라이선스에 따라 배포됩니다 - 자세한 내용은 [LICENSE](https://github.com/GameFrameX/com.gameframex.unity.sharesdk/blob/main/LICENSE) 파일을 참조하세요.
