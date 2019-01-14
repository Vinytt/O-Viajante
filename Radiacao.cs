using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiacao : MonoBehaviour {

    public GameObject GerenciadorJogo;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
    
    //A função OnTriggerEnter é executada quando os BoxCollider de dois corpos começam a se tocar
    //Função para quando o Jogador adentrar a área de Radiação
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            GerenciadorJogo.GetComponent<Vida>().Continuar = true; //O bool Continuar recebe true, para que o Dano seja contínuo
            GerenciadorJogo.GetComponent<Vida>().StartCoroutine(GerenciadorJogo.GetComponent<Vida>().TomarDanoContinuo(10, 1f)); //Ativa o dano contínuo
        }
    }

    //A função OnTriggerExit é executada quando o BoxCollider de um corpo para de encostar no de outro
    //Função para quando o Jogador deixar a área de Radiação
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            GerenciadorJogo.GetComponent<Vida>().Continuar = false; //Ao receber false, o bool Continuar parará o dano contínuo
        }
    }
}
