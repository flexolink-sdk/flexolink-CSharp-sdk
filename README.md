
# **柔灵SDK简介#SDK概述**
柔灵 SDK是一款基于柔灵科技脑电设备与肌电设备的开发套件，旨在让开发者能够使用柔灵科技产品接入自家应用程序。这样开发者就不需要具备丰富脑机接口与肌电背景知识，而可以专注于产品相关的行业应用开发。本文介绍了柔灵SDK提供的SDK语言版本，列举了最新版本SDK的获取地址。

**#快速入门**
柔灵 SDK封装了2022-10-26版本API，以访问密钥（appKey）识别调用者身份，提供自动签名等功能，方便您通过SDK接入柔灵脑电产品。实现云SDK功能需要您购买柔灵脑电产品，并申请appKey和appSecret。


**快速接入C#SDK**
**购买柔灵产品**
开发者可联系业务人员购买柔灵肌电产品与脑电产品。
如使用本sdk需联系业务人员获取柔灵科技蓝牙适配器
**生成 App Key**
每个应用程序都需要一个唯一的应用程序密钥(App Key)来初始化SDK。
获取方式：请联系业务人员获取
**开放平台地址**
https://openplatform.flexolinkai.com/#/guide/CSharp/access


**示例代码**
**初始化SDK**

```
            //初始化sdk
            FlexoSDK flexoSDK = new FlexoSDKEEG(appkey, appSecret);
```

**扫描设备**



```
          	// appkey 与appSecret联系业务人员获取 
            FlexoSDK flexoSDK = new FlexoSDKEEG("appkey", "appSecret");
            //过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备 portName：蓝牙适配器串口 默认 COM5
            flexoSDK.connectBleDevice("portName", "Flex-BM07-010002", new FlexoConnectCallbackListener());

            Thread.Sleep(5000);
            //主动关闭连接
            flexoSDK.closeDevice();
 ```

**相关依赖**：https://github.com/flexolink-sdk/flexolink-CSharp-sdk/tree/beta/flexolink-CSharp-sdk/bin/x64/Debug