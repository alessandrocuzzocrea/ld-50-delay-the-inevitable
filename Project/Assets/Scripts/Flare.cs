using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : MonoBehaviour
{
    public float[] rndValues;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = newScale.y = newScale.z = rndValues[Random.Range(0, rndValues.Length)];
            transform.localScale = newScale;

            timer = 0.1f;
        }

    }
}
