using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

    }

    private void OnGUI()
    {

        GUI.Label(new Rect(0, 10, 1000, 90), string.Format("Seconds: {0}", timer));
    }
}
