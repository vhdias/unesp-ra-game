using System.Collections;
using UnityEngine;

public class AtingiuAlvo : MonoBehaviour {
    public float timeToDestroy = 0;
    public Color colorBeforeDestroy = Color.red;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Sphere(Clone)")
        {
            Renderer renderer = col.gameObject.GetComponent<Renderer>();
            renderer.material.SetColor("_Color", colorBeforeDestroy);
            if(timeToDestroy != 0) Destroy(col.gameObject, timeToDestroy);
        }
    }
}
