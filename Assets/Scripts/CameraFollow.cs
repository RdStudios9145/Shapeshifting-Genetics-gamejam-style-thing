using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public float followSpeed = 2f;
	public float yOffset = 1f;
	public float xOffset = 1f;

	public Transform target;
	
    void FixedUpdate()
    {
		Vector3 targetPos = target.position;
		targetPos.x += xOffset;
		targetPos.y += yOffset;
		targetPos.z = -10;

		transform.position = Vector3.Slerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }
}
