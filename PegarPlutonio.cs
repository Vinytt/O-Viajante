using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarPlutonio : MonoBehaviour {

    bool PertoPlutonio; //Verifica se o Jogador está perto desse pedaço de plutônio

    public GameObject Plutonio;

    public GameObject Jogador;

	// Use this for initialization
	void Start () {
        PertoPlutonio = false; //O Jogador começa longe do pedaço de plutônio
	}
	
	// Update is called once per frame
	void Update () {
        //O Jogador só poderá pegar o Plutônio caso esteja perto dele e não esteja carregando outro Item de Mão
		if (PertoPlutonio && Input.GetKeyDown("e") && !Jogador.GetComponent<ItensJogador>().CarregandoItemMao)
        {
            Jogador.GetComponent<ItensJogador>().CarregandoItemMao = true;
            Jogador.GetComponent<ItensJogador>().ItemMao = Plutonio; //Torna o Plutônio o Item de Mão do Jogador, Importante para largá-lo depois
            Plutonio.SetActive(false); //Desativa o Plutônio
        }
	}

    //OBS: Por quê não usar OnTriggerStay?
    //OnTriggerStay é executada a todo frame, enquanto o Jogador estiver em contato com o BoxCollider do Plutônio, devido a isso o códico não é executado como esperado

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            PertoPlutonio = true;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Chao"))
        {
            Plutonio.GetComponent<Rigidbody2D>().gravityScale = 0; //Faz com que a gravidade pare de afetar o Plutônio (para ele não cair através do chão)
            Plutonio.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //Zera a velocidade que o Plutônio já adquiriu durante sua queda até o chão
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            PertoPlutonio = false;
        }
    }
}
