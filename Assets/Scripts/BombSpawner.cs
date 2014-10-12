using UnityEngine;
using System.Collections;

public class BombSpawner : MonoBehaviour {

	public GameObject Bomb;
	public GameObject BombUsable;

	// Use this for initialization
	void Start () {
		BombUsable = (GameObject) Instantiate (Bomb);
		BombUsable.transform.position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (BombUsable == null) {
			BombUsable = (GameObject) Instantiate (Bomb);
			BombUsable.transform.position = this.transform.position;
		}
	}
}
