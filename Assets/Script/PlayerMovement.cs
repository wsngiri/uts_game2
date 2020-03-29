using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

	public static float runSpeed = 60f;
	public Animator animator;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SoundManagerScript.PlaySound("jump");
			animator.SetBool("IsJumping", true);
			jump = true;
		}

//		if (Input.GetKeyDown(KeyCode.DownArrow))
//		{
//			crouch = true;
//		} else if (Input.GetKeyUp(KeyCode.DownArrow))
//		{
//			crouch = false;
//		}

	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
