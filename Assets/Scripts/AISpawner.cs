using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    [Header("AI Prefabs")]
    public GameObject[] enemies;

    [Header("Position Arrays")]
    public float[] posX;
    public float[] posY;

    [Space]
    private float pSpawnCd;
    public float spawnCd;
    public int curEnemies;
    public int maxEnemies;

	// Use this for initialization
	void Start ()
    {
        pSpawnCd = spawnCd;
	}
	
	// Update is called once per frame
	void Update ()
    {
        pSpawnCd -= Time.deltaTime;


        if (pSpawnCd <= 0)
        {
            Debug.Log("Lol");
            if (curEnemies < maxEnemies)
            {
                Debug.Log("wOWie");
                Instantiate(enemies[Random.Range(0, enemies.Length)],
                    new Vector2(posX[Random.Range(0, posX.Length)],
                    posY[Random.Range(0, posY.Length)]), Quaternion.identity);
                pSpawnCd = spawnCd;
                curEnemies += 1;
            }
        }


	}
}
