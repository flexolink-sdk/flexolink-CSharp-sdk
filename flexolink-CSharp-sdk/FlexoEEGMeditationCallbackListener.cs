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
     * 冥想分期结果
     */
    class FlexoEEGMeditationCallbackListener : FlexoEEGMeditationCallback
    {
        public void callback(int i)
        {
            Debug.WriteLine("冥想分期结果:" + i);
        }

    }

}
