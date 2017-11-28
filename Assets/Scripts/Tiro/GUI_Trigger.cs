using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Trigger : MonoBehaviour {

    public static int score;

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = "BEM VINDO. \nATINJA TODOS OS BLOCOS";
	}
	
	// Update is called once per frame
	void Update () {
       /* score = Atigiu_Alvo.pontos;

        if(score == 9)
        {
            this.GetComponent<Text>().text = "PARABENS, VOCE ATINGIU TODOS OS CUBOS!";
        }
        else
            if (score != 0 && score <= 9)
                this.GetComponent<Text>().text = "BLOCOS ATINGIDOS = " + score;*/
    }
}
