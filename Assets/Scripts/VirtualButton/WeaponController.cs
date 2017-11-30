using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : DefaultVirtualButtonController {
    public Rigidbody bullet;
    public float speed;

    override protected void ButtonPressed()
    {
        ActionRA.Atira(new Vector3(0, -1, 0), transform, bullet, speed).AddRelativeTorque(Random.rotation * new Vector3(1,1,1));
    }
}
