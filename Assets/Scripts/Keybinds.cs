using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybinds
{
	static KeyCode lastDownHorizontal;
	static KeyCode lastDownHorizontalAlt;

	public static KeyCode Left = KeyCode.A;
	public static KeyCode LeftAlt = KeyCode.LeftArrow;

	public static KeyCode Right = KeyCode.D;
	public static KeyCode RightAlt = KeyCode.RightArrow;

	public static KeyCode Jump = KeyCode.Space;
	public static KeyCode JumpAlt = KeyCode.JoystickButton0;

	public static KeyCode OpenInventory = KeyCode.E;

	public static float getMovementHorizontal()
	{
		KeyCode tempLastDown = lastDownHorizontal;
		KeyCode tempLastDownAlt = lastDownHorizontalAlt;

		lastDownHorizontal = Left;
		lastDownHorizontalAlt = LeftAlt;
		if (Input.GetKeyDown(Left))     return -1f;
		if (Input.GetKeyDown(LeftAlt))  return -1f;

		lastDownHorizontal = Right;
		lastDownHorizontalAlt = RightAlt;
		if (Input.GetKeyDown(Right))    return  1f;
		if (Input.GetKeyDown(RightAlt)) return  1f;

		lastDownHorizontal = tempLastDown;
		lastDownHorizontalAlt = tempLastDownAlt;
		if (Input.GetAxisRaw("Horizontal") != 0) return Input.GetAxisRaw("Horizontal");

		if (Input.GetKey(lastDownHorizontal) && lastDownHorizontal == Left)           return -1f;
		if (Input.GetKey(lastDownHorizontalAlt) && lastDownHorizontalAlt == LeftAlt)  return -1f;
		if (Input.GetKey(lastDownHorizontal) && lastDownHorizontal == Right)          return  1f;
		if (Input.GetKey(lastDownHorizontalAlt) && lastDownHorizontalAlt == RightAlt) return  1f;

		if (Input.GetKey(Left))     return -1f;
		if (Input.GetKey(LeftAlt))  return -1f;
		if (Input.GetKey(Right))    return  1f;
		if (Input.GetKey(RightAlt)) return  1f;

		return 0f;
	}
}
