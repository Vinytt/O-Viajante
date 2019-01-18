using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguirJogador : MonoBehaviour {

    public GameObject Camera;
    public GameObject Jogador;

    public Vector3 Ajuste; //representa a distancia que a câmera deve ficar do jogador

    Vector3 VelocidadeFuncao; //Velocidade de referência que será usada pela função SmoothDamp

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

    //As funções LateUpdate e FixedUpdate funcionam tal como a Update, mas são executadas imediatamente DEPOIS
    //Usaremos ela aqui pois o movimento do jogador é executado em um Update, e queremos que a câmera o siga após seu movimento
    //Do Contrário, câmera e jogador "competirão" para se mover primeiro dentro do Update! 
	void FixedUpdate () {
        Vector3 PosicaoDesejada = Jogador.transform.position + Ajuste; //Posição para qual a câmera irá

        //A função SmoothDamp faz a progressão de um Vetor A até um Vetor B, ideal para o movimento suave da câmera
        //Parâmetros: Vetor de Origem (A), Vetor Destino (B), referenciação a um Vector3 que terá seu valor alterado pela própria função e o tempo que a progressão deve demorar
        Vector3 PosicaoSuavizada = Vector3.SmoothDamp(Camera.transform.position, PosicaoDesejada, ref VelocidadeFuncao, 0.8f);
        Camera.transform.position = PosicaoSuavizada;
	}
}
