using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public float InputX;
	public float InputXRS;
	public float InputZ;
	public Vector3 desiredMovementDirection;
	public bool blockRotationPlayer;
	public float desiredRotationSpeed;
	public Animator anim;
	public float Speed;
	public float allowplayerRotation;
	public Camera cam;
	public CharacterController controller;
	public bool isGrounded;
	private float verticalVel;
	private Vector3 moveVector;
	public float movementSpeed = 10f;
	public bool isAttacking;

	// Start is called before the first frame update
	void Start()
	{
		anim = this.GetComponent<Animator>();
		cam = Camera.main;
		controller = this.GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		InputMagnitude();
		isGrounded = controller.isGrounded;
		if (isGrounded)
		{
			verticalVel -= 0;
		}
		else
		{
			verticalVel -= 2;
		}
		moveVector = new Vector3(0, verticalVel, 0);
		controller.Move(moveVector);
	}

	void PlayerMoveAndRotation()
	{
		InputX = Input.GetAxis("Horizontal");
		InputZ = Input.GetAxis("Vertical");

		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0.0f;
		right.y = 0.0f;

		forward.Normalize();
		right.Normalize();

		desiredMovementDirection = forward * InputZ + right * InputX;
		if (!blockRotationPlayer)
		{
			if (InputX != 0)
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMovementDirection), desiredRotationSpeed);
		}
		if (!isAttacking)
		{
			controller.Move(desiredMovementDirection * Time.deltaTime * movementSpeed);
		}
	}

	void InputMagnitude()
	{
		//calcular los vectores de input
		InputX = Input.GetAxis("Horizontal");
		InputZ = Input.GetAxis("Vertical");

		//Calcular la magnitud del imput
		Speed = new Vector2(InputX, InputZ).sqrMagnitude;

		//mover el jugador fisicamente
		if (Speed >= allowplayerRotation)
		{
			PlayerMoveAndRotation();
		}
		else if (Speed < allowplayerRotation)
		{

		}
	}

	void IsNotAttacking()
	{
		isAttacking = false;
	}
	void StartedAttacking()
	{
		isAttacking = true;
	}
}
