using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayManager : MonoBehaviour
{
	[SerializeField]
	private ColourData colorData;

	[SerializeField]
	private ObstacleData[] obstacles;

	[SerializeField]
	private ObstacleData colourSwapper;

	[SerializeField]
	private Transform obstacleContainer;

	[SerializeField]
	private GameObject player;

	public UnityEvent OnGameOver;
	public bool IsGameOver { get => isGameOver; set => isGameOver = value; }
	public static GamePlayManager Instance { get; private set; }

	private IColorEntity playerEntity;
	private bool isGameOver;

	private ObstacleGenerator obstacleGenerator;

	void Awake()
    {
	
		if(Instance == null)
		{
			Instance = this;
		}
        if(player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
			
		}
		if (player)
		{
			playerEntity = player.GetComponent<Player>() as IColorEntity;
			playerEntity.InitializeColours(colorData);
		}
		else
		{
			Debug.LogError("There is no player object in the scene");
		}

		obstacleGenerator = new ObstacleGenerator(obstacles, colourSwapper, obstacleContainer, colorData);
	}

    void Update()
    {
        if(IsGameOver)
		{
			return;
		}
    }

	public void Retry()
	{
		Reset();	
	}

	private void Reset()
	{
		IsGameOver = false;
	}

	public void SetGameOver()
	{
		isGameOver = true;
		obstacleGenerator.ResetObstacles();
		StartCoroutine(WaitThenRun(OnGameOver.Invoke));
	}

	public IEnumerator WaitThenRun(Action method, float time = 2)
	{
		yield return new WaitForSeconds(time);
		method();
	}
}

