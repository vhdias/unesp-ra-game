using System.Collections;
using UnityEngine;

public class Atingiu_Alvo : MonoBehaviour {

    public static int pontos = 0;

	// Use this for initialization
	void Start () {
        pontos = 0;
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Bola(Clone)")
        {
            pontos = pontos + 1;

            Destroy (this.gameObject, 0.03f);
            Destroy(col.gameObject, 0.05f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
