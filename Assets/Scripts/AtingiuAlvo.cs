using System.Collections;
using UnityEngine;

public class AtingiuAlvo : MonoBehaviour {
    public float timeToDestroy = 1 , scale = 1.5f;
    public Transform tracker;

    private void Update()
    {
        var VectorDistance = (transform.position - tracker.position);
        var Distance = Mathf.Pow(VectorDistance.x, 2) + Mathf.Pow(VectorDistance.y, 2) + Mathf.Pow(VectorDistance.z, 2);
        if (Mathf.Sqrt(Distance) > 30) Destroy(gameObject);
    }

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
            //Destroy(gameObject, timeToDestroy * scale * 3);
            Destroy(gameObject);
        }
    }

    void ActivateRigidbodyGravity()
    {
        var rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = false;
        rigid.useGravity = true;
    }
}
