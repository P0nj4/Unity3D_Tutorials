using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xmin, xmax, zmin, zmax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");
		this.rigidBody.velocity = new Vector3 (moveHorizontal * speed, 0.0f, moveVertical * speed);

		rigidBody.position = new Vector3 (
			Mathf.Clamp(this.rigidBody.position.x,this.boundary.xmin, this.boundary.xmax),
			0.0f,
			Mathf.Clamp(this.rigidBody.position.z,this.boundary.zmin, this.boundary.zmax)
		);

		rigidBody.rotation = Quaternion.Euler (0.0f, 0.0f, this.rigidBody.velocity.x * -3);
	}
}
