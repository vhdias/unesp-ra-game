﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : DefaultVirtualButtonController
{
    public Rigidbody bullet;
    public GameObject ray;
    private GameObject[] weapons = new GameObject[2];
    public float speed, multiplierspeed, timeToDestroy;
    public enum Weapons
    {
        Ray = 0,
        Grenade = 1
    }
    public Weapons weapon = Weapons.Grenade;

    private bool iniatilized = false;
   
    override protected void ButtonPressed()
    {
        //"TrocaArma()" será removido daqui e movido para Update() quando for implementada a troca por rotação. 
        //Por hora só pode ser testado efetuando a troca manualmente no editor da Unity da arma selecionada (variável weapon)
        if (weapon == Weapons.Grenade)
        {
            TrocaArma();//Será removido daqui e movido para Update() quando for implementada a troca por rotação
            Rigidbody shooted = ActionRA.Atira(new Vector3(0, 1, 0), transform.Find("Grenade"), bullet, speed, timeToDestroy);
            shooted.AddRelativeTorque(Random.rotation * new Vector3(1, 1, 1));
        }
        else if (weapon == Weapons.Ray)
        {
            TrocaArma(); //Será removido daqui e movido para Update() quando for implementada a troca por rotação
            //Busca objeto que centralizara a saida dos raios na ponta da arma
            Transform centralize = transform.Find("Ray");
            //Cria a esfera de raios
            GameObject shooted = Instantiate(ray, centralize.position, centralize.rotation);
            //Obtem o rigidbody que representa o ponto de atração das particulas
            Rigidbody target = shooted.GetComponent<Rigidbody>();
            //Movimenta o ponto de atração
            target.AddRelativeForce(new Vector3(0, -1, 0) * speed * multiplierspeed);
            ParticleSystem particleSystem = shooted.GetComponent<ParticleSystem>();
            Destroy(shooted, particleSystem.main.duration);
        }
    }

    /// <summary>
    /// Troca a arma ativa de forma que permaneça a troca mesmo após perder o rastreamento do ImageTarget
    /// </summary>
    void TrocaArma()
    {
        if (iniatilized == false)
        {
            //Debug.Log("Grenade: " + (int)Weapons.Grenade + "\n Ray: " + (int)Weapons.Ray + "\n Weapons" + weapons.Length);
            weapons[(int)Weapons.Grenade] = transform.Find("Grenade Launcher").gameObject;
            weapons[(int)Weapons.Ray] = transform.Find("Ray Launcher").gameObject;
            iniatilized = true;
        }
        var _weapon = weapons[(int)Weapons.Grenade];
        var _weaponIsSelected = weapon == Weapons.Grenade;
        _weapon.SetActive(_weaponIsSelected);
        _weapon.tag = _weaponIsSelected ? "Untagged" : "ActiveByButton";
        _weapon = weapons[(int)Weapons.Ray];
        _weaponIsSelected = weapon == Weapons.Ray;
        _weapon.SetActive(_weaponIsSelected);
        _weapon.tag = _weaponIsSelected ? "Untagged" : "ActiveByButton";
    }

    private void Update()
    {

    }
}
