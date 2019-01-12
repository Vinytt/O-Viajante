using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarAlavanca : MonoBehaviour {

    bool Ativada; //Guarda o estado da alavanca

    public GameObject AreaRadiacao;

    bool ColidindoComJogador; //Verifica se o Jogador está colidindo com o BoxCollider da Alavanca

    public Animator AnimadorAlavanca;

	// Use this for initialization
	void Start () {
        Ativada = false; //A alavanca começa sempre desativada
        ColidindoComJogador = false; //A alavanca nunca começará colidindo com o Jogador
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && ColidindoComJogador)
        {
            if (Ativada)
            {
                Desativar();
            }
            else
            {
                Ativar();
            }
        }
    }

    //Quando o Jogador COMEÇAR a encostar com o BoxCollider da Alavanca, essa função é executada (apenas uma vez)
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            ColidindoComJogador = true;
        }
    }

    //Quando o Jogador PARAR de encostar no BoxCollider da Alavanca, essa função é executada (apenas uma vez)
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            ColidindoComJogador = false;
        }
    }

    //Função para ativar alavanca
    public void Ativar()
    {
        Ativada = true;

        AreaRadiacao.SetActive(false); //Neutraliza a área de radiação

        AnimadorAlavanca.SetBool("Ativada", true); //Muda a animação da alavanca
    }

    //Função para desativar a alavanca
    public void Desativar()
    {
        Ativada = false;

        AreaRadiacao.SetActive(true); //Área de Radiação para de ser neutralizada

        AnimadorAlavanca.SetBool("Ativada", false); //Muda a aniação da alavanca
    }
}
