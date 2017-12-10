using System.Collections;
using UnityEngine;

public class AtingiuAlvo : MonoBehaviour {
    public float timeToDestroy = 1 , scale = 1.5f;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "EsferaParticulas")
        {
            ActivateRigidbodyGravity();
            Destroy(gameObject, timeToDestroy * scale);
            //Debug.Log("Colisão com a explosão");
        }
        else if(col.gameObject.name == "Lightning(Clone)")
        {
            ActivateRigidbodyGravity();
            Destroy(gameObject, timeToDestroy);
            //Debug.Log("Colisão com a esfera de raio");
        }
        else if(col.gameObject.name.Contains("Lata")){
            ActivateRigidbodyGravity();
            //Debug.Log("Colisão entre latas");
        } else if(col.gameObject.name == "Chao")
        {
            ActivateRigidbodyGravity();
            Destroy(gameObject, timeToDestroy * scale * 3);
        }
    }

    void ActivateRigidbodyGravity()
    {
        var rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = false;
        rigid.useGravity = true;
    }
}
