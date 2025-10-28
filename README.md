# GameFrameX.ShareSDK

> GameFrameX.ShareSDK is the ShareSDK component for the GameFrameX framework.

## Features

- `Initialize SDK`
- `Authorize`
- `Get User Info`
- `Share Content`
- `Show Share Menu`
- `Show Share View`
- `Get Token`
- `Remove Authorize`

## Supported Platforms

- SinaWeibo
- TencentWeibo
- DouBan
- QZone
- Renren
- Kaixin
- Pengyou
- Facebook
- Twitter
- Evernote
- Foursquare
- GooglePlus
- Instagram
- LinkedIn
- Tumblr
- Mail
- SMS
- Print
- Copy
- WeChat
- WeChatMoments
- QQ
- Instapaper
- Pocket
- YouDaoNote
- Pinterest
- Flickr
- Dropbox
- VKontakte
- WeChatFavorites
- YiXinSession
- YiXinTimeline
- YiXinFav
- MingDao
- Line
- WhatsApp
- KakaoTalk
- KakaoStory
- FacebookMessenger
- Telegram
- Bluetooth
- AliSocial
- AliSocialMoments
- Dingding
- Youtube
- MeiPai
- CMCC
- Reddit
- ESurfing
- FacebookAccount
- Douyin
- WeWork
- Oasis
- KuaiShou
- TikTok
- Littleredbook
- Apple
- SnapChat
- WatermelonVideo

## How to Use

1.  **Mount the Component**
    Mount the `ShareSDK` component on the `GameEntry` game entry object.

2.  **Set Parameters**
    Set the `AppKey` and `AppSecret` on the `ShareSDK` component.

3.  **Call Methods**
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
