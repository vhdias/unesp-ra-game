using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    private int actual = 1;
    public int lastLevel = 4;
    private Transform[] alvos;

    Transform Alvos(int i, bool state)
    {
        var filho = transform.GetChild(i);
        filho.gameObject.SetActive(state);
        if (!state) return null;
        var alvo = filho.Find("Eixo");
        if (!alvo) alvo = filho.Find("Alvos");
        else alvo = alvo.Find("Alvos");
        //Debug.Log("Filho[" + i + "]: " + filho.name + ";;" + alvo.name);
        return alvo;
    }

    private void Start()
    {
        alvos = new Transform[2];
        for(int i = 0; i < 2; i++)
        {
            alvos[i] = Alvos(i, true);
        }
    }

    private bool NextLevel()
    {
        if (actual == lastLevel)
        {
            for (int i = 0; i < 2; i++)
            {
                Alvos(actual * 2 - i - 1, false);
            }
            return false; //Acabou os niveis
        }
        for (int i = 0; i < 2; i++)
        {
            Alvos(actual * 2 - i - 1,false);
            alvos[i] = Alvos((actual + 1) * 2 - i - 1,true);
        }
        actual++;
        return true; //Foi para o próximo level
    }

    private void FixedUpdate()
    {
        if (alvos[0].childCount == 0 && alvos[1].childCount == 0)
            if (!NextLevel())
            {
                //Debug.Log("Acabou o jogo!");
            }
    }
}
