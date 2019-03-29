using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingScript : MonoBehaviour
{
    Vector2 startPos;
    public float scrollingSpeed;
    void Start()
    {
        scrollingSpeed = 10;
        startPos = transform.position;
    }

    private void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollingSpeed, 20);
        transform.position = startPos + Vector2.down * newPos;
    }
}
