using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class VirtualButtonController : MonoBehaviour, IVirtualButtonEventHandler {
    public Rigidbody bullet;
    // Use this for initialization
	void Start () {
        // Gera uma lista dos filhos que são botões virtuais
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < vbs.Length; i++)
        {
            //Registra os botões para que eventos possam ser acionados
            vbs[i].RegisterEventHandler(this);
        }
	}

    void IVirtualButtonEventHandler.OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        Renderer renderer;
        //Desativa "Botão" (GameObject) filho do container do botão virtual
        transform.Find(vb.transform.gameObject.name).Find("Botao").gameObject.SetActive(false);
        switch (vb.VirtualButtonName)
        {
            
            case "Ativa":
                transform.Find("Quad").Find("Cube").gameObject.SetActive(true);
                break;
            case "Troca cor":
                renderer = transform.Find("Quad").Find("Cube").gameObject.GetComponent<Renderer>();
                renderer.material.SetColor("_Color", Color.blue);
                break;
            case "Dispara":
                Rigidbody instance = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
                Vector3 forward = transform.TransformDirection(new Vector3(0,-1,0));
                
                instance.AddForce(forward * 15);
                //Destroy(instance.gameObject, 12.5f);
                break;
        }
    }
    void IVirtualButtonEventHandler.OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "Ativa":
                transform.Find("Quad").Find("Cube").gameObject.SetActive(false);
                break;
            case "Troca cor":
                Renderer renderer = transform.Find("Quad").Find("Cube").gameObject.GetComponent<Renderer>();
                renderer.material.SetColor("_Color", Color.red);
                break;
            case "Dispara":
                //Nothing
                break;
        }//Ativa "Botão" (GameObject) filho do container do botão virtual
        transform.Find(vb.transform.gameObject.name).Find("Botao").gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
