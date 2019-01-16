using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[ExecuteInEditMode]
public class test: MonoBehaviour {

    //private TheadIO thead;
    //public string filename;
    //public void Awake()
    //{
    //    thead = new TheadIO();
    //    thead.InitPath(Application.streamingAssetsPath + "/" + filename);
    //    thead.FileName = filename;
    //    Debug.Log(thead.ReadFile());


    //}
    private TheadIO thead;
    public string filename;
    public void Awake()
    {
        thead = new TheadIO();
        List<FileInfo> fileinfo = new List<FileInfo>();
        string fullPath = "Assets/StreamingAssets" + "/";  //路径

        //获取指定路径下面的所有资源文件
        if (Directory.Exists(fullPath))
        {

            DirectoryInfo direction = new DirectoryInfo(fullPath);
            FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
            string a = Application.streamingAssetsPath;
            for (int i = 0; i < files.Length; i++)
            {
                if (!files[i].Name.Contains("meta"))
                {
                    thead.ReadFile(Application.streamingAssetsPath + "/" + files[i].Name);
                }
            }
            Debug.Log(files.Length);



            //for (int i = 0; i < files.Length; i++)
            //{
            //    if (files[i].Name.EndsWith(".meta"))
            //    {
            //        continue;
            //    }
            //    Debug.Log("Name:" + files[i].Name);  //打印出来这个文件架下的所有文件
            //    //Debug.Log( "FullName:" + files[i].FullName );  
            //    //Debug.Log( "DirectoryName:" + files[i].DirectoryName );  
            //}
        }
    }
}
