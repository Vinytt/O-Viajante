using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //É necessário adicionar esse namespace para mexer com o áudio!
using System; //É necessário adicionar esse namespace para usar a função Array.Find()

public class Audio :
    MonoBehaviour {

    //Para trabalharmos o áudio, não compensa fazermos uma função para cada som. É mais fácil fazer uma função universal que procure cada som e o toque
    //Assim, teremos que

    public Som[] Soms; //Vetor de objetos da classe Som, guardará todos clipes de áudio do jogo

    private void Awake() //A função Awake funciona tal como a Start, mas é chamada antes
    {
        foreach (Som s in Soms) //Para cada objeto na vetor Soms, damos a ele a source e o clip especificados
        {
            s.Fonte = s.ObjetoFonte.AddComponent<AudioSource>(); //Cria uma audio source a partir do Objeto que é a fonte do áudio
            s.Fonte.clip = s.Clipe; //O clipe de som que a Source tocará será a que o objeto Som recebeu pela interface da Unity

            s.Fonte.spatialBlend = s.SpatialBlend; //A source recebe o valor de SpatialBlend colocado através da interface da Unity

            s.Fonte.rolloffMode = AudioRolloffMode.Linear; //Faz com que os sons diminuam caso estejam distantes da fonte (câmera)

            s.Fonte.volume = s.Volume; //A source recebe o valor de volume colocado através da interface da Unity
            s.Fonte.pitch = s.Altura;  //A source recebe o valor de altura colocado através da interace da Unity
            s.Fonte.maxDistance = s.DistanciaMaxima; //A source recebe o valor de distância mínima colocado através da interface da Unity
            s.Fonte.minDistance = s.DistanciaMinima; //A source recebe o valor de distância mínima através da interface da Unity
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Função universal para tocar um clipe de áudio do jogo
    //OBS: Essa função deve ser usada apenas para soms que sempre devem ser ouvidos em seu volume máximo
    public void TocarSom (string Nome) //O parâmetro Nome identifica o nome do Som a ser tocado
    {
        Som s = Array.Find(Soms, som => som.Nome == Nome); //Encontra o objeto dentro do vetor Soms cujo nome é igual ao parâmetro passado
        s.Fonte.Play(); //Toca o clipe desse objeto Som
    }
}
