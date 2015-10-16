using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject expotion;
	public GameObject playerExpotion;

	void OnTriggerEnter(Collider other) {
		//Debug.Log (other.name);
		if (other.tag == "JailTag") {
			return;
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
		Instantiate (expotion, transform.position, transform.rotation);
		Debug.Log (other.tag);
		if (other.tag == "Player1") {
			Debug.Log ("lalala");
			Instantiate (playerExpotion, other.transform.position, other.transform.rotation);
		}
	}
}
