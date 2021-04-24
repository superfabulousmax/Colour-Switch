using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
	[SerializeField]
	private float speed;
	private Vector3 target;
	private Vector3 axis;
	private void Start()
	{
		target = transform.position;
		axis = Vector3.forward;
	}

	void Update()
    {
		transform.RotateAround(target, axis, speed * Time.deltaTime);
	}
}
