using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	public GameObject hazzard;
	public Vector3 spawnValue;
	public float spawnWait;
	public float startWait;

	IEnumerator spawnWaves() {
		while (true) {
			yield return new WaitForSeconds (startWait);

			for (int i = 0; i < 10; i++) {
				Vector3 position = new Vector3 (Random.Range (spawnValue.x * -1, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion rotation = Quaternion.identity;
				Instantiate (hazzard, position, rotation);
				yield return new WaitForSeconds (spawnWait);
			}
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (spawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
