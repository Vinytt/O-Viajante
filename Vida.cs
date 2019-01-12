using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour {

    public GameObject TelaMorte;

    public GameObject Jogador;

    [Range(0, 100f)]
    float Saude = 100; //Guarda a saúde atual do Jogador

    float SaudeTotal = 100; //Guarda a saúde total do Jogador

    public GameObject BarraSaudeRestante;

    public GameObject GerenciadorAudio;

    Vector3 EscalaSaude; //Variável para guardar o Scale da Barra de Saúde Restante

    float EscalaXOriginal; //Variável que guarda o primeiro valor do Scale.x da barra de Saúde (ou seja, seu comprimento original)

    public bool Continuar; //Variável que diz se o dano contínuo deve continuar ou não

    bool Morto; //Variável que diz se o jogador está morto

	// Use this for initialization
	void Start () {
        EscalaSaude = BarraSaudeRestante.transform.localScale; //Guarda o tamanho inicial da Barra de Saúde Restante do Jogador
        EscalaXOriginal = EscalaSaude.x;

        Morto = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Saude < 0.00001)
        {
            Morrer();
        }

        if(Jogador.transform.position.y < -50f) //Tomar dano fatal quando o Jogador cair
        {
            TomarDano(Saude);
        }
    }

    public void Morrer()
    {
        Time.timeScale = 0; //Desativa o tempo
        TelaMorte.SetActive(true);
        Morto = true;
    }

    public void TomarDano(float dano)
    {
        if (!Morto) //Nao queremos que o Jogador continue tomando dano depois de Morto
        {
            GerenciadorAudio.GetComponent<Audio>().TocarSom("TomarDano"); //Toca o áudio de dano

            Saude -= dano; //Reduz a Saúde Restante

            float porcentagemVida = Saude / SaudeTotal; //Calcula a porcentagem de vida restante

            EscalaSaude.x = EscalaXOriginal * porcentagemVida; //o transform.localScale da Barra de saúde não pode ser mudado diretamente, por isso precisamos de uma variável

            BarraSaudeRestante.transform.localScale = EscalaSaude; //Muda o tamanho da Barra de Saúde Restante
        }
    }

    //Essa função precisa ser do tipo IEnumerator para permitir o uso do yield return new Wait
    public IEnumerator TomarDanoContinuo (int dano, float tempo)
    {
        //OBS: continuar é public e deve ser mudado para true ou false a partir de outros scripts!
        while (Continuar)
        {
            TomarDano(dano); //Chama a função de causar dano

            yield return new WaitForSecondsRealtime(tempo); //Pausa a execução desse script por (tempo) segundos
        }
    }
}
