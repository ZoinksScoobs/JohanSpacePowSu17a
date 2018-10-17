using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Collider2D))]
public class AI : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [Header("Components")]
    public Animator aiAnim;
    public AudioSource audioData;
    public GameObject aiSpawnerObj;
    public AISpawner aiSpawner;
 

    [Header("Stats")]
    [Range(0, 1000)]
    public float speed;
    [Range(1, 100)]
    public int health;
    public float deathDelay;
    public bool dead;


	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        aiAnim = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
        aiSpawnerObj = GameObject.FindGameObjectWithTag("EnemySpawner");
        aiSpawner = aiSpawnerObj.GetComponent<AISpawner>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb2d.velocity = new Vector2(0f, -speed * Time.deltaTime);

        if (health <= 0 && !dead)
        {
            health = 0;
            Die();
            
        }
	}

    public void Die ()
    {
        dead = true;
        speed = 0f;
        aiSpawner.curEnemies -= 1;
        audioData.Play(0);
        aiAnim.SetTrigger("Die");
        Destroy(gameObject, deathDelay);
    }

    public void takeDamage (int dmg)
    {
        health -= dmg;
    }
}
