using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilha : MonoBehaviour {

    public GameObject Jogador;

    public GameObject GerenciadorJogo;

    public float Dano; //Dano que a armadilha causará

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            Jogador.GetComponent<Rigidbody2D>().AddForce(Jogador.GetComponent<MovimentacaoJogador>().Pulo); //Dá um knockback pra cima
            //OBS:concertar o bug que faz o jogador ganhar um impulso ao encostar na armadilha quando já estiver pulando
            //O bug acontece pois a força aplicada pelo knockback da armadilha se soma à força aplicada pelo pulo

            GerenciadorJogo.GetComponent<Vida>().TomarDano(Dano); //Chama a função de dano, pertencente ao script Vida, atrelado ao objeto GerenciadorJogo
        }
    }
}
