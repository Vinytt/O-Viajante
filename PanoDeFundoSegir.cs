using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanoDeFundoSegir : MonoBehaviour {

    public GameObject Camera;

    public GameObject PanoDeFundo;

    float XCamera; //Float que guarda a posição da Câmera no Eixo X

    float YCamera; //Float que guarda a posição da Câmera no Eixo Y

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        XCamera = Camera.transform.position.x;

        YCamera = Camera.transform.position.y;

        //Não podemos atribuir o transform.position da Câmera diretamente ao transform.position do Pano de Fundo, por isso precisamos dessas variáveis
        PanoDeFundo.transform.position = new Vector3(XCamera, YCamera, PanoDeFundo.transform.position.z);
	}
}
