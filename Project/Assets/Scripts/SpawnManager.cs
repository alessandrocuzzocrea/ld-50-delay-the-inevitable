using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int rounds = 0;

    public GameManager gameManager;
    public GameObject[] heads;

    public GameObject[] heads_pattern0_a;
    public GameObject[] heads_pattern0_b;
    public GameObject[] heads_pattern0_c;
    public GameObject[] heads_pattern0_d;

    public GameObject[] heads_pattern1_a;
    public GameObject[] heads_pattern1_b;
    public GameObject[] heads_pattern1_c;
    public GameObject[] heads_pattern1_d;
    public GameObject[] heads_pattern1_e;

    public float timeout;
    public float timeoutDuration;

    public float pattern0_timeout;
    public float pattern0_timeoutDuration;

    public float pattern1_timeout;
    public float pattern1_timeoutDuration;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        DeactivateAll();
    }

    void Update()
    {

        if (gameManager.gameStarted == false && gameManager.gameEnded == false)
        {
            return;
        }

        Debug.Log("spawnManage");

        timeout -= Time.deltaTime;
        pattern0_timeout -= Time.deltaTime;
        pattern1_timeout -= Time.deltaTime;

        if (timeout < 0)
        {
            rounds++;

            if (pattern1_timeout < 0.0f && rounds >= 10)
            {
                Debug.Log("pattern1");
                GameObject[] randomPattern1 = SelectRndPattern1();
                DoPattern1(randomPattern1);
                pattern1_timeout = pattern1_timeoutDuration;
                timeout = timeoutDuration * 2;
            }
            else if (pattern0_timeout < 0.0f && rounds >= 10)
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
        rndHead.GetComponent<Head>().CloseJaw();
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

    void DoPattern0(GameObject[] headz)
    {
        DeactivateAll();
        ActivateWithTimeout(headz[0], 0.3f);
        ActivateWithTimeout(headz[1], 0.6f);
        ActivateWithTimeout(headz[2], 0.9f);
    }

    GameObject[] SelectRndPattern1()
    {
        switch (Random.Range(0, 5))
        {
            case 0:
                return heads_pattern1_a;
            case 1:
                return heads_pattern1_b;
            case 2:
                return heads_pattern1_c;
            case 3:
                return heads_pattern1_d;
            default:
                return heads_pattern1_e;
        }
    }

    void DoPattern1(GameObject[] headz)
    {
        DeactivateAll();
        ActivateWithTimeout(headz[0], 0.5f);
        ActivateWithTimeout(headz[1], 0.5f);
    }

    void DeactivateAll()
    {
        foreach (GameObject head in heads)
        {
            head.SetActive(false);
        }
    }
}
