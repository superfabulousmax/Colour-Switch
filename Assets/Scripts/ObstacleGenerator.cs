using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleGenerator
{
	private List<IColorEntity> generatedObstacles;
	private ObstacleData[] obstacles;
	private ObstacleData colourSwapper;
	private Transform container;
	private ColourData colourData;

	public ObstacleGenerator(ObstacleData[] obstacles, ObstacleData colourSwapper, Transform container, ColourData colourData)
	{
		this.obstacles = obstacles;
		this.colourSwapper = colourSwapper;
		this.container = container;
		this.colourData = colourData;
		generatedObstacles = new List<IColorEntity>();
		Generate();
		GenerateColourSwapper();
		Generate();
		GenerateColourSwapper();
		Generate();
		GenerateColourSwapper();
		Generate();
	}

	public List<IColorEntity> GeneratedObstacles { get => generatedObstacles; set => generatedObstacles = value; }

	public void Generate()
	{
		var i = Random.Range(0, obstacles.Length);
		var ob = Object.Instantiate(obstacles[i].obstacle, container);
		var prevOb = generatedObstacles.LastOrDefault();
		var y = prevOb == null ? obstacles[i].distance : obstacles[i].distance + prevOb.GetGameObject().transform.position.y;
		ob.transform.position = new Vector3(0, y, 0);
		ob.transform.rotation = Random.rotation;
		ob.transform.eulerAngles = new Vector3(0, 0, ob.transform.eulerAngles.z);
		var parts = ob.GetComponentsInChildren<ObstaclePart>();
		foreach (var part in parts)
		{
			var entity = part as IColorEntity;
			if (entity != null)
			{
				entity.InitializeColours(colourData);
				generatedObstacles.Add(entity);
			}
		}
	}

	public void GenerateColourSwapper()
	{
		var ob = Object.Instantiate(colourSwapper.obstacle, container);
		var prevOb = generatedObstacles.LastOrDefault();
		var y = prevOb == null ? colourSwapper.distance : colourSwapper.distance + prevOb.GetGameObject().transform.position.y;
		ob.transform.position = new Vector3(0, y, 0);
		var parts = ob.GetComponentsInChildren<ColourSwapper>();
		foreach (var part in parts)
		{
			var entity = part as IColorEntity;
			if (entity != null)
			{
				entity.InitializeColours(colourData);
				generatedObstacles.Add(entity);
			}
		}
	}

	public void ResetObstacles()
	{
		generatedObstacles.ForEach(o => o.Reset());
	}
}
