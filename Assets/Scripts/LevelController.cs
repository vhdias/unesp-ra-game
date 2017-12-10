using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
    private int actual = 1;
    public int lastLevel = 4;
    private Transform[] alvos;
    public Text Information, Points;
    private int points = 0;
    private int[] oldCounts;
    bool alreadyIntroductionDone = false;

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
        StartCoroutine(Introduction());
    }

    IEnumerator Introduction()
    {
        /*
        string texto = "Seja bem vindo" +
                        "Obstrua o botão vermelho para atirar" +
                        "Rotacione a arma em 180º para trocar de arma" +
                        "Boa sorte...";
        var words = texto.Split(' ');
        foreach(string s in words)
        {
            SetText(s);
            yield return new WaitForSecondsRealtime(0.3f);
        }
        */
        SetText("Seja bem vindo");
        yield return new WaitForSecondsRealtime(3);
        SetText("Obstrua o botão vermelho para atirar");
        yield return new WaitForSecondsRealtime(3);
        SetText("Rotacione a arma em 180º para trocar de arma");
        yield return new WaitForSecondsRealtime(3);
        SetText("Boa sorte...");
        yield return new WaitForSecondsRealtime(3);
        SetText("");
        alreadyIntroductionDone = true;
        alvos = new Transform[2];
        oldCounts = new int[2];
        for (int i = 0; i < 2; i++)
        {
            alvos[i] = Alvos(i, true);
            oldCounts[i] = alvos[i].childCount;
        }
    }

    IEnumerator Wining()
    {
        SetText("Parabéns, você venceu!");
        yield return new WaitForSecondsRealtime(3);
        SetText("Adeus.");
        yield return new WaitForSecondsRealtime(3);
        SetText("");
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
            oldCounts[i] = alvos[i].childCount;
        }
        actual++;
        return true; //Foi para o próximo level
    }

    private void FixedUpdate()
    {
        if (alreadyIntroductionDone)
        {
            for (int i = 0; i < 2; i++)
            {
                points += (oldCounts[i] - alvos[i].childCount) * actual;
                SetText(points);
                oldCounts[i] = alvos[i].childCount;
            }
            if (alvos[0].childCount == 0 && alvos[1].childCount == 0)
                if (!NextLevel())
                {
                    SetText("Parabéns, você venceu!");
                }
        }
    }

    private void SetText(int points)
    {
        if(alreadyIntroductionDone) Points.text = "Pontos: " + points;
    }

    private void SetText(string text)
    {
        Points.text = text;
    }
}
