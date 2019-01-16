using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStruct {
    /// <summary>
    /// 点
    /// </summary>
    public List<Vector3> Points = new List<Vector3>();
    /// <summary>
    /// 点关系
    /// </summary>
    public List<int> PointRelation  = new List<int>();
    /// <summary>
    /// 点数量
    /// </summary>
    public int PointCount;
    /// <summary>
    /// 点关系的行数
    /// </summary>
    public int PointRelationCount;
    /// <summary>
    /// 法线
    /// </summary>
    public List<Vector3> Normals;
    /// <summary>
    /// UV
    /// </summary>
    public List<Vector2> UV;
    /// <summary>
    /// 文件名
    /// </summary>
    public string FileName;
    /// <summary>
    /// 文件路径
    /// </summary>
    public string FilePath;
    /// <summary>
    /// 文件序列
    /// </summary>
    public int Index;
}
