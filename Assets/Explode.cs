using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    public ParticleSystem _particleSystem;

    private void OnDestroy()
    {
        ParticleSystem generatedparticleSystem  = Instantiate(_particleSystem, transform.position, transform.rotation);
        Destroy(generatedparticleSystem.gameObject, generatedparticleSystem.duration);
    }
}
