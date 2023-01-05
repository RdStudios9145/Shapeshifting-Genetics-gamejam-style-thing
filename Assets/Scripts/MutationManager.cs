using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MutationManager : MonoBehaviour
{
	[SerializeField] GameObject Player;

	public static List<Mutation> mutationList = new List<Mutation>();
	public static List<Mutation> obtainedMutations = new List<Mutation>();
	public static List<Mutation> enabledMutations = new List<Mutation>();

	[SerializeField] GameObject Inventory;
	[SerializeField] GameObject MutationsList;

	public void ChangeInventoryVisibility()
	{
		UpdateMutationList();

		Inventory.SetActive(!Inventory.activeInHierarchy);

		if (!Inventory.activeInHierarchy) UpdateCharacterMutations();
	}

	void UpdateMutationList()
	{
		System.Type[] typeList = { typeof(CanvasRenderer), typeof(Image), typeof(Button) };

		foreach (Mutation mutation in obtainedMutations)
		{
			if (MutationsList.transform.Find(mutation.name) != null) continue;
			GameObject listObject = new GameObject(mutation.name, typeList);
			listObject.transform.SetParent(MutationsList.transform, false);
			listObject.GetComponent<Image>().sprite = mutation.icon;
			listObject.GetComponent<Button>().onClick.AddListener(onMutationClick);
			mutation.gameObject.transform.SetParent(listObject.transform, false);
			mutation.gameObject.transform.name = "Mutation";
		}
	}

	void onMutationClick()
	{
		Mutation c = EventSystem.current.currentSelectedGameObject.transform
			.Find("Mutation").GetComponent<Mutation>();
		if (enabledMutations.Contains(c)) enabledMutations.Remove(c);
		else enabledMutations.Add(c);
	}

	void UpdateCharacterMutations()
	{
		System.Type[] typeList = { typeof(SpriteRenderer) };

		foreach (Mutation mutation in enabledMutations)
		{
			Transform location = getMutationLocation(mutation);

			GameObject listObject = new GameObject(mutation.name, typeList);
			listObject.transform.SetParent(location, false);
			listObject.GetComponent<SpriteRenderer>().sprite = mutation.mutation;
			listObject.transform.localScale = Vector3.one * 0.67f;

		}
	}

	Transform getMutationLocation(Mutation m)
	{
		if (m.location == MutationLocation.Head) return Player.transform.Find("Head");
		if (m.location == MutationLocation.Body) return Player.transform.Find("Body");
		if (m.location == MutationLocation.Arms) return Player.transform.Find("Arms");
		if (m.location == MutationLocation.Feet) return Player.transform.Find("Feet");
		return null;
	}
}
