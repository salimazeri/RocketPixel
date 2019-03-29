using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject a1, a2, a3, a4, asteroidPrefab, healthBoostPrefab, healthBoost;
    public float firstRespTime;
    public float respTime;
    private GameObject[] asteroids;
    public int speed;
    private Vector3 position;
    public bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        asteroids = new GameObject[7];
        healthBoost = GameObject.Find("healthBoost");
        asteroids[0] = GameObject.Find("asteroids_0");
        asteroids[1] = GameObject.Find("asteroids_0");
        asteroids[2] = GameObject.Find("asteroids_1");
        asteroids[3] = GameObject.Find("asteroids_2");
        asteroids[4] = GameObject.Find("asteroids_2");
        asteroids[5] = GameObject.Find("asteroids_3");
        asteroids[6] = GameObject.Find("asteroids_3");
        InvokeRepeating("SpawnAsteroid", firstRespTime, respTime);
        InvokeRepeating("SpawnHealthBoost", 5, 5);

    }

    // Update is called once per frame
    void SpawnAsteroid()
    {   
        if (canSpawn)
        {
            position = new Vector3(Random.Range(0.0f, 12.0f), Random.Range(12, 15), transform.position.y);
            asteroidPrefab = Instantiate(asteroids[Random.Range(0, 7)], position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0, 360)));
            asteroidPrefab.GetComponent<Rigidbody2D>().AddForce(Vector3.down * speed * Time.time);
        }
        
    }

    void SpawnHealthBoost()
    {   
        if (canSpawn)
        {
            position = new Vector3(Random.Range(1.0f, 11.0f), Random.Range(12, 15), transform.position.y);
            healthBoostPrefab = Instantiate(healthBoost, position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0, 360)));
            healthBoostPrefab.GetComponent<Rigidbody2D>().AddForce(Vector3.down * speed * Time.time);
            healthBoostPrefab.GetComponent<Rigidbody2D>().AddTorque(1f);
        }
        
    }
}
