using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO;
using System.Text;
using System;

/// <summary>
/// 多线程 文件读取 
/// </summary>
public class TheadIO
{

    public string FilePath;
    public string FileName;
    private DataManager dataManager;
    private StreamReader Sr;
    private string DataLine;

    struct Node
    {
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
        //填入数据
        Node m_node;
        m_node.data = new List<string>();
        while (true)
        {
            if ((DataLine = Sr.ReadLine()) == null)
                break;

            if (DataLine.Contains("*"))
            {
                if (DataLine.Contains("NODE"))
                    Debug.Log(DataLine);
            }
            else
            {
                DataLine = DataLine.Trim();
                string[] Data = DataLine.Split(' ');
                for (int i = 0; i < Data.Length; i++)
                {
                    if (Data[i] != "")
                        m_node.data.Add(Data[i]);
                }
                Debug.Log(m_node.data[0]);
                Debug.Log(m_node.data[1]);
                Debug.Log(m_node.data[2]);
                Debug.Log(m_node.data[3]);
                //Debug.Log(m_node.data[0]);
                Sr.Close();
                Sr.Dispose();
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
