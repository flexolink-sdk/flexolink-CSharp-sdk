using flexo_sdk.com.flexo.sdk.callback;
using flexo_sdk.com.flexo.sdk.vo;
using System.Diagnostics;

namespace flexolink_CSharp_sdk
{
    /**
      *  连接设备
      */
    public class FlexoConnectCallbackListener : FlexoConnectCallback
    {
        /**
         * 事件回调
         * 0 脱落 1连接
         */
        public void eventCallback(int eventNum)
        {
            if (eventNum == 1)
            {
                Debug.WriteLine("佩戴事件");
            }
            else
            {
                Debug.WriteLine("脱落事件");
            }

        }

        /**
         * 返回连接是否成功
         */
        public void onConnectResult(ResultVo resultVo)
        {
            Debug.WriteLine("连接状态:" + resultVo.getResultType());

        }

        /**
         * 异常事件
         */
        public void onError(ResultVo resultVo)
        {
            Debug.WriteLine("异常事件:" + resultVo.getMsg());
        }
    }
}
