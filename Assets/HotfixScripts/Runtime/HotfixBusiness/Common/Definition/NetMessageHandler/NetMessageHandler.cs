using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniFramework.Utility;
using LitJson;
using Hotfix.EventDefine;

public static class NetMessageHandler
{
    /// <summary>
    /// 登陆
    /// </summary>
    /// <param name="code"></param>
    public static void SendLogin(string code)
    {
        UnityWebRequestTool.Get($"http://{SettingDefine.WebServerUrl}/server-box/login/{code}", OnSendLoginCallback);
    }
   
    private static void OnSendLoginCallback(string error, string jsonData)
    {
       OnCallback(error,jsonData);
       UserEventDefine.UserLoginSuccess.SendEventMessage();
    }
    
    /// <summary>
    /// 开箱子
    /// </summary>
    public static void SendOpenTreasureBox()
    {
        UnityWebRequestTool.Get($"http://{SettingDefine.WebServerUrl}/server-box/openBox/{UserDataManager.Instance.PlayerId}", OnSendOpenTreasureBox);
    }
    
    private static void OnSendOpenTreasureBox(string error, string jsonData)
    {
       OnCallback(error,jsonData);
       UserEventDefine.UserOpenTreasureBox.SendEventMessage();
    }

    /// <summary>
    /// 箱子升升级完成
    /// </summary>
    public static void SendBoxLvUpFinish()
    {
        UnityWebRequestTool.Get($"http://{SettingDefine.WebServerUrl}/server-box/boxLvUpFinish/{UserDataManager.Instance.PlayerId}", OnCallback);
    }

    /// <summary>
    /// 穿装备
    /// </summary>
    public static void SendWearTempEquip()
    {
        UnityWebRequestTool.Get($"http://{SettingDefine.WebServerUrl}/server-box/wearTempEquip/{UserDataManager.Instance.PlayerId}", OnCallback);
    }

    /// <summary>
    /// 卖装备
    /// </summary>
    public static void SendSellTempEquip()
    {
        UnityWebRequestTool.Get($"http://{SettingDefine.WebServerUrl}/server-box/sellTempEquip/{UserDataManager.Instance.PlayerId}", OnCallback);
    }

    private static void OnCallback(string error, string jsonData)
    {   
        UniLogger.Log($"jsonData = {jsonData}");
        if (!string.IsNullOrEmpty(error)) UniLogger.Error(error);
        var jUserData = JsonMapper.ToObject<JUserData>(jsonData);
        UniLogger.Log(jUserData.ToStringFormat());
        UserDataManager.Instance.InitOrRefresh(jUserData.data);
    }
}
