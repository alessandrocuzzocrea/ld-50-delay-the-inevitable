using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] heads;
    public float timeout;
    public float timeoutDuration;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateAll();
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
        DoStuff();

        // Reset timer
        timeout = timeoutDuration;
    }

    void DoStuff()
    {
        DeactivateAll();
        GameObject rndHead = heads[Random.Range(0, heads.Length)];
        rndHead.SetActive(true);
    }

    void DeactivateAll()
    {
        foreach (GameObject head in heads)
        {
            head.SetActive(false);
        }
    }
}
