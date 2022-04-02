using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float timer = 0.0f;

    public float power0_cooldown = 0.0f;

    public float power1_cooldown = 0.0f;
    public float power1_duration = 5.0f;

    //public GameObject hand0;
    //public GameObject hand1;
    public GameObject currentHand;
    public GameObject otherHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        power0_cooldown = Mathf.Max(0.0f, power0_cooldown - Time.deltaTime);
        power1_cooldown = Mathf.Max(0.0f, power1_cooldown - Time.deltaTime);
        power1_duration = Mathf.Max(0.0f, power1_duration - Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
        {
            if (power0_cooldown == 0.0f)
            {
                if (power1_duration == 0.0f)
                {
                    SwapHands();
                    currentHand.GetComponent<SpriteRenderer>().enabled = true;
                    currentHand.GetComponent<BoxCollider2D>().enabled = true;
                    otherHand.GetComponent<SpriteRenderer>().enabled = false;
                    otherHand.GetComponent<BoxCollider2D>().enabled = false;
                }

                power0_cooldown = 1.0f;
            }

        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (power1_cooldown == 0.0f)
            {
                otherHand.GetComponent<SpriteRenderer>().enabled = true;
                otherHand.GetComponent<BoxCollider2D>().enabled = true;

                power1_cooldown = 7.0f;
                power1_duration = 4.0f;
            }
        }

        if (power1_duration == 0.0f)
        {
            otherHand.GetComponent<SpriteRenderer>().enabled = false;
            otherHand.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void SwapHands()
    {
        GameObject swap = currentHand;
        currentHand = otherHand;
        otherHand = swap;
    }

    private void OnGUI()
    {

        GUI.Label(new Rect(10, 20, 1000, 90), string.Format("Seconds: {0}", timer));
        GUI.Label(new Rect(10, 30, 1000, 90), string.Format("Power 0: Cooldown:{0}", power0_cooldown));
        GUI.Label(new Rect(10, 40, 1000, 90), string.Format("Power 1: Cooldown:{0} - Duration:{1}", power1_cooldown, power1_duration));
        //GUI.Label(new Rect(0, 30, 1000, 90), string.Format("Power 2: {0}", timer));
        //GUI.Label(new Rect(0, 40, 1000, 90), string.Format("Power 3: {0}", timer));
    }
}
