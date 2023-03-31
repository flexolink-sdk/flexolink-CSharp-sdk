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
         *  eeg数据回调处理
         */
    public class FlexoEEGCallbackListener : FlexoEEGCallback
    {
        /**
         * 实时原始数据
         */
        public void onRealTimeData(float[] eegData)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < eegData.Length; i++)
            {
                str.Append(eegData[i]);
                str.Append(":");

            }
            Debug.WriteLine("eeg数据回调处理:" + str.ToString());
        }
        /**
         * 实时滤波数据
         */
        public void onRealTimeFilterData(float[] eegData)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < eegData.Length; i++)
            {
                str.Append(eegData[i]);
                str.Append(":");

            }
            Debug.WriteLine("eeg滤波数据回调处理:" + str.ToString());
        }
    }
}
