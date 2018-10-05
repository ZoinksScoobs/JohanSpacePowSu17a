using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PMovement : MonoBehaviour
{

    private Rigidbody2D rb2d;

    [Header("Speed")]
    public float moveSpeed;


	// Use this for initialization.
	void Start ()
    {
        //Hämtar rigidbody komponenten.
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame.
	void Update ()
    {
        //Skapar två float variabler som sedan rör på rigidbodyn på båda horizontalt och vertikalt.
        float h = (Input.GetAxis("Horizontal") * moveSpeed) * Time.deltaTime;
        float v = (Input.GetAxis("Vertical") * moveSpeed) * Time.deltaTime;

        rb2d.velocity = new Vector2(h, v);
    }
}
