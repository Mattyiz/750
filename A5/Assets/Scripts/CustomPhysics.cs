using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{

    [SerializeField] public Vector2 velocity;
    [SerializeField] public float angularVelocity;
    [SerializeField] private Collider2D collider;
    [SerializeField] private Collider2D collider2;
    [SerializeField] private LayerMask layer;

    private Vector2 currentVelocity;
    private float currentAngleVelocity;
    private bool paused;

    [SerializeField] private Vector2 cameraBounds;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        currentVelocity = velocity;
        currentAngleVelocity = angularVelocity;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (paused)
            {
                angularVelocity = currentAngleVelocity;
                //velocity = currentVelocity;
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

        if(!paused)
        {
            velocity = currentVelocity;
            angularVelocity = currentAngleVelocity;
        }

    }

    void FixedUpdate()
    {
        transform.position += new Vector3 (velocity.x, velocity.y, 0);
        transform.Rotate(0, 0, angularVelocity, Space.Self);

        if ((transform.position.x >= cameraBounds.x && velocity.x > 0) || (transform.position.x <= cameraBounds.x * -1 && velocity.x < 0))
        {
            currentVelocity = new Vector2(velocity.x * -1, velocity.y);
        }

        if ((transform.position.y >= cameraBounds.y && velocity.y > 0) || (transform.position.y <= cameraBounds.y * -1 && velocity.y < 0))
        {
            currentVelocity = new Vector2(velocity.x, velocity.y * -1);

        }

        /*if (collider.IsTouchingLayers(layer))
        {
        }*/

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if((velocity.x > 0 && collision.collider.GetComponent<CustomPhysics>().velocity.x > 0) || (velocity.x < 0 && collision.collider.GetComponent<CustomPhysics>().velocity.x < 0))
        {
            currentVelocity.x = (velocity.x + (collision.collider.GetComponent<CustomPhysics>().velocity.x * .9f))/2;
        }
        else
        {
            currentVelocity.x = velocity.x + (collision.collider.GetComponent<CustomPhysics>().velocity.x * 1.1f);
        }

        if ((velocity.y > 0 && collision.collider.GetComponent<CustomPhysics>().velocity.y > 0) || (velocity.y < 0 && collision.collider.GetComponent<CustomPhysics>().velocity.y < 0))
        {
            currentVelocity.y = (velocity.y + (collision.collider.GetComponent<CustomPhysics>().velocity.y * .9f))/ 2;
        }
        else
        {
            currentVelocity.y = velocity.y + (collision.collider.GetComponent<CustomPhysics>().velocity.y * 1.1f);
        }

        if ((angularVelocity > 0 && collision.collider.GetComponent<CustomPhysics>().angularVelocity > 0) || (angularVelocity < 0 && collision.collider.GetComponent<CustomPhysics>().angularVelocity < 0))
        {
            currentAngleVelocity = (angularVelocity + (collision.collider.GetComponent<CustomPhysics>().angularVelocity * .9f)) / 2;
        }
        else
        {
            currentAngleVelocity = angularVelocity + (collision.collider.GetComponent<CustomPhysics>().angularVelocity * 1.1f);
        }

    }

}
