using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketCollider : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.AddForce(transform.up * speed * 10);
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "wall")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "Ground")
        {
            Destroy(this.gameObject);
        }

    }
}
