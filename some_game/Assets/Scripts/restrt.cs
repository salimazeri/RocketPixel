﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class restrt : MonoBehaviour
{

    Vector3 touchPosWorld;

    TouchPhase touchPhase = TouchPhase.Ended;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        {
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
            if (hitInformation.collider.tag == "restart")
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}