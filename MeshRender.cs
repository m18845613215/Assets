using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRender : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Mesh mesh = new Mesh();
        DataManager dataManager = DataManager.Instance;
        mesh.vertices = dataManager.dataStruct[0].Points.ToArray();
        //int[] indices = new int[15];
        //indices[0] = 1;
        //indices[1] = 3;
        //indices[2] = 15;

        //indices[3] = 3;
        //indices[4] = 15;
        //indices[5] = 12;

        //indices[6] = 3;
        //indices[7] = 4;
        //indices[8] = 18;

        //indices[9] = 4;
        //indices[10] = 18;
        //indices[11] = 15;

        //indices[12] = 4;
        //indices[13] = 2;
        //indices[14] = 6;
        //mesh.triangles = indices;
        mesh.triangles = DataManager.Instance.dataStruct[0].PointRelation.ToArray();

        MeshFilter meshfilter = this.gameObject.GetComponent<MeshFilter>();
        meshfilter.mesh = mesh;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
