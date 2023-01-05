using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MutationLocation
{
	Head, Body, Arms, Feet
}

[RequireComponent(typeof(Collider2D))]
public class Mutation : MonoBehaviour
{

	public string playerTag = "Player";

	public Sprite icon;
	public Sprite mutation;

	public MutationLocation location = MutationLocation.Body;

	public new string name = "Boots";

	private void OnEnable()
	{
		MutationManager.mutationList.Add(this);
		try
		{
			GetComponent<SpriteRenderer>().sprite = icon;
		} catch { }
	}

	private void OnDisable() => MutationManager.mutationList.Remove(this);

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag != playerTag) return;
		MutationManager.obtainedMutations.Add(this);
		gameObject.SetActive(false);
	}
}
