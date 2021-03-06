using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    public float speed;
    public Transform candle;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        candle = GameObject.Find("FlameSprite").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, candle.position, step);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("OnCollisionEnter2D");
        if (col.gameObject.name == "FlareSprite")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().InitiateGameOver();
        } else
        {
            Destroy(this.gameObject);
        }
    }
}
