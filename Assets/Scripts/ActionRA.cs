using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionRA : MonoBehaviour
{
    public static void Atira(Vector3 direction, Transform transform, Rigidbody bullet, float speed, float time = 0)
    {
        Rigidbody instance = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        Vector3 forward = transform.TransformDirection(direction);
        instance.AddForce(forward * speed);

        if (time != 0) Destroy(instance.gameObject, time);
    }

    public static void ResetaCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
