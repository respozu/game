using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    public bool _isGrounded = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalMove = 0;
        if (Input.GetKey(KeyCode.A)) horizontalMove -= speed;
        if (Input.GetKey(KeyCode.D)) horizontalMove += speed;

        Vector2 vectorMove = new Vector2(horizontalMove, _rb.velocity.y);
        _rb.velocity = vectorMove;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) _rb.AddForce(new Vector2(0, jumpForce));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
    }
}
