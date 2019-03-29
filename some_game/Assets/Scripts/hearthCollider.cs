using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearthCollider : MonoBehaviour
{
    public Rocket rocket;
    private GameObject rocket2_0;
    private Collider2D healthBoostCollider, asteroidCollider2D;
    ContactPoint2D[] contacts;
    private void Start()
    {
        asteroidCollider2D = GetComponent<Collider2D>();
        contacts = new ContactPoint2D[2];
        rocket2_0 = GameObject.Find("rocket2_0");
        healthBoostCollider = GameObject.Find("healthBoost").GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            Destroy(this.gameObject);
        }

    }
}
