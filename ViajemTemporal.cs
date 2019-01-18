using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViajemTemporal : MonoBehaviour {
    //Instruções para o uso desse Script:
    //Nas cenas em que poderão ocorrer viagem temporal (praticamente todas), devemos ter dois emptyGameObjects: um para o passado e outro para o presente
    //O gameObject "passado" será pai de todos gameObjects que existirão apenas no passado, enquanto "presente" será pai de todos que existirem apenas no presente
    //Os objetos que existirem em ambos não serão filho de nenhum deles
    //Quando o Jogador viajar para o passado, desativaremos o gameObject "presente" (e, consequentemente, todos seus filhos) e ativaremos o gameObject "passado"

    //OBS: Por que não fazer duas cenas separadas para o passado e para o presente, que nem fizemos na Hackathon?
    //Esse tipo aprroach complica as coisas bem mais do que seria necessário, pois a passagem de cenas não destrói apenas os objetos de uma cena para outra
    //mas também o elo entre ele. Assim, mesmo que consigamos impedir que certos objetos sejam destruídos, torná-los ligados aos scripts um dos outros é praticamente
    //inviável.

    //OBS': EU PASSEI MAIS DE 3 DIAS TENTANDO FAZER COM CENAS DIFERENTES
    //NÃO
    //VALE
    //A
    //PENA
    //Ass: Ypê

    public GameObject Passado;

    public GameObject Presente;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("t"))
        {
            ViajemProPassado();
        }

        //OBS: Tive que usar duas teclas diferentes senão entrava nos dois ifs ao mesmo tempo
        //Possivelmente esse problema será resolvido quando tivermos Inputs com touchscreen
        if (Input.GetKeyDown("y"))
        {
            ViajemProPresente();
        }
	}

    public void ViajemProPassado()
    {
        Presente.SetActive(false);

        Passado.SetActive(true);
    }

    public void ViajemProPresente()
    {
        Presente.SetActive(true);

        Passado.SetActive(false);
    }
}
