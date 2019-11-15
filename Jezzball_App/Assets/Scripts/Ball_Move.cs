using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Move : MonoBehaviour
{
    private Rigidbody2D balls_rb;
    public GameObject gameBalls;
    public int numBalls;
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        for (int i = 0; i < numBalls; i++)
        {
            Instantiate(gameBalls, camera.ViewportToWorldPoint(new Vector3(Random.Range(0, 1), Random.Range(0, 1), 9)), Quaternion.identity);
        }
        
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Balls");

        for (int i = 0; i < balls.Length; i++)
        {
            balls_rb = balls[i].GetComponent<Rigidbody2D>();
        
            // Move ball up 10 units per second
            balls_rb.velocity = new Vector2(Random.Range(-10, 10), Random.Range(-10,10));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
