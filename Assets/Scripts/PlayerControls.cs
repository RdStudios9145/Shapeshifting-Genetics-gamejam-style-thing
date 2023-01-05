using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : MonoBehaviour
{
	CharacterController2D controller;
	[SerializeField] MutationManager mutationManager;

	public float moveSpeed = 40f;

	private float HorizontalMoveSpeed = 0f;
	private bool Jump = false;

	private void OnEnable()
	{
		controller = GetComponent<CharacterController2D>();
	}

	void Update()
    {
		HorizontalMoveSpeed = Keybinds.getMovementHorizontal() * moveSpeed;
		if (Input.GetKey(Keybinds.Jump) || Input.GetKey(Keybinds.JumpAlt)) Jump = true;
		if (Input.GetKeyDown(Keybinds.OpenInventory)) mutationManager.ChangeInventoryVisibility();
    }

	private void FixedUpdate()
	{
		controller.Move(HorizontalMoveSpeed * Time.deltaTime, Jump);
		Jump = false;
	}
}
