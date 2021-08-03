using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
	public float moveSpeed = 3.0f;
	public float jumpForce= 5.0f;

	Vector3 moveDirection = Vector3.zero;
	Vector2 position;

	Rigidbody2D rb;
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		float horizontalInput = Input.GetAxisRaw("Horizontal");

		rb.velocity = new Vector2(horizontalInput * moveSpeed,rb.velocity.y);

		if(Input.GetButton("Jump") && IsGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x,jumpForce);
		}

	}

	private bool IsGrounded()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 3);

		if(hit.collider != null)
		{
			return true;
		}

		return false;
	}

}
