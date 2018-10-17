using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PShoot : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject bullet;

    //Cooldown Timers, en som är public för att sätta vald tid och en privat som håller koll på tiden.
    [Header("Stats")]
    private float pCdTimer;
    [Range(0, 1)]
    public float cdTimer;
    public float spawnDistance;

    private void Start()
    {
        pCdTimer = cdTimer;
    }

    // Update is called once per frame
    private void Update()
    {


        if (pCdTimer <= 0)
        {
            //Kollar ifall du trycker ner fire och ifall den hittar en bullet prefab, ifall inte så skriver den ut det i debug listan.
            if (Input.GetButton("Fire1"))
            {
                if (bullet == null)
                    Debug.Log("No Bullet Prefab Found!");
                else if (bullet != null)
                {
                    //Kallar på shoot funktionen.
                    Shoot();
                    //Sätter privata timern tillbaka till valda cooldown Timern.
                    pCdTimer = cdTimer;
                }
            }
        }
        else if (pCdTimer > 0)
            pCdTimer -= Time.deltaTime;
    }

    public void Shoot()
    {
        //Spawnar in prefaben "Bullet" som anges i Unity editorn.
        Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + spawnDistance), Quaternion.identity);
    }
}
