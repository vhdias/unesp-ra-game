using System.Collections;
using UnityEngine;

public class AtingiuAlvo : MonoBehaviour {
    public float timeToDestroy = 0;
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "EsferaParticulas")
        {
            Destroy(gameObject, timeToDestroy);
            Debug.Log("Colisão com a explosão");
        } else if (col.gameObject.name == "target Sphere")
        {
            Destroy(gameObject, timeToDestroy);
            Debug.Log("Colisão com o raio");
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        var rigid = other.transform.parent.GetComponentInChildren<Rigidbody>();
        //other.transform.rotation = transform.rotation;
        //other.transform.position = transform.position;
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        Debug.Log("Colisão de particulas");
    }
}
