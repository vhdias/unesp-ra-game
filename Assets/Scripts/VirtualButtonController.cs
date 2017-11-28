using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class VirtualButtonController : MonoBehaviour, IVirtualButtonEventHandler {
    private GameObject Cubo;
    // Use this for initialization
	void Start () {
        // Gera uma lista dos filhos que são botões virtuais
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < vbs.Length; i++)
        {
            //Registra os botões para que eventos possam ser acionados
            vbs[i].RegisterEventHandler(this);
        }

        Cubo = transform.Find("Quad").Find("Cube").gameObject;
	}

    void IVirtualButtonEventHandler.OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "Ativa":
                Cubo.SetActive(true);
                break;
            case "Troca cor":
                Renderer renderer = Cubo.GetComponent<Renderer>();
                renderer.material.SetColor("_Color", Color.blue);
                break;
        }
    }
    void IVirtualButtonEventHandler.OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "Ativa":
                Cubo.SetActive(false);
                break;
            case "Troca cor":
                Renderer renderer = Cubo.GetComponent<Renderer>();
                renderer.material.SetColor("_Color", Color.red);
                break;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
