using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class test: MonoBehaviour {

    private TheadIO thead;
    public string filename;
    public void Awake() {
        thead = new TheadIO();
        thead.InitPath(Application.streamingAssetsPath + "/" + filename);
        thead.FileName = filename;
        Debug.Log(thead.ReadFile());
    }
}
