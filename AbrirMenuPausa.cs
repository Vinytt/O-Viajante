using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirMenuPausa : MonoBehaviour {

    bool Pausado; //Retorna true se o jogo estiver pausado

    public GameObject Menu;

    public GameObject GerenciadorAudio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausado)
            {
                Despausar();
            }
            else
            {
                Pausar();
            }
        }
		
	}

    void Despausar()
    {
        Menu.SetActive(false); //Desativa o Menu
        Time.timeScale = 1f;   //Faz o tempo voltar ao normal
        Pausado = false;
    }

    void Pausar()
    {
        GerenciadorAudio.GetComponent<Audio>().TocarSom("AbrirMenuPausa"); //Toca o som de abertura do menu de pausa

        Menu.SetActive(true); //Ativa o Menu
        Time.timeScale = 0f;  //Congela o tempo
        Pausado = true;
    }

    //Função Para sair do jogo
    public void Sair()
    {
        Application.Quit();
    }
}
