using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRender : MonoBehaviour {
    private int m_number;
	// Use this for initialization
	void Start () {
        m_number = 0;
        DataManager dataManager = DataManager.Instance;
        Mesh mesh = new Mesh();

        mesh.vertices = dataManager.dataStruct[4].Points.ToArray();
        mesh.triangles = DataManager.Instance.dataStruct[0].PointRelation.ToArray();

        MeshFilter meshfilter = this.gameObject.GetComponent<MeshFilter>();
        meshfilter.mesh = mesh;
        Debug.Log(dataManager.dataStruct[0].FileName);
    }

    // Update is called once per frame
    void Update () {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Mesh_U();
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Mesh_D();
        //}
    }

    public void Mesh_U()
    {
        DataManager dataManager = DataManager.Instance;
        m_number -= 1;
        if (m_number < 0)  { m_number = 0; }

        Debug.Log("加载" + dataManager.dataStruct[m_number].FileName);

        Mesh mesh = new Mesh();
        mesh.vertices = dataManager.dataStruct[m_number].Points.ToArray();
        mesh.triangles = DataManager.Instance.dataStruct[0].PointRelation.ToArray();
        MeshFilter meshfilter = this.gameObject.GetComponent<MeshFilter>();
        meshfilter.mesh = mesh;

        Debug.Log(dataManager.dataStruct[m_number].FileName);
    }

    public void Mesh_D()
    {
        DataManager dataManager = DataManager.Instance;
        m_number += 1;
        if (m_number > DataManager.Instance.dataStruct.Count)  { m_number = DataManager.Instance.dataStruct.Count; }

        Debug.Log("加载" + dataManager.dataStruct[m_number].FileName);

        Mesh mesh = new Mesh();
        mesh.vertices = dataManager.dataStruct[m_number].Points.ToArray();
        mesh.triangles = DataManager.Instance.dataStruct[0].PointRelation.ToArray();
        MeshFilter meshfilter = this.gameObject.GetComponent<MeshFilter>();
        meshfilter.mesh = mesh;

        Debug.Log(dataManager.dataStruct[m_number].FileName);
    }

}
