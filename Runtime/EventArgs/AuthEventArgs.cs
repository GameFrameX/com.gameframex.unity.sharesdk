using System.Collections;
using cn.sharesdk.unity3d;
using GameFrameX.Event.Runtime;
using GameFrameX.Runtime;

namespace GameFrameX.ShareSdk.Runtime
{
    /// <summary>
    /// 授权事件
    /// </summary>
    public sealed class AuthEventArgs : GameEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly string EventId = typeof(AuthEventArgs).FullName;

        public override void Clear()
        {
            Data.Clear();
            Type = PlatformType.Unknown;
            State = ResponseState.BeginUPLoad;
        }

        public override string Id
        {
            get { return EventId; }
        }

        /// <summary>
        /// 创建授权事件参数实例
        /// </summary>
        /// <param name="state">响应状态</param>
        /// <param name="type">平台类型</param>
        /// <param name="data">数据哈希表</param>
        /// <returns>授权事件参数实例</returns>
        public static AuthEventArgs Create(ResponseState state, PlatformType type, Hashtable data)
        {
            var eventArgs = ReferencePool.Acquire<AuthEventArgs>();
            eventArgs.State = state;
            eventArgs.Type = type;
            eventArgs.Data = data;
            return eventArgs;
        }

        /// <summary>
        /// 获取或设置数据哈希表
        /// </summary>
        public Hashtable Data { get; private set; }

        /// <summary>
        /// 获取或设置平台类型
        /// </summary>
        public PlatformType Type { get; private set; }

        /// <summary>
        /// 获取或设置响应状态
        /// </summary>
        public ResponseState State { get; private set; }
    }
}