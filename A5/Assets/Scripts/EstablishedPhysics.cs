using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstablishedPhysics : MonoBehaviour
{

    [SerializeField] private Vector2 velocity;
    [SerializeField] private float angularVelocity;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 currentVelocity;
    private float currentAngleVelocity;
    private bool paused;

    [SerializeField] private Vector2 cameraBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = velocity;
        rb.angularVelocity = angularVelocity;
        paused = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if((transform.position.x >= cameraBounds.x && rb.velocity.x > 0) || (transform.position.x <= cameraBounds.x * -1 && rb.velocity.x < 0))
        {
            rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
        }

        if ((transform.position.y >= cameraBounds.y && rb.velocity.y > 0) || (transform.position.y <= cameraBounds.y * -1 && rb.velocity.y < 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * -1);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(paused)
            {
                rb.angularVelocity = currentAngleVelocity;
                rb.velocity = currentVelocity;
                paused = false;
            }
            else
            {
                currentAngleVelocity = rb.angularVelocity;
                currentVelocity = rb.velocity;

                rb.angularVelocity = 0;
                rb.velocity = new Vector2(0, 0);

                paused = true;
            }
            
        }
    }
}
