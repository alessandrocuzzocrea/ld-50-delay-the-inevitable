using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] heads;

    public GameObject[] heads_pattern0_a;
    public GameObject[] heads_pattern0_b;
    public GameObject[] heads_pattern0_c;
    public GameObject[] heads_pattern0_d;

    public float timeout;
    public float timeoutDuration;

    public float pattern0_timeout;
    public float pattern0_timeoutDuration;


    void Start()
    {
        DeactivateAll();
    }

    void Update()
    {

        timeout -= Time.deltaTime;
        pattern0_timeout -= Time.deltaTime;

        if (timeout < 0)
        {

            if (pattern0_timeout < 0.0f)
            {
                Debug.Log("pattern0");
                GameObject[] randomPattern0 = SelectRndPattern0();
                DoPattern0(randomPattern0);
                pattern0_timeout = pattern0_timeoutDuration;
                timeout = timeoutDuration * 2;
            }
            else
            {
                Debug.Log("reg pattern");
                DoStuff();
                timeout = timeoutDuration;
            }
        }
    }

    void ActivateWithTimeout(GameObject head, float timeout)
    {
        head.SetActive(true);
        head.GetComponent<Head>().timeout = timeout;
        head.GetComponent<Head>().timeoutDuration = timeout;
    }

    void DoStuff()
    {
        DeactivateAll();
        GameObject rndHead = heads[Random.Range(0, heads.Length)];
        ActivateWithTimeout(rndHead, 0.5f);
    }

    GameObject[] SelectRndPattern0()
    {
        switch(Random.Range(0, 4))
        {
            case 0:
                return heads_pattern0_a;
            case 1:
                return heads_pattern0_b;
            case 2:
                return heads_pattern0_c;
            default:
                return heads_pattern0_d;
        }
    }

    void DoPattern0(GameObject[] heads)
    {
        DeactivateAll();
        ActivateWithTimeout(heads[0], 0.3f);
        ActivateWithTimeout(heads[1], 0.6f);
        ActivateWithTimeout(heads[2], 0.9f);
    }

    void DeactivateAll()
    {
        foreach (GameObject head in heads)
        {
            head.SetActive(false);
        }
    }
}
