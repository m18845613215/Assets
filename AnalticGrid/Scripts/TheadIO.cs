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

    /// <summary>
    /// 调用存储
    /// </summary>
    private Action CallSet;

    struct Node {
        public string[] node;
        public List<string> data;
    }

    public void InitPath(string path)
    {
        FilePath = path;
    }
    /// <summary>
    /// 读取文件
    /// </summary>
    public bool ReadFile()
    {
        Sr = new StreamReader(FilePath);
        DataStruct dataStruct = new DataStruct();
        //取每个文件前四行 文件头
        for (int i = 0; i < 4; i++)
        {
            if ((DataLine = Sr.ReadLine()) != null)
            {
                if (DataLine.Contains("$STATE_NO"))
                {
                    string[] index = DataLine.Split('=');
                    dataStruct.Index = Convert.ToInt32(index[index.Length - 1]);
                    Debug.Log("Index  :" + dataStruct.Index);
                }
            }
        }

        while (true)
        {
            if ((DataLine = Sr.ReadLine()) == null)
                break;

            if (DataLine.Contains("*"))
            {
                if (DataLine.Contains("NODE"))
                    Debug.Log(DataLine);
                CallSet += 
            }
            else
            {
                DataLine = DataLine.Trim();
                DataLine = new Regex("[\\s]+").Replace(DataLine, " ");
                string[] DataSplit = DataLine.Split(' ');
                dataStruct.Points.Add(new Vector3(Convert.ToSingle(DataSplit[1]), Convert.ToSingle(DataSplit[2]), Convert.ToSingle(DataSplit[3])));
                Debug.Log(dataStruct.Points.Count);
            }
        }
        Sr.Close();
        Sr.Dispose();
        return true;
    }
    public void ReadFirstFrame()
    {
        while ((DataLine = Sr.ReadLine()) != null)
        {
            if (DataLine.Contains("*ELEMENT_SHELL"))
            {
                Debug.Log(DataLine);
            }
        }
    }
}
