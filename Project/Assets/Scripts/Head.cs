using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Head : MonoBehaviour
{
    public float timeoutDuration;
    public float timeout;
    public GameObject blow;

    void Start()
    {
        timeoutDuration = Random.Range(1, 4);

        timeout = 0;
    }

    void Update()
    {
        if (timeout > 0)
        {
            timeout -= Time.deltaTime;

            return;
        }


        Spawn();

        timeout = Mathf.Infinity;
    }

    private void Spawn()
    {
        Instantiate(blow, transform.position, Quaternion.identity);
    }
}
