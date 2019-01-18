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

    public GameObject Passado;

    public GameObject Presente;

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {

        //Largar Item de Mão
        if(Input.GetKeyDown("x") && CarregandoItemMao)
        {
            CarregandoItemMao = false;

            ItemMao.transform.position = Jogador.transform.position; //Faz o Item de Mão aparecer perto do Jogador

            ItemMao.SetActive(true); //Ativa o Item de Mão

            //Como Item de Mão, queremos que caso ele seja deixado no passado, volte a aparecer no presente, e não fique apenas no passado!
            if (Passado.activeSelf)
            {
                ItemMao.transform.SetParent(null); //Assim, o faremos filho de ninguém
            }

            //Mas caso seja deixado no presente, não pode aparecer no passado!
            else if (Presente.activeSelf)
            {
                ItemMao.transform.SetParent(Presente.transform); 
            }

            ItemMao.GetComponent<Rigidbody2D>().gravityScale = 1.0f; //Faz o Item voltar a ser afetado pela gravidade, pelo menos até que encoste denovo no chão

            ItemMao = null;
        }
		
	}
}
