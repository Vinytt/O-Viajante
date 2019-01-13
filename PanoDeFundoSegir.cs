using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanoDeFundoSegir : MonoBehaviour {

    public GameObject Camera;

    public GameObject PanoDeFundo;

    float XCamera;

    float YCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        XCamera = Camera.transform.position.x;

        YCamera = Camera.transform.position.y;

        PanoDeFundo.transform.position = new Vector3(XCamera, YCamera, PanoDeFundo.transform.position.z);
	}
}
