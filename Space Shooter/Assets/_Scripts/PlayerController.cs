using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xmin, xmax, zmin, zmax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private Rigidbody rigidBody;
	private float nextFire = 0.0f;

	void Start () {
		rigidBody = this.GetComponent<Rigidbody> ();
	}


	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
		}
	}

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
