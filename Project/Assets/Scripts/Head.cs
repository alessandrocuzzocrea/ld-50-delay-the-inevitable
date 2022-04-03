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
    public GameObject skull;
    public GameObject jaw;


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
        OpenJaw();
        GameObject newBlow = Instantiate(blow, transform.position, Quaternion.identity);
        Vector3 newScale = newBlow.transform.localScale;
        newScale.x = transform.localScale.x;
        newBlow.transform.localScale = newScale;
    }

    public void OpenJaw()
    {
        //Quaternion newRot = jaw.transform.localRotation;
        skull.GetComponent<SpriteRenderer>().color = Color.magenta;
        jaw.GetComponent<SpriteRenderer>().color = Color.magenta;
        jaw.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -24.0f);
    }

    public void CloseJaw()
    {
        //Quaternion newRot = jaw.transform.localRotation;
        skull.GetComponent<SpriteRenderer>().color = Color.gray;
        jaw.GetComponent<SpriteRenderer>().color = Color.gray;
        jaw.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
}
