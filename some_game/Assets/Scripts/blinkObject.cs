using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkObject : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(blink());
    }

    IEnumerator blink()
    {
        while (true)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.3f);
        }
    }

}
