using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO;
using System.Text;
using System;
using System.Text.RegularExpressions;

/// <summary>
/// 多线程 文件读取 
/// </summary>
public class TheadIO {

    public string FilePath;
    public string FileName;
    private DataManager dataManager;
    private StreamReader Sr;
    private string DataLine;
    private bool IsNODE;
    private bool IsELEMENT_SHELL;

    public void InitPath(string path) {
        FilePath = path;
    }
    /// <summary>
    /// 读取文件
    /// </summary>
    public bool ReadFile() {
        Sr = new StreamReader(FilePath);
        DataStruct dataStruct = new DataStruct();
        dataStruct.Points = new List<Vector3>(new Vector3[20000]);
        Debug.Log(dataStruct.Points.Count);
        //取每个文件前四行 文件头
        for (int i = 0; i < 4; i++) {
            if ((DataLine = Sr.ReadLine()) != null) {
                if (DataLine.Contains("$STATE_NO")) {
                    string[] index = DataLine.Split('=');
                    dataStruct.Index = Convert.ToInt32(index[index.Length - 1]);
                    Debug.Log("Index  :" + dataStruct.Index);
                }
            }
        }

        while (true) {
            if ((DataLine = Sr.ReadLine()) == null)
                break;
            if (DataLine.Contains("*") || DataLine.Contains("$")) {
                IsELEMENT_SHELL = false;
                IsNODE = false;
                if (DataLine == "*NODE") {
                    Debug.Log(DataLine);
                    IsNODE = true;
                }
                else if (DataLine == ("*ELEMENT_SHELL")) {
                    Debug.Log(DataLine);
                    IsELEMENT_SHELL = true;
                }
            }
            else {
                DataLine = DataLine.Trim();
                DataLine = new Regex("[\\s]+").Replace(DataLine, " ");
                string[] DataSplit = DataLine.Split(' ');
                if (IsNODE) {
                    dataStruct.Points[Convert.ToInt32(DataSplit[0])] = (new Vector3(Convert.ToSingle(DataSplit[1]), Convert.ToSingle(DataSplit[2]), Convert.ToSingle(DataSplit[3])));
                    Debug.Log(dataStruct.Points.Count);
                }
                if (IsELEMENT_SHELL) {
                    dataStruct.PointRelation.AddRange(new int[]{ Convert.ToInt32(DataSplit[2]),
                                                                 Convert.ToInt32(DataSplit[3]),
                                                                 Convert.ToInt32(DataSplit[4]),
                                                                 Convert.ToInt32(DataSplit[3]),
                                                                 Convert.ToInt32(DataSplit[4]),
                                                                 Convert.ToInt32(DataSplit[5]) });
                }
            }

        }
        Sr.Close();
        Sr.Dispose();
        return true;
    }
}
