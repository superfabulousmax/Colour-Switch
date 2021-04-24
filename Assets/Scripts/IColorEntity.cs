using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColorEntity
{
	void InitializeColours(ColourData colourData);

	uint GetColourIndex();

	void Reset();

	GameObject GetGameObject();
}
