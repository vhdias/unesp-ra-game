using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    public ParticleSystem _particleSystem;

    private void OnDestroy()
    {
        //Instancia o sistema de particulas que simula a explosão
        ParticleSystem generatedparticleSystem  = Instantiate(_particleSystem, transform.position, transform.rotation);
        //Instancia uma esfera para verificar colisões de forma otimizada
        GameObject spheretoCollid = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //Define o raio da esfera como o mesmo do sistema de particula
        float raio = generatedparticleSystem.shape.radius;
        spheretoCollid.transform.localScale = new Vector3(raio, raio, raio);
        spheretoCollid.transform.position = transform.position;
        Rigidbody rig = spheretoCollid.AddComponent<Rigidbody>();
        rig.useGravity = false;
        //Desabilita a renderização da esfera
        Renderer render = spheretoCollid.GetComponent<Renderer>();
        render.enabled = false;
        //Nome definido para verificar no script de colisão dos objetos
        spheretoCollid.name = "EsferaParticulas";
        //Destroi os objetos criados após o fim da animação da explosão
        Destroy(generatedparticleSystem.gameObject, generatedparticleSystem.main.duration);
        Destroy(spheretoCollid, generatedparticleSystem.main.duration);
    }
}
