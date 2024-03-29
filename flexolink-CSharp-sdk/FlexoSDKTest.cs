﻿using flexo_sdk.com.flexo.api.impl;
using flexo_sdk.com.flexo.sdk.api;
using flexo_sdk.com.flexo.sdk.bean;
using flexo_sdk.com.flexo.sdk.util;
using flexolink_CSharp_sdk;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace flexo_sdk
{

    class FlexoSDKTest
    {

        static string portName = "COM5";
        //appkey
        static string appkey = "**";
        //appSecret
        static string appSecret = "**";
        //授权信息存储路径
        static string filePath = @"D:\tmp\flexoSDK.auth";
        static string deviceName = "Flex-BM07-010002";
        //初始化sdk
        static FlexoSDK flexoSDK = null;
        public static void Main(string[] ages)
        {
            // 获取离线授权
            getAuth();
            // 读取离线授权信息并初始化sdk
            flexoSDK = new FlexoSDKEEG(readAuthCode());
            // 开始使用
            startAttention();

        }
        // 获取离线授权
        private static void getAuth(){
            FlexoAuth fexoAuth = new FlexoAuth();
            string authText = fexoAuth.getAuth(appkey, appSecret);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(authText);
            }

        }

        // 读取已获取的离线授权码
        private static string readAuthCode()
        {
            string authText = "";
            using (StreamReader reader = new StreamReader(filePath))
            {
                authText = reader.ReadToEnd();
            }
            
            return authText;
        }
        // 获取专注度监听
        private static void startAttention()
        {
           
        
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName, deviceName, new FlexoConnectCallbackListener());
            Thread.Sleep(10000);
            //调用注意力接口前需进行信号质量检测接口
            //float[] f = flexoSDK.pickDataByPointStamp(10);
            //bool b = flexoSDK.checkSignalQuality(f, f.Length);
            //if (b) {
            //    flexoSDK.setSleepStageListener(new FlexoSleepStageCallbackListener());
            //}
            flexoSDK.startAttention(new FlexoSDKAttentionCallbackListener());
            Thread.Sleep(10000000);
            //关闭注意力监听
            flexoSDK.stopAttention();
            Thread.Sleep(10000);
            //主动关闭连接
            flexoSDK.closeDevice();
        }

        //扫描设备
        private static void scanBleDeviceTest()
        {
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //扫描设备
            flexoSDK.scanBleDevice(portName, new FlexoScanCallbackListener());


            Thread.Sleep(1000000);
            //停止扫描
            flexoSDK.stopScan();

        }


        //连接设备
        private static void connectBleDeviceTest()
        {
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());

            Thread.Sleep(5000);
            //主动关闭连接
            flexoSDK.closeDevice();
        }

        //判断设备是否连接
        private static void isConnectedTest()
        { 
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());

            for (int i = 0; i < 1000; i++)
            {
                bool b = flexoSDK.isConnected();
                Debug.WriteLine(b);

                Thread.Sleep(300);
            }
            //主动关闭连接
            flexoSDK.closeDevice();
        }

        //脑电实时数据监听
        private static void setRealDataListenerTest()
        {
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());
            Thread.Sleep(10000);
            flexoSDK.setRealDataListener(new FlexoEEGCallbackListener());
            Thread.Sleep(10000);
            //主动关闭连接
            flexoSDK.closeDevice();
        }

        //原始数据截取
        private static void pickDataByPointStampTest()
        {
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());
            Thread.Sleep(10000);
            for (int i = 0; i < 100; i++)
            {
                float[] f = flexoSDK.pickDataByPointStamp(30);
                Debug.WriteLine(f.Length);
                Thread.Sleep(1000);
            }
            Thread.Sleep(10000);
            //主动关闭连接
            flexoSDK.closeDevice();
        }

        // 是否佩戴额贴
        private static void isWearPatchTest()
        {
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());
            for (int i = 0; i < 100; i++)
            {
                bool b = flexoSDK.isWearPatch();
                Debug.WriteLine(b);
                Thread.Sleep(300);
            }
            Thread.Sleep(10000);
            //主动关闭连接
            flexoSDK.closeDevice();
        }
        // 获取蓝牙设备电量
        private static void getBatteryTest()
        {
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());
            Thread.Sleep(10000);
            for (int i = 0; i < 10; i++)
            {
                int b = flexoSDK.getBattery();
                Debug.WriteLine(b);
                Thread.Sleep(1000);
            }
            Thread.Sleep(10000);
            //主动关闭连接
            flexoSDK.closeDevice();
        }

        // 获取采集的数据质量
        private static void checkSignalQualityTest()
        {
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());
            Thread.Sleep(10000);
            for (int i = 0; i < 100; i++)
            {
                float[] f = flexoSDK.pickDataByPointStamp(10);
                bool b = flexoSDK.checkSignalQuality(f, f.Length);
                Debug.WriteLine(b);
                Thread.Sleep(1000);
            }
            Thread.Sleep(10000);
            //主动关闭连接
            flexoSDK.closeDevice();
        }

        // 开始记录eeg
        private static void startRecordTest()
        {
            TimeSpan tss = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long thisTime = Convert.ToInt64(tss.TotalMilliseconds);
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());
            Thread.Sleep(10000);
            string edf = "E:\\files\\" + thisTime + ".edf";
            UserInfo userInfo = new UserInfo();
            userInfo.setName("名称");
            userInfo.setSex(0);
            userInfo.setBirthday("1991-01-01");
            flexoSDK.startRecord(edf, userInfo, new FlexoRecordCallbackListener());
            Thread.Sleep(10000);
            for (int i = 0; i < 100; i++)
            {
                DateTime eventNow = new DateTime();
                Thread.Sleep(1000);
                DateTime eventEndNow = new DateTime();
                //写入edf事件
                flexoSDK.addEvent(eventNow, eventEndNow, "test");
                Thread.Sleep(1000);

            }
            //关闭edf
            flexoSDK.stopRecord();
            Thread.Sleep(10000);
            //主动关闭连接
            flexoSDK.closeDevice();
        }
   
        // 实时睡眠分期监听
        private static void setSleepStageListenerTest()
        {
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());
            Thread.Sleep(30000);
            //调用分期接口前需进行信号质量检测接口
            //float[] f = flexoSDK.pickDataByPointStamp(10);
            //bool b = flexoSDK.checkSignalQuality(f, f.Length);
            //if (b) {
            //    flexoSDK.setSleepStageListener(new FlexoSleepStageCallbackListener());
            //}
            flexoSDK.setSleepStageListener(new FlexoSleepStageCallbackListener());
            Thread.Sleep(100000);
            //主动关闭连接
            flexoSDK.closeDevice();
        }

        // 开启冥想-结束冥想
        private static void startMeditationTest()
        {

            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());
            Thread.Sleep(10000);
            flexoSDK.startMeditation(new FlexoEEGMeditationCallbackListener());
            Thread.Sleep(10000000);
            flexoSDK.stopMeditation();
            //主动关闭连接
            flexoSDK.closeDevice();
        }
        // 获取体位
        private static void getBodyPositionTest()
        {
   
            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());
            Thread.Sleep(10000);
            for (int i = 0; i < 100; i++)
            {
                int b = flexoSDK.getBodyPosition();
                Debug.WriteLine(b);
                Thread.Sleep(1000);
            }
            //主动关闭连接
            flexoSDK.closeDevice();
        }

        // 设置滤波
        private static void setFilterParamTest()
        {

            //授权过期时间
            long expiredAt = flexoSDK.getExpiredAt();
            //连接设备
            flexoSDK.connectBleDevice(portName,deviceName, new FlexoConnectCallbackListener());
            Thread.Sleep(10000);
            flexoSDK.setFilterParam(8,40,2);

            //主动关闭连接
            flexoSDK.closeDevice();
        }

    }

  
   
 
 
}
