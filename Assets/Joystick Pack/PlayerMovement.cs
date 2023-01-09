using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public PlayerGroudCheck groundCheck;
	public Animator animator;
	[SerializeField]
	protected Rigidbody2D rb = null;

	public Joystick joystick;

	public float runSpeed = 1000f;

	public float jumpHeight = 2f;

	float horizontalMove = 0f;
	bool jumping = false;
	bool crouch = false;

    private void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
	{
	
		horizontalMove = joystick.Horizontal * runSpeed;

		if (joystick.Horizontal >= .2f)
        {
			horizontalMove = runSpeed;
        } else if (joystick.Horizontal <= -.2f)
        {
			horizontalMove = -runSpeed;
        }
		else
        {
			horizontalMove = 0f;
        }

		float verticalMove = joystick.Vertical;

		//animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (groundCheck.isGrounded == true)
		{
			if (verticalMove >= .5f)
            {
				if (jumping == false)
                {
					Jump();

					jumping = true;

					//animator.SetBool("IsJumping", true);
				}
			}
			
		}

		if (groundCheck.isGrounded == true)
        {
			jumping = false;
        }

		if (verticalMove <= -.5f)
		{
			crouch = true;
		}
		else 
		{
			crouch = false;
		}

	}

	/*public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}*/

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jumping);
		jumping = false;
	}

	void Jump()
    {
		rb.AddForce(Vector2.up * jumpHeight);
	}
}