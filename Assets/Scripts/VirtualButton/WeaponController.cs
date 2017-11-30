using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : DefaultVirtualButtonController {
    public Rigidbody bullet;
    public float speed, timeToDestroy;

    override protected void ButtonPressed()
    {    
        Rigidbody shooted = ActionRA.Atira(new Vector3(0, 1, 0), transform.Find("Grenade"), bullet, speed,timeToDestroy);
        shooted.AddRelativeTorque(Random.rotation * new Vector3(1, 1, 1));
    }
}
