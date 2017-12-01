using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : DefaultVirtualButtonController
{
    public Rigidbody bullet;
    public GameObject ray;
    public float speed, timeToDestroy;
    public enum Weapons
    {
        Ray,
        Grenade
    }
    public Weapons weapon = Weapons.Grenade;

    override protected void ButtonPressed()
    {
        if (weapon == Weapons.Grenade)
        {
            Rigidbody shooted = ActionRA.Atira(new Vector3(0, 1, 0), transform.Find("Grenade"), bullet, speed, timeToDestroy);
            shooted.AddRelativeTorque(Random.rotation * new Vector3(1, 1, 1));
        }
        else if (weapon == Weapons.Ray)
        {
            //Busca objeto que centralizara a saida dos raios na ponta da arma
            Transform centralize = transform.Find("Ray");
            //Cria o raio
            GameObject shooted = Instantiate(ray, centralize.position, centralize.rotation);
            //Desabilita esfera em volta do ponto de atração
            var particles = shooted.GetComponentsInChildren<ParticleSystem>();
            for(int i = 1; i < particles.Length; i++)
            {
                var emissor = particles[i].emission;
                emissor.SetBursts(null, 0);
            }
            //Obtem o rigidbody que representa o ponto de atração das particulas
            Rigidbody target = shooted.GetComponentInChildren<Rigidbody>();
            //Movimenta o ponto de atração
            target.AddRelativeForce(new Vector3(0, -1, 0) * speed * 30);
            ParticleSystem particleSystem = shooted.GetComponent<ParticleSystem>();
            Destroy(shooted, particleSystem.main.duration);
        }
    }

    private void Update()
    {

    }
}
