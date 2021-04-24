using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Player : MonoBehaviour, IColorEntity
{
	[SerializeField]
	private float forceFactor;
	[SerializeField]
	private ParticleSystem deathParticles;
	private InputController input;
	private Rigidbody2D rb;
	private SpriteRenderer spriteRenderer;

	private Vector3 startPosition;
	private bool hasReset;
	private ColourData colourData;
	private uint currentColourIndex;

	public uint GetColourIndex() { return currentColourIndex; }

	public void InitializeColours(ColourData colourData)
	{
		this.colourData = colourData;
		Debug.Log("Init player colours");
		GetComponents();
		currentColourIndex = (uint)Random.Range(0, colourData.size);
		spriteRenderer.color = colourData.GetColourFromIndex(currentColourIndex);
	}

	void Start()
    {
		hasReset = false;
		startPosition = transform.position;
		GetComponents();
	}

	void GetComponents()
	{
		if(rb == null)
			rb = GetComponent<Rigidbody2D>();
		if(spriteRenderer == null)
			spriteRenderer = GetComponent<SpriteRenderer>();
	}

    void Update()
    {
		if (GamePlayManager.Instance.IsGameOver)
			return;
        if(Input.GetKeyDown(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
		{
			rb.AddForceAtPosition(Vector2.up * forceFactor, transform.position, ForceMode2D.Impulse);
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var entity = collision.GetComponent<ObstaclePart>();
		if(entity != null)
		{
			if (entity.GetColourIndex() != GetColourIndex())
			{
				var particles = Instantiate(deathParticles, transform.position, Quaternion.identity);
				spriteRenderer.enabled = false;
				Destroy(particles.gameObject, 2);
				GamePlayManager.Instance.SetGameOver();
				StartCoroutine(GamePlayManager.Instance.WaitThenRun(Reset));
				
			}
		}
	}

	public void ChangeColour()
	{
		currentColourIndex = colourData.GetRandomColourIndex(currentColourIndex);
		spriteRenderer.color = colourData.GetColourFromIndex(currentColourIndex);
	}

	private void Reset()
	{
		rb.velocity = Vector3.zero;
		rb.position = startPosition;
		spriteRenderer.enabled = true;
	}

	void IColorEntity.Reset()
	{
		throw new NotImplementedException();
	}

	public GameObject GetGameObject()
	{
		throw new NotImplementedException();
	}
}
