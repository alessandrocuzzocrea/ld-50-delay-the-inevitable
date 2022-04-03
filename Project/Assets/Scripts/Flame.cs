using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float[] rndValues;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Vector3 newScale = transform.localScale;
            newScale.y = rndValues[Random.Range(0, rndValues.Length)];
            transform.localScale = newScale;

            timer = 0.2f;
        }

    }
}
