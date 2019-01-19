using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[ExecuteInEditMode]
public class test : MonoBehaviour
{

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

        string fullPath = "Assets/StreamingAssets" + "/";  //路径


        if (DataManager.Instance.dataStruct != null)
        {
            //获取指定路径下面的所有资源文件
            if (Directory.Exists(fullPath))
            {

                DirectoryInfo direction = new DirectoryInfo(fullPath);
                FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
                FileInfo[] fileinfo = new FileInfo[files.Length / 2];
                string a = Application.streamingAssetsPath;
                for (int i = 0; i < files.Length; i++) //排序文件
                {
                    if (!files[i].Name.Contains("meta"))
                    {
                        string name = files[i].Name.Remove(0, 4);
                        int index = int.Parse(name);
                        fileinfo[index-1] = files[i];
                    }
                }

                for (int i = 0; i < fileinfo.Length; i++) //解析文件
                {
                    thead.FilePath = Application.streamingAssetsPath + "/" + fileinfo[i].Name;
                    thead.FileName = fileinfo[i].Name;
                    thead.ReadFile();
                }
            }
          
        }
    }
}