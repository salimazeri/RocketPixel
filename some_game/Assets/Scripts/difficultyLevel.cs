using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyLevel : MonoBehaviour
{
    spawner spawner;
    scrollingScript scrollingSpeed1, scrollingSpeed2;
    float asteroidRespTime;
    Text levelText;
    int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        scrollingSpeed1 = GameObject.Find("background").transform.GetChild(0).GetComponent<scrollingScript>();
        scrollingSpeed2 = GameObject.Find("background").transform.GetChild(1).GetComponent<scrollingScript>();
        levelText = GameObject.Find("Canvas").transform.GetChild(2).GetComponent<Text>();
        spawner = GameObject.Find("Spawner").GetComponent<spawner>();
        asteroidRespTime = spawner.respTime;
        StartCoroutine(showLvl());
    }

    // Update is called once per frame

    public void IncreaseDifficulty()
    {
        spawner.speed = spawner.speed + 1;
        spawner.respTime = spawner.respTime - 0.01f;
        scrollingSpeed1.scrollingSpeed = scrollingSpeed1.scrollingSpeed + 0.2f;
        scrollingSpeed2.scrollingSpeed = scrollingSpeed2.scrollingSpeed + 0.2f;
        StartCoroutine(showLvl());
    }

    IEnumerator showLvl()
    {
        spawner.canSpawn = false;
        level++;
        levelText.text = "Level: " + level;
        levelText.enabled = true;
        yield return new WaitForSeconds(4);
        levelText.enabled = false;
        spawner.canSpawn = true;

    }
}
