using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public float timeoutDuration = 2;
    public float timeout;
    public GameObject blow;

    // Start is called before the first frame update
    void Start()
    {
        timeout = timeoutDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeout > 0)
        {
            // Reduces the timeout by the time passed since the last frame
            timeout -= Time.deltaTime;

            // return to not execute any code after that
            return;
        }

        // this is reached when timeout gets <= 0

        // Spawn object once
        Spawn();

        // Reset timer
        timeout = timeoutDuration;
    }

    private void Spawn()
    {
        Instantiate(blow, transform);
    }
}
