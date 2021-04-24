using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorData", menuName = "Color Settings/Create New Color Data")]
public class ColourData : ScriptableObject
{
	[SerializeField]
	private Color one, two, three, four;
	public int size = 4;

	public Color GetColourFromIndex(uint index)
	{
		switch(index)
		{
			case 0:
				return one;
			case 1:
				return two;
			case 2:
				return three;
			case 3:
				return four;
		}
		Debug.Log("Passed in color index that is not handled");
		return Color.white;
	}

	public Color GetRandomColour()
	{
		return GetColourFromIndex((uint)Random.Range(0, size));
	}

	public uint GetRandomColourIndex(uint excludedColour)
	{
		uint i = (uint)Random.Range(0, size);
		if (i == excludedColour)
		{
			i = (i + 1) % (uint)size;
		}
		return i;
	}
	public Color GetRandomColour(uint excludedColour)
	{
		var i = GetRandomColourIndex(excludedColour);
		return GetColourFromIndex(i);
	}
}
