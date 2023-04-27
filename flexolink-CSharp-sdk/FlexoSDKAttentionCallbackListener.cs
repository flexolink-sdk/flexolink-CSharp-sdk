using flexo_sdk.com.flexo.sdk.callback;
using System.Diagnostics;

namespace flexo_sdk
{
    internal class FlexoSDKAttentionCallbackListener : FlexoSDKAttentionCallback
    {
        /**
         * 注意力值
         * @param num 0-100 100是非常专注
         */
        public void callback(double num)
        {
            Debug.WriteLine("专注度指数:" + num);
        }
    }
}