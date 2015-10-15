using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text finishText;

	private Rigidbody rb;
	private int count;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		updateCount();
	}

	void FixedUpdate () {
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 vec = new Vector3 (moveHorizontal * 1, 0.0f, moveVertical * 1);
		rb.AddForce (vec * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count+=1;
			updateCount();
		}
	}

	void updateCount(){
		this.countText.text = "Score: " + (this.count * 10).ToString();
		if (this.count == 12) {
			this.finishText.gameObject.SetActive(true);
		}
	}
}
