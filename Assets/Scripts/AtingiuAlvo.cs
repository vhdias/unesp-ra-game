﻿using System.Collections;
using UnityEngine;

public class AtingiuAlvo : MonoBehaviour {
    public float timeToDestroy = 0;
    
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "EsferaParticulas")
        {
            Destroy(gameObject, timeToDestroy);
            Debug.Log("Colisão com a explosão");
        }
    }
}
