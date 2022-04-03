using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float rotateSpeed;
    public float maxRotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.parent.position, new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(transform.parent.position, new Vector3(0, 0, 1), -1 * rotateSpeed * Time.deltaTime);

        }
    }
}
