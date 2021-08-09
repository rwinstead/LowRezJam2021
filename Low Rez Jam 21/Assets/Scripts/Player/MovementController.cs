using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class MovementController : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private LayerMask m_WhatIsLadder;                          // A mask determining what is a ladder to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // Whether or not the player is grounded.
	public bool m_Laddered;            // Whether or not the player is on a ladder.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	public Animator anim;
	public MovementInput moveInput;

	public bool beingKnockedBack = false;

	BoxCollider2D lastPlatformDeactivated = null;
	bool insidePlatformDetector = false;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;
	public UnityEvent OnLadderEvent;

	float gravityScale;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	public float yInputAbs = 0f;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();

		gravityScale = m_Rigidbody2D.gravityScale;
	}

	private void Update()
	{
		yInputAbs = Mathf.Abs(moveInput.verticalMove);
		anim.SetFloat("Y_Speed", m_Rigidbody2D.velocity.y);
		anim.SetBool("Grounded", m_Grounded);
		anim.SetFloat("Y_Input", yInputAbs);
		insidePlatformDetector = false;
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		bool wasLaddered = m_Laddered;
		m_Grounded = false;
		m_Laddered = false;
		anim.SetBool("OnLadder", false);

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;

				anim.SetBool("Jumping", false);
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
		
		colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsLadder);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				if(Mathf.Abs(moveInput.verticalMove) > 0.01f)
                {
					m_Laddered = true;
					anim.SetBool("OnLadder", true);
					if (!wasLaddered)
						m_Rigidbody2D.gravityScale = 0f;
					OnLadderEvent.Invoke();
				}
				

			}
		}

		if(!m_Laddered && wasLaddered)
        {
			m_Rigidbody2D.gravityScale = gravityScale;
		}
	}


	public void Move(float xMove, float yMove, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			//Collider2D platformCol = Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround);
			//if(platformCol != null)
			//{
			//	if (platformCol.gameObject.CompareTag("Platform"))
			//	{
			//		Debug.Log("reneabling platform col");
			//		platformCol.gameObject.GetComponent<BoxCollider2D>().enabled = true;
			//	}
			//}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				xMove *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			}
			else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(xMove * 10f, m_Rigidbody2D.velocity.y);

			if (m_Laddered)
            {
				// Move the character by finding the target velocity
				targetVelocity = new Vector2(xMove * 10f, yMove * 10f);
				m_Rigidbody2D.AddForce(new Vector2(0f, m_Rigidbody2D.gravityScale));
			}

			// And then smoothing it out and applying it to the character
			if (!beingKnockedBack)
			{
				m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
			}

			// If the input is moving the player right and the player is facing left...
			if (xMove > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (xMove < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));

			anim.SetBool("Jumping", true);
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void StartKnockBack(Vector2 force)
	{
		StartCoroutine("KnockBack", force);
	}

	public IEnumerator KnockBack(Vector2 force)
	{
		if (!beingKnockedBack)
		{
			Debug.Log(force);
			beingKnockedBack = true;
			m_Rigidbody2D.velocity = Vector2.zero;
			m_Rigidbody2D.AddForce(force, ForceMode2D.Impulse);
			yield return new WaitForSeconds(.4f);
			beingKnockedBack = false;
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (m_Laddered && collision.gameObject.CompareTag("Platform") && moveInput.verticalMove < 0)
		{
			lastPlatformDeactivated = collision.gameObject.GetComponent<BoxCollider2D>();
			lastPlatformDeactivated.enabled = false;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("PlatformDetector"))
		{
			insidePlatformDetector = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("PlatformDetector") && lastPlatformDeactivated != null && !insidePlatformDetector)
		{
			lastPlatformDeactivated.enabled = true;
		}
	}

}