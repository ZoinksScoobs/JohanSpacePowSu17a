using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        Debug.Log("Enemy hit DeathWall.");
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject.Destroy(col.gameObject);
        Debug.Log("Something that wasn't supposed to hit the wall just did.");
    }



}
