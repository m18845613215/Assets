using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class ToolManager {
    public static string BytesToString(byte[] BToS) {
        return Encoding.Default.GetString(BToS);
    }

    public static string GetSyatemTime() {
        //获取系统当前时间
        DateTime NowTime = DateTime.Now.ToLocalTime();
        return NowTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
