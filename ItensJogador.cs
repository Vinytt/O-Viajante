using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensJogador : MonoBehaviour {
    //O Jogador deve ser capaz de ter dois tipos de itens:

    //Itens de Mão:
    //São Itens que não ficam dentro do inventário e têm uso imediato (plutônio para os puzzles, por exemplo)
    //O Jogador pode carregar apenas UM item de Mão por vez

    //Itens de Inventário
    //São os itens que ficam dentro do inventário enquanto o Jogador não decidir descartá-los (armas, upgrades, ferramentas, consumíveis)
    //A quantidade de itens de inventário que o Jogador pode carregar consigo é limitada pelo número de Espaços no Inventário


    public bool CarregandoItemMao; //Verifica se o Jogador está carregando um item de mão no momento

    public GameObject ItemMao;

    public GameObject Jogador;
	// Use this for initialization
	void Start () {
        CarregandoItemMao = false; //O Jogador nunca começa a fase carregando um item de Mão
	}
	
	// Update is called once per frame
	void Update () {

        //Largar Item de Mão
        if(Input.GetKeyDown("e") && CarregandoItemMao)
        {
            CarregandoItemMao = false;

            ItemMao.transform.position = Jogador.transform.position;

            ItemMao.SetActive(true);

            ItemMao.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
		
	}
}
