using flexo_sdk.com.flexo.sdk.callback;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flexolink_CSharp_sdk
{

    /**
     *  扫描设备
     */
    public class FlexoScanCallbackListener : FlexoScanCallback
    {
        /**
         * 扫描到蓝牙，输出内容
         */
        public void callback(string text)
        {
            Debug.WriteLine("设备名称:" + text);
        }
    }
}
