using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public Vector3 rotation;
    public float velocidade = 1;

    private void FixedUpdate()
    {
        transform.Rotate(rotation * velocidade);
    }
}
