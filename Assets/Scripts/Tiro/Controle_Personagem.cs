using UnityEngine;
using System.Collections;


public class Controle_Personagem : MonoBehaviour {

    public float Velocidade_Movimento = 10f;

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float translation = Input.GetAxis("Vertical") * Velocidade_Movimento;
        float straffe = Input.GetAxis("Horizontal") * Velocidade_Movimento;
        translation = translation * Time.deltaTime;
        straffe = straffe * Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
	}
}
