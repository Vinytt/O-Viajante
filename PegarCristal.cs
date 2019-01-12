
using UnityEngine;

public class PegarCristal : MonoBehaviour {

    public GameObject Cristal;

    public Animator AnimadorCristal;

    public AnimationClip ClipeColetaCristal;

    public GameObject TextoContadorCristais;

    public GameObject GerenciadorAudio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //A função OnTriggerEnter é executada quando um BoxCollider entra dentro da área de outro
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jogador")) //Verifica se um gameObject com a tag "Jogador" entrou dentro do BoxCollider
        {
            AnimadorCristal.Play("AnimaçãoColetaCristal"); //Acessa o animador e executa a animação de Coleta do Cristal

            GerenciadorAudio.GetComponent<Audio>().TocarSom("PegandoCristal"); //Toca o clipe de som para pegar o cristal

            //A função destrói serve para deletar gameObjects e recebe 2 parâmetros: o objeto a ser destruído e quanto tempo deve-se esperar para destruí-lo
            Destroy(Cristal, ClipeColetaCristal.length); //Destrói o cristal logo após o término do clipe de coleta 

            TextoContadorCristais.GetComponent<ContadorCristais>().ColetouCristal(); //Chama a função ColetouCristal do Script ContadorCristais,
                                                                                     //vinculado ao gameObject TextoContadorCristais
        }
    }
}
