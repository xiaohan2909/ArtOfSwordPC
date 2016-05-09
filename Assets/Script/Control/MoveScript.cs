using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	// 1 - Designer variables
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);
	
	private Vector2 movement;
	
	void Update()
	{
		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		transform.parent.rigidbody.velocity = new Vector3(movement.x, movement.y ,0f);
	//	transform.parent.rigidbody2D.velocity = movement;
	}
}
