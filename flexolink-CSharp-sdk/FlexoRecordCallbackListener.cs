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
      *  开始记录设备eeg数据
      */
    public class FlexoRecordCallbackListener : FlexoDeviceRecordCallback
    {
        /**
         * 自动结束记录
         */
        public void onAutoStopRecord()
        {
            Debug.WriteLine("onAutoStopRecord:回调");

        }
        /**
         * 采集失败
         */
        public void onRecordFailure(ResultVo resultVo)
        {
            Debug.WriteLine("onRecordFailure:回调");
        }
        /**
         * 正在记录
         */
        public void onRecording()
        {
            Debug.WriteLine("onRecording:回调");
        }
        /**
         * 开始记录
         */
        public void onStartRecord(string edfPath)
        {
            Debug.WriteLine("记录开始:回调");
        }

        /**
         * 记录完成
         */
        public void onStopRecord()
        {
            Debug.WriteLine("onStopRecord:回调");
        }
    }
}
