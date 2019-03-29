using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidCollider : MonoBehaviour
{
    private Rocket rocket;
    private difficultyLevel lvl;
    private Collider2D healthBoostCollider, asteroidCollider2D;
    ContactPoint2D[] contacts;
    private void Start()
    {
        lvl = GameObject.Find("DifficultyLevel").GetComponent<difficultyLevel>();
        rocket = GameObject.Find("rocket2_0").GetComponent<Rocket>();
        asteroidCollider2D = GetComponent<Collider2D>();
        contacts = new ContactPoint2D[2];
        healthBoostCollider = GameObject.Find("healthBoost").GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.name == "Ground")
        {
            Destroy(this.gameObject);
            rocket.score += 1;
            if (rocket.score % 100 == 0)
            {
                lvl.IncreaseDifficulty();
            }
            rocket.scoreText.text = rocket.score.ToString();

        }

        if (collision.gameObject.tag == "healthBoost")
        {
            Physics2D.IgnoreCollision(healthBoostCollider, asteroidCollider2D);
        }

    }
}
    