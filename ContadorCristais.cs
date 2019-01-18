
using UnityEngine;
using UnityEngine.UI; //Permite manipular a UI do jogo (no caso, o  texto do contdor de cristais)

public class ContadorCristais : MonoBehaviour {

    public int CristaisColetados; //Guarda quantos cristais foram coletados até o momento

    public Text TextoCristaisColetados;

	// Use this for initialization
	void Start () {
        CristaisColetados = 0; //O Jogador começa com 0 cristais
	}
	
	// Update is called once per frame
	void Update () {

        //A função ToString tranforma um tipo de dado em string
        TextoCristaisColetados.text = CristaisColetados.ToString(); //Faz com que o texto mostre o número de cristais que foram coletados	
	}

    //Função que deve ser executada sempre que o Jogador coletar um cristal
    public void ColetouCristal()
    {
        CristaisColetados++; //incrementa o contador
    }
}
