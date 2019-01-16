using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据管理 单例
/// </summary>
public class DataManager: Singleton<DataManager> {
    /// <summary>
    /// 网格数据 结构体
    /// </summary>
    public List<DataStruct> dataStruct;
    public override void Awake() {
        base.Awake();
        dataStruct = new List<DataStruct>();
    }
}
