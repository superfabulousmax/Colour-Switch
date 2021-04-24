using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleColorizer : MonoBehaviour, IColorEntity
{
	[SerializeField]
	private ColourData colourData;

	private ParticleSystem system;

	private void Awake()
	{
		system = GetComponent<ParticleSystem>();
	}

	private void Update()
	{
		InitializeColours(colourData);
	}

	public uint GetColourIndex()
	{
		return 0;
	}

	public void InitializeColours(ColourData colourData)
	{
		if (system == null)
			return;
		var copySystem = new ParticleSystem.Particle[system.main.maxParticles];
		var count = system.GetParticles(copySystem);
		for (int i = 0; i < count; i++)
		{
			if(copySystem[i].startColor == Color.white)
				copySystem[i].startColor = colourData.GetRandomColour();
		}
		system.SetParticles(copySystem, count);
	}

	public void Reset()
	{
		return;
	}

	public GameObject GetGameObject()
	{
		return gameObject;
	}
}
