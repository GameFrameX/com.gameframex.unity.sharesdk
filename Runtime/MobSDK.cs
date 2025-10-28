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
using System.IO;
using System.Text;
using UnityEngine;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace cn.sharesdk.unity3d
{
    public class MobSDK : MonoBehaviour
    {
#if UNITY_IPHONE || UNITY_IOS
		public getPolicyHandle getPolicy;
#endif
        public MobSDKImpl sdk;
        public OnSubmitPolicyGrantResultCallback onSubmitPolicyGrantResultCallback;

        public delegate void OnSubmitPolicyGrantResultCallback(bool success);

        void Awake()
        {
#if UNITY_IPHONE
				sdk = new iOSMobSDKImpl(gameObject);
#elif UNITY_ANDROID
            sdk = new AndroidMobSDKImpl(gameObject);
#endif
        }

        private void _PolicyGrantResultCallback(bool success)
        {
            onSubmitPolicyGrantResultCallback(success);
        }

        /// <summary>
        /// 提交用户授权结果给MobSDK
        /// </summary>
        public Boolean submitPolicyGrantResult(bool granted)
        {
            return sdk.submitPolicyGrantResult(granted);
        }

        /// <summary>
        /// 是否允许展示二次确认框
        /// </summary>
        public void setAllowDialog(bool allowDialog)
        {
            sdk.setAllowDialog(allowDialog);
        }

        /// <summary>
        /// 设置二次确认框样式
        /// </summary>
        public void setPolicyUi(string backgroundColorRes, string positiveBtnColorRes, string negativeBtnColorRes)
        {
            sdk.setPolicyUi(backgroundColorRes, positiveBtnColorRes, negativeBtnColorRes);
        }
#if UNITY_IPHONE || UNITY_IOS
		public delegate void getPolicyHandle(string content);

		public void getPrivacyPolicy(bool url, string language) {
			sdk.getPrivacyPolicy(url, language);
		}

		public string getDeviceCurrentLanguage() {
			return sdk.getDeviceCurrentLanguage();
		}

		private void _Callback(string data) {
			if (data == null) {
				return;
			}

			Hashtable res = (Hashtable)MiniJSON.jsonDecode(data);
			if (res == null || res.Count <= 0) {
				return;
			}

			int status = Convert.ToInt32(res["status"]);
			int action = Convert.ToInt32(res["action"]);

			switch(status) {
				case 1: {
					Console.WriteLine(data);
					Hashtable resp = (Hashtable) res["res"];
					if (action == 1) {
						if (getPolicy != null) {
							getPolicy((string)resp["url"]);
						}
					}
					break;
				}
				case 2: {
					break;
				}
				case 3: {
					break;
				}
			}
		}
#endif

#if UNITY_ANDROID
        public string getPrivacyPolicy(bool url, string language)
        {
            return sdk.getPrivacyPolicy(url, language);
        }
#endif
    }
}