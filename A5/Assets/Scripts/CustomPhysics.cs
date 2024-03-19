using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{

    [SerializeField] private Vector2 velocity;
    [SerializeField] private float angularVelocity;
    [SerializeField] private Collider2D collider;


    private Vector2 currentVelocity;
    private float currentAngleVelocity;
    private bool paused;

    [SerializeField] private Vector2 cameraBounds;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (paused)
            {
                angularVelocity = currentAngleVelocity;
                velocity = currentVelocity;
                paused = false;
            }
            else
            {
                currentAngleVelocity = angularVelocity;
                currentVelocity = velocity;

                angularVelocity = 0;
                velocity = new Vector2(0, 0);

                paused = true;
            }

        }
    }

    void FixedUpdate()
    {
        transform.position += new Vector3 (velocity.x, velocity.y, 0);

        if ((transform.position.x >= cameraBounds.x && velocity.x > 0) || (transform.position.x <= cameraBounds.x * -1 && velocity.x < 0))
        {
            velocity = new Vector2(velocity.x * -1, velocity.y);
        }

        if ((transform.position.y >= cameraBounds.y && velocity.y > 0) || (transform.position.y <= cameraBounds.y * -1 && velocity.y < 0))
        {
            velocity = new Vector2(velocity.x, velocity.y * -1);
        }

    }
}
