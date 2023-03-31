using flexo_sdk.com.flexo.sdk.callback;
using flexo_sdk.com.flexo.sdk.vo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flexolink_CSharp_sdk
{
    /**
        *  连接设备
        */
    public class FlexoConnectCallbackListener : FlexoConnectCallback
    {
        /**
         * 返回连接是否成功
         */
        public void onConnectResult(ResultVo resultVo)
        {
            Debug.WriteLine("连接状态:" + resultVo.getResultType());

        }
    }
}
