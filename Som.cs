using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //É necessãrio adicionar esse namespace para mexer com o áudio!

//Esse Script serve para criar uma classe chamada Som, que usaremos para tocar todos clipes de áudio mais facilmente

[System.Serializable] //Faz com que o vetor Soms criado no script Audio possa ser mostrado na interface da Unity
public class Som {

    public AudioClip Clipe; //Cada instância da classe Som tem um AudioClip
    public string Nome; //Cada instância também terá um Nome, para ser facilmente identificada

    [Range(0,1f)] //Range serve para definir os valores máximo e mínimo para a variável logo abaixo dele, nesse caso Volume
    public float Volume; //Será usada para controlar o volume do clipe de áudio

    [Range(-3f, 3f)]
    public float Altura; //Será usada para controlar a altura do clipe de áudio

    [Range(0, 1f)]
    public float SpatialBlend; //Será usada para controlar o quanto que o som é afetado pela sua posição no espaço

    public GameObject ObjetoFonte; //GameObject que será a fonte do áudio

    [HideInInspector] //variável não aparecerá na interface da Unity
    public AudioSource Fonte; //Essa variável deve ser pública para que possa ser acessada no script Audio, mas não deve aparecer na interface da Unity
                              //Serve para criar um AudioSource, necessário para tocar o áudio!

    public float DistanciaMinima; //Recebe a distância a partir da qual o som para de aumentar conforme chega-se perto da fonte
    public float DistanciaMaxima; //Recebe a distância a partir da qual para-se de ouvir o som

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
