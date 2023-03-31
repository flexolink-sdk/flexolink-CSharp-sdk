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
    *  分期事件接口
    */
    public class FlexoSleepStageCallbackListener : FlexoSleepStageCallback
    {
        /**
         * 实时分期结果 0 深睡 1 浅睡 2 REM 3 清醒
         */
        public void callback(int sleepStage)
        {
            Debug.WriteLine("分期结果:{0}", sleepStage);

        }
    }
}
