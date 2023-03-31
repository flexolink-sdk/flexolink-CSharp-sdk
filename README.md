# flexolink-CSharp-sdk
https://openplatform.flexolinkai.com/#/guide/CSharp/access
快速接入SDK
#购买柔灵产品
开发者可联系业务人员购买柔灵肌电产品与脑电产品。
如使用本sdk需联系业务人员获取柔灵科技蓝牙适配器

#生成 App Key
每个应用程序都需要一个唯一的应用程序密钥(App Key)来初始化SDK。
获取方式：请联系业务人员获取

示例代码
1、初始化SDK
            //初始化sdk
            FlexoSDK flexoSDK = new FlexoSDKEEG(appkey, appSecret);
复制代码
2、扫描设备
          	// appkey 与appSecret联系业务人员获取 
            FlexoSDK flexoSDK = new FlexoSDKEEG("appkey", "appSecret");
            //过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备 portName：蓝牙适配器串口 默认 COM5
            flexoSDK.connectBleDevice("portName", "Flex-BM07-010002", new FlexoConnectCallbackListener());

            Thread.Sleep(5000);
            //主动关闭连接
            flexoSDK.closeDevice();
