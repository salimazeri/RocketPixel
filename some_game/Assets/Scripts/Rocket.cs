using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public float speed;
    private float screenWidth;
    public int score;
    public int health;
    public int flash;
    Touch touch;
    public Text scoreText, healthText;
    private GameObject hearths;
    public int child;
    int lastChanged1, lastChanged2;
    SpriteRenderer renderer;
    Collider2D rocketCollider;
    bool isDeath;
    private void Start()
    {
        isDeath = false;
        hearths = GameObject.Find("health");
        child = 0;
        rocketCollider = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
        health = 3;
        scoreText = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();
        healthText = GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Text>();
        healthText.text = "Health: " + health.ToString();
        scoreText.text = score.ToString();
        score = 0;
        screenWidth = Screen.width;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(Input.touches.Length - 1);
            if (touch.position.x > screenWidth / 2 && this.transform.position.x <= 11)
            {
                transform.rotation = Quaternion.EulerRotation(new Vector3(0, 0, -0.3f));
                transform.position += new Vector3(1.0f * speed * Time.deltaTime, 0, 0);
            }
            else if (touch.position.x < screenWidth / 2 && this.transform.position.x >= 1)
            {
                transform.rotation = Quaternion.EulerRotation(new Vector3(0, 0, 0.3f));
                transform.position += new Vector3(-1.0f * speed * Time.deltaTime, 0, 0);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                transform.rotation = Quaternion.EulerRotation (new Vector3(0, 0, 0));
            }
        }
        if (health == 0)
        {   
            if (!isDeath)
            {
                rocketCollider.enabled = false;
                StartCoroutine(gameOver());
                isDeath = !isDeath;
            }
        }
    }
    IEnumerator gameOver()
    {
        bool x = false;
        for (int i = 0; i < 12; i++)
        {
            x = !x;
            hearths.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = x;
            hearths.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = x;
            hearths.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = x;
            yield return new WaitForSeconds(0.2f);
        }
        SceneManager.LoadScene("gameoverScene");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            StartCoroutine(SaveTime(flash));
            //explosion animation here
            Destroy(collision.gameObject);
            if (health > 0 & health <= 3)
            {
                health--;
                hearths.transform.GetChild(child).GetComponent<SpriteRenderer>().enabled = false;
                child++;
                healthText.text = "Health: " + health.ToString();
            }
        }
        if(collision.gameObject.tag == "healthBoost")
        {
            Destroy(collision.gameObject);
            if (health >= 0 & health < 3)
            {
                health++;
                child--;
                hearths.transform.GetChild(child).GetComponent<SpriteRenderer>().enabled = true;
                healthText.text = "Health: " + health.ToString();
            }

        }
    }

    IEnumerator SaveTime(int time)
    {
        rocketCollider.enabled = false;
        for (int i = 0; i < flash*2; i++)
        {   //czas 12 * 0.1s = 1.2s
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        rocketCollider.enabled = true;
    }

}