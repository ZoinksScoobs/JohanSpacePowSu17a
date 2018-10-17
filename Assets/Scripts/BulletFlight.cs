using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kräver att objektet som har detta script har komponenterna BoxCollider2D och Rigidbody2D
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletFlight : MonoBehaviour
{
    [Header("Animations")]
    public Animator bulletAnim;

    //Timer för att förstöra objektet.
    [Header("Stats")]
    [Range(0, 5)]
    public float timer;
    [Range(1, 2500)]
    public float speed;
    [Range(1, 10)]
    public int damage;
    private bool dead;
    public float deathDelay;

    [Header("Components")]
    private Rigidbody2D rb2d;
    public GameObject hit;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dead = false;
    }

	// Update is called once per frame
	void Update ()
    {
        rb2d.velocity = new Vector2(0, speed* Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.SendMessageUpwards("takeDamage", damage);
            Die();
        }
        if (col.gameObject.tag == "Walls")
        {
            if (!dead)
            Instantiate(hit, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Die();
        }
    }

    void Die()
    {
        dead = true;
        speed = 0f;
        bulletAnim.SetTrigger("Die");
        Destroy(gameObject, deathDelay);
    }

}
