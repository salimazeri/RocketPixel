using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateRockets : MonoBehaviour
{
    bool order;
    private GameObject rocket, rocketPrefab;
    Vector3 positionHorizontal, positionVertical;
    private float[] generateRangeH, generateRangeV;
    private Vector3[] vectorListHorizontal, vectorListVertical;
    int force;
    // Start is called before the first frame update
    void Start()
    {
        order = true;
        int force = 2000;
        rocket = GameObject.Find("rocketPrefab");
        InvokeRepeating("startc", 0, 2);

    }

    void startc()
    {
        StartCoroutine(spawnRocketHorizontal(order));
        order = !order;
    }
    // Update is called once per frame
    IEnumerator spawnRocketHorizontal(bool order)
    {
        int range = Random.Range(-14, -16);
        for (int i = 0; i < 4; i++)
        {   
            if (order)
            {
                range = range + 1;
            }
            else
            {
                range = range - 1;

            }
            positionHorizontal = new Vector3(range, -11.5f, rocket.transform.position.z);
            rocketPrefab = Instantiate(rocket, positionHorizontal, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            yield return new WaitForSeconds(0.2f);
        }
    }

    
}
