using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPorta : MonoBehaviour {

    public GameObject Porta;

    public Animator AnimadorPorta;

    public GameObject[] CaixasEnergia; //Talvez queiramos que uma porta só consiga abrir quando mais de uma Caixa de Energia estiiver ativada, então teremos para
                                       //isso um vetor de gameObjects que receberá todas as caixas

    bool TemCaixaVazia; //Verifica se alguma das Caixas de Energia está vazia

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        TemCaixaVazia = false; //Começa supondo que todas caixas estão ativadas

        //checa cada um dos elementos do vetor de gameObjects
        for (int i = 0; i < CaixasEnergia.Length; i++)
        {
            if (!CaixasEnergia[i].GetComponent<EnergizarCaixa>().Ativada)
            {
                TemCaixaVazia = true; //Caso alguma das caixas estiver vazia/desativada, o booleano recebe true
            }
        }

        //Caso haja alguma caixa vazia, a porta estará fechada e terá seu BoxCollider ativado, bloqueando a passagem do Jogador
        if (TemCaixaVazia)
        {
            AnimadorPorta.SetBool("Aberta", false);

            Porta.GetComponent<BoxCollider2D>().enabled = true;
        }

        //Caso não haja caixas vazias, a porta estará aberta e terá seu BoxCollider desativado, permitindo a passagem do Jogador
        if (!TemCaixaVazia)
        {
            AnimadorPorta.SetBool("Aberta", true);

            Porta.GetComponent<BoxCollider2D>().enabled = false;
        }
	}
}
