using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle", menuName = "Obstacles/Create New Obstacle")]
public class ObstacleData : ScriptableObject
{
	public GameObject obstacle;
	public float distance;
}
