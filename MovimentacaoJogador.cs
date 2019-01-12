using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour {

    public GameObject Jogador; 

    public float Velocidade = 20f; //Velocidade de Movimentação

    public Vector2 Pulo; //Força do Pulo

    bool NoAr; //Retorna true quando o Jogador estiver no ar

    bool Agachado; //Retorna true quando o Jogador estuver agachando

    bool obstaculoFrente; //Retorna true quando houver um objeto na frente
    bool obstaculoAtras; //Retorna true quando houver um objeto atrás

    public Animator Animador; //Animador do JOGADOR, no caso

    private Vector3 PosicaoJogador; //Guarda a posição do Jogador a cada frame, importante para a animação!

    private bool OlhandoEsquerda; //Retorna true quando o jogador estiver olhando para a Esquerda s2

    private Vector3 Direcao; //Guarda a transform.localScale do Jogador, importante para virá-lo quando mudar de direção

    private Vector2 CaixaColisao; //Guarda o tamanho da caixa de colisão do Jogador antes de ele agachar
    private Vector2 PosCaixaColisao; //Guarda a posição da caixa de colisão em relação ao Jogador antes de ele abaixar

    public GameObject GerenciadorAudio;

    public GameObject GerenciadorJogo;

	// Use this for initialization
	void Start () {
        OlhandoEsquerda = false;
        CaixaColisao = Jogador.GetComponent<BoxCollider2D>().size; //Guarda o tamanho inicial da caixa dde colisão do Jogador
        PosCaixaColisao = Jogador.GetComponent<BoxCollider2D>().offset; //Guarda o offset inicial da caixa de colisão do Jogador
	}
	
	// Update is called once per frame
	void Update () {

        PosicaoJogador = Jogador.transform.position; //Guarda a posição do Jogador nesse frame

        Direcao = Jogador.transform.localScale;

        //Movimentação Horizontal

        //Para que a movimentação funciona de maneira correta, devemos restringí-la na presença de obstáculos, do contrário o Jogador tentará "atravessar"
        //qualquer parede que se encontre na sua frente enquanto se movimenta
        //Devemos, então, usar o Raycast, função que cria um vetor invisível e retorna true sempre que esse vetor toca um GameObject

        //OBS: para que o Raycast não bata no Collider do Jogdor, devemos colocar o Jogador e os obstáculos em Layers diferentes (criando Layers no menu)
        //Feito isso, usaremos o bit shift Mascara para selecionarmos apenas a camada do Jogador e depois o inverteremos
        int Mascara = 1 << 10 | 1 << 12; //Seleciona as Layers 10 e 12 para colisão
        Mascara = ~Mascara; //INVERSÃO: seleciona todas camadas EXCETO as camadas 10 (do jogador) e 12 (Radiação)

        obstaculoFrente = Physics2D.Raycast(new Vector2 (Jogador.transform.position.x, Jogador.transform.position.y) - new Vector2(0, 1.5f), transform.right, 1f, Mascara);
        obstaculoAtras = Physics2D.Raycast(new Vector2 (Jogador.transform.position.x, Jogador.transform.position.y) - new Vector2(0, 1.5f), -transform.right, 1f, Mascara);
        //OBS: a função Physics.Raycast recebe 4 parâmetros: a origem do vetor, a direção do vetor, o tamanho do vetor e as layers que o vetor pode atingir

        //OBS':Para usos de Debug, podemos visualizar o Raycast através da função DrawLine
        //(Seus parâmetros são a origem da linha, o destino da linha e a cor da linha)
        //Debug.DrawLine(Jogador.transform.position - new Vector3(0, 1.5f, 0), Jogador.transform.position - new Vector3(-1f, 1.5f, 0), Color.white);

        if(Input.GetKey("d") && !obstaculoFrente) //A função GetKey retorna true enquanto a tecla estiver pressionada
            {
                Jogador.transform.position += new Vector3(Velocidade * Time.deltaTime, 0, 0); //a posição do jogador é alterada a cada frame
                if (!NoAr)
                {
                    Animador.SetBool("Correndo", true); //Ativa a animação de correr
                }

            //Caso ele esteja olhando para a Esquerda, é preciso muda a direção (Mudando a Scale.x do jogador)
            //Isso não pode ser feito diretamente, por isso precisamos da variável Direcao
                if (OlhandoEsquerda) 
                {
                    Direcao.x *= -1; //multipla o componente x da direção
                    Jogador.transform.localScale = Direcao; //Muda a direção do jogador
                    OlhandoEsquerda = false;
                }

            }

        if (Input.GetKey("a") && !obstaculoAtras)
            {
                Jogador.transform.position += new Vector3(-Velocidade * Time.deltaTime, 0, 0);
                if (!NoAr)
                {
                Animador.SetBool("Correndo", true);
                }

                if (!OlhandoEsquerda)
                {
                    Direcao.x *= -1;
                    Jogador.transform.localScale = Direcao; //muda direção do jogador
                    OlhandoEsquerda = true;
                }
            }
        

        //Pulo  (Deve ser chamada apenas quando o objeto não estiver no ar!)
        if(Input.GetKeyDown("w") && !NoAr) //A função GetKeyDown retorna true apenas o frame em que a tecla foi pressionada!
            {
                //Diferentemente da movimetação horizontal, o pulo não pode ser feito alterando a posição do Jogador, pois isso apenas o transportará para cima
                //Assim, temos que dar a ele uma velocidade, que deve ser feita através de seu componente de física, o Rigidbody
                //Isso pode ser feito de dois métodos:

                //Adiconando uma velocidade ao Rigidbody:
                //Jogador.GetComponent<Rigidbody>().velocity = new Vector3(0, Pulo * Time.deltaTime, 0); MUDA A VELOCIDADE DO RIGIDBODY
                //Porém esse método o torna menos realista!

                //Adicionando uma FORÇA ao Rigidbody:
                Jogador.GetComponent<Rigidbody2D>().AddForce(Pulo); //Adiciona uma força de valor "Pulo" na componente Y

                //OBS: A função GetComponent serve para chamar um componente de um GameObject!

                NoAr = true; //o objeto agora estará no ar

                Animador.SetBool("Pulando", true); //Animação de pulo

                GerenciadorAudio.GetComponent<Audio>().TocarSom("Pulo");
            }

        //Agachar
        if(Input.GetKey("s") && !NoAr)
        {
            Agachado = true;

            Animador.SetBool("Agachando", true);

            Jogador.GetComponent<BoxCollider2D>().size = new Vector2(0.1077923f, 0.09696253f); //Muda o tamanho do BoxCollider
            Jogador.GetComponent<BoxCollider2D>().offset = new Vector2(0.004848991f, -0.1025f); //Muda a posição do BoxCollider em relação ao Jogador
        }

        if (Input.GetKeyUp("s")) //A função GetKeyUp retorna true no frame em que a tecla foi solta
        {
            Agachado = false;

            Animador.SetBool("Agachando", false);

            Jogador.GetComponent<BoxCollider2D>().size = CaixaColisao;
            Jogador.GetComponent<BoxCollider2D>().offset = PosCaixaColisao;
        }
    }

    //Aqui verificamos se a posição do Jogador se manteve em relação ao início do frame, caso isso ocorra, quer dizer que ele não está em movimento
    //e, portanto, devemos parar a animação de corrida
    private void LateUpdate()
    {
        if(Jogador.transform.position.x == PosicaoJogador.x)
        {
            Animador.SetBool("Correndo", false);
        }

        //Sempre que o Jogador tiver uma velocidade para baixo, quer dizer que ele está caindo
        if(Jogador.GetComponent<Rigidbody2D>().velocity.y < -2f)
        {
            Animador.SetBool("Caindo", true);
        }
    }

    //Chamando a função OnCollisionEnter (que só é executada quando começa uma colisão), podemos identificar quando o Rigidboody do Jogador está colidindo
    //com um Rigidbody de um GameObject que tenha a tag "Chao"
    //No entando, OnCollisionStay funciona melhor, pois é chamada TODO frame, verificando se o contato entre os corpos existe

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Chao"))
        {
            NoAr = false;
            Animador.SetBool("Caindo", false);
        }
    }

    //Aqui usaremos OnCollisionEnter para cancelar a animação de Pulo sempre que o jogador começar a tocar um objeto com a tag "Chao"
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Chao"))
        {
            Animador.SetBool("Pulando", false); //Para a animação de Pulo
            Animador.SetBool("Caindo", false);
        }
    }

    //Temos também que lembrar de tornar NoAr true quando o corpo PARAR de tocar o chão, do contrário o Jogador será identificado "no ar" apenas depois de pular
    //mas não quando cai de uma plataforma, por exemplo
    //OnCollisionExit é executada sempre que uma colisão para de acontecer
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Chao"))
        {
            NoAr = true;
            Animador.SetBool("Correndo", false);
            if (!Animador.GetBool("Pulando") && !Agachado)
            {
                Animador.SetBool("Caindo", true);
            }
        }
    }
}
