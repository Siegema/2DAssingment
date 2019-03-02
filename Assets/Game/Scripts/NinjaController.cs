using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class NinjaController : MonoBehaviour
{
	public float speed = 5.0f;
	public float movementThreshold = 0.5f;

	private Vector2 inputDirection;
	private Rigidbody2D _rigidbody2D;
	private Animator _animator;

	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
    {
		inputDirection.x = Input.GetAxis("Horizontal");
		inputDirection.y = Input.GetAxis("Vertical");

		if (inputDirection.magnitude > movementThreshold)
		{
			_rigidbody2D.velocity = new Vector2(inputDirection.x * speed, inputDirection.y * speed);

			// Set the input values on the animator
			_animator.SetFloat("inputX", inputDirection.x);
			_animator.SetFloat("inputY", inputDirection.y);
			_animator.SetBool("isWalking", true);
		}
		else
		{
			_rigidbody2D.velocity = new Vector2();
			_animator.SetBool("isWalking", false);
		}
	}
}
