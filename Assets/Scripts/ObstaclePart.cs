using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObstaclePart : MonoBehaviour, IColorEntity
{
	public uint colourIndex;

	private SpriteRenderer spriteRenderer;

	private ColourData colourData;

	public uint GetColourIndex()
	{
		return colourIndex;
	}

	public GameObject GetGameObject()
	{
		return gameObject;
	}

	public void InitializeColours(ColourData colourData)
	{
		this.colourData = colourData;
		GetComponents();
		spriteRenderer.color = colourData.GetColourFromIndex(colourIndex);
	}

	public void Reset()
	{
		Debug.Log("Resetting obstacle part");
		return;
	}

	void GetComponents()
	{
		if (spriteRenderer == null)
			spriteRenderer = GetComponent<SpriteRenderer>();
	}
}

