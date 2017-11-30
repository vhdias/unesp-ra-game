using UnityEngine;
using UnityEngine.SceneManagement;


public class Atirar : MonoBehaviour {

	public Rigidbody bullet;

    public void Atira(Vector3 direction, Transform transform, float speed, float time)
    {
        Rigidbody instance = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        Vector3 forward = transform.TransformDirection(direction);
        instance.AddForce(forward * speed);

        if(time != 0) Destroy(instance.gameObject, time);
    }
}
