using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float hSpeed = 5f;
    private float horizontal;
    private float vSpeed = 0f;

    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        IsGrounded();
    }

    // Update is called once per frame
    void Update()
    {

        
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            vSpeed = 10f;
        }

        player.velocity = new Vector2(horizontal * hSpeed, vSpeed);
        
        if (vSpeed >= -5f)
        {
            Debug.Log(vSpeed);
            vSpeed -= .2f;
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //return true;
    }
}
