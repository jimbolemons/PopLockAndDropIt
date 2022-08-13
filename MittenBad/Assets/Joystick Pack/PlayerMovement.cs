using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator animator;
	[SerializeField]
	protected Rigidbody2D rb = null;

	public Joystick joystick;

	public float runSpeed = 1000f;

	float horizontalMove = 0f;
	bool jump = false;
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

		if (controller.m_Grounded == true && verticalMove >= .5f && jump == false)
		{
			jump = true;

			StartCoroutine(Jump());

			//animator.SetBool("IsJumping", true);
		}

		if (controller.m_Grounded == true)
        {
			jump = false;
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
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	IEnumerator Jump()
    {
		float jumpForce = 10f;
		rb.AddForce(new Vector2(0f, jumpForce));
		yield return null;
    }
}