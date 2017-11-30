using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : DefaultVirtualButtonController {
    public Rigidbody bullet;

    override protected void ButtonPressed()
    {
        ActionRA.Atira(new Vector3(0, -1, 0), transform, bullet, 10);
    }
}
