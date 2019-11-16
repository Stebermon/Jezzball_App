using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private float speed;
    private Vector2 unit;

    // Start is called before the first frame update
    void Start()
    {
        speed = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        
    }

    // Update is called once per frame
    void Update()
    {
        unit = GetComponent<Rigidbody2D>().velocity.normalized;
    }

    // Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Balls")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = -unit * speed;
        }
    }
}
