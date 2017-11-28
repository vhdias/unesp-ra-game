using System.Collections;
using UnityEngine;

public class Atingiu_Alvo : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Sphere(Clone)")
        {
            Renderer renderer = col.gameObject.GetComponent<Renderer>();
            renderer.material.SetColor("_Color", Color.red);
            //Destroy(col.gameObject, 0.01f);
            Debug.Log("BATEU!!!!!");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
