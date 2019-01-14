using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergizarCaixa : MonoBehaviour {

    public GameObject Jogador;

    public Animator AnimadorCaixa;

    bool PertoDaCaixa; //Verifica se o Jogador está perto o suficiente da caixa para interagir com ela

    public bool Ativada; //Guarda se a caixa contém um Plutônio energizado e está, portanto, ligada

    public GameObject Plutonio; //Recebe o Plutônio que o Jogador guardar na Caixa de Energia

	// Use this for initialization
	void Start () {
        PertoDaCaixa = false; //O Jogador nunca começa perto da caixa
        Ativada = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Ok, vamos com calma pois o código a seguir é meio longo
        //Para que a caixa seja ativada precisamos que 5 condições sejam satisfeitas simultâneamente
        //1: A Caixa não está ativada
        //2: O Jogador esteja perto o suficiente para interagir com a caixa
        //3: O Jogador pressione a tecla "q"
        //4: O Jogador esteja carregando um item cuja a Tag seja "Plutonio"
        //5: O item que o jogador estiver carregando tenha atrelado a ele um Script "EnergiaPlutonio" e que dentro desse script a variável "Enerfizado" retorne true

        //OBS: Por quê simplesmente não adicionar um public gameObject o qual receberia o Plutônio ao invés de chamá-lo atráves do Jogador?
        //Isso não é feito pois ocasionaria na restrição de plutônios, apenas o Plutônio que fosse adicionado ao public gameObject serviria para ativar
        //a caixa. Queremos que o Jogador possa ativar a caixa usando qualquer Plutônio energizado que tenha em mãos
		if(!Ativada && PertoDaCaixa && Input.GetKeyDown("q") && Jogador.GetComponent<ItensJogador>().ItemMao.CompareTag("Plutonio") && Jogador.GetComponent<ItensJogador>().ItemMao.GetComponent<EnergiaPlutonio>().Energizado)
        {

            Debug.Log("Entrou no primeiro if");

            AnimadorCaixa.SetBool("Ligada", true); //Ativa a animação da Caixa Energizada

            Ativada = true;

            Plutonio = Jogador.GetComponent<ItensJogador>().ItemMao; //Guarda o plutônio que estava com o Jogador na variável apropriada

            Jogador.GetComponent<ItensJogador>().ItemMao = null; //Faz o Item na Mão do Jogador ser nada

            Jogador.GetComponent<ItensJogador>().CarregandoItemMao = false; //Jogador não estará mais carregando um Item de Mão
        }

        //Similarmente, precisamos que 4 condições sejam satisfeitas simultaneamente para que a caixa seja desarivada:
        //1: A está ativada
        //2: O Jogador está perto o suficiente da caixa
        //3: O Jogador pressiona a tecla "f" (TIVE QUE USAR TECLAS DIFERENTES SENÃO ENTRAVA NOS DOIS IFs AO MESMO TEMPO)
        //4: O Jogador não está carregando nenhum item de mão
        if(Ativada && PertoDaCaixa && Input.GetKeyDown("f") && !Jogador.GetComponent<ItensJogador>().CarregandoItemMao)
        {
            Debug.Log("Entrou no segundo if");

            AnimadorCaixa.SetBool("Ligada", false); //Ativa a animação da Caixa Sem Energia

            Ativada = false;

            Jogador.GetComponent<ItensJogador>().ItemMao = Plutonio; //O Item na mão do Jogador se torna o Plutônio que estava na caixa

            Plutonio = null; //Agora não tem mais Plutônio dentro da caixa

            Jogador.GetComponent<ItensJogador>().CarregandoItemMao = true; //Jogador volta a estar carregando um item
        }
	}

    //A função OnTriggerEnter é chamada apenas uma vez, quando o objeto começa a colidir com outro
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            PertoDaCaixa = true;
        }
    }

    //A função OnTriggerExit é chamda apenas uma vez, quando o objeto para de colidir com outro
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jogador"))
        {
            PertoDaCaixa = false;
        }
    }
}
