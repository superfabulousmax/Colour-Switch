using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSwapper : MonoBehaviour, IColorEntity
{
	public uint colourIndex;
	private bool hasColourSwapped;
	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		hasColourSwapped = false;
	}

	public uint GetColourIndex()
	{
		return colourIndex;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (hasColourSwapped)
			return;
		if(collision.CompareTag("Player"))
		{
			Debug.Log("Colour Swapping");
			var playerEntity = collision.GetComponent<Player>();
			playerEntity.ChangeColour();
			hasColourSwapped = true;
		}
	}

	public void Reset()
	{
		Debug.Log("Resetting colour swapper");
		hasColourSwapped = false;
	}

	public void InitializeColours(ColourData colourData)
	{
		GetComponents();
		spriteRenderer.color = colourData.GetColourFromIndex(colourIndex);
	}

	void GetComponents()
	{
		if (spriteRenderer == null)
			spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public GameObject GetGameObject()
	{
		return gameObject;
	}
}
