using UnityEngine;
using System.Collections;

public class MovingPlatforms : MonoBehaviour {

	Transform platform1;
	Transform platform2;

	public Vector3 platform1Change;
	public Vector3 platform2Change;
	public float totalTime = 2.0f;

	Vector3 originalPosition1;
	Vector3 originalPosition2;

	bool busy;

	bool mystate;

	// Use this for initialization

	void Start () {
		platform1 = transform.GetChild(0);
		platform2 = transform.GetChild(1);

		originalPosition1 = platform1.position;
		originalPosition2 = platform2.position;
		busy = false;
		mystate = true;
	}

	void Update() {
		if (!busy) {
			if (!mystate) {
				platform1.rigidbody.position = originalPosition1 + platform1Change;
				platform2.rigidbody.position = originalPosition2 + platform2Change;
			}
			else {
				platform1.rigidbody.position = originalPosition1;
				platform2.rigidbody.position = originalPosition2;
			}
		}
	}

	public void OnSwitched(bool state){
		if (!busy) {
			busy = true;
			if (mystate) {
				StartCoroutine (MoveTorward ());
				mystate = false;
			} else {
				StartCoroutine (MoveBack ());
				mystate = true;
			}
		}
	}

	IEnumerator MoveTorward(){
		float timeMoving = 0.0f;

		while(timeMoving < totalTime){
			timeMoving += Time.deltaTime;
			platform1.rigidbody.MovePosition(originalPosition1 + timeMoving/totalTime * platform1Change);
			platform2.rigidbody.MovePosition(originalPosition2 + timeMoving/totalTime * platform2Change);
			platform1.GetComponent<IndivPlat>().onMove();
			platform2.GetComponent<IndivPlat>().onMove();
			yield return null;
		}

		platform1.rigidbody.MovePosition(originalPosition1 + platform1Change);
		platform2.rigidbody.MovePosition(originalPosition2 + platform2Change);
		busy = false;
	}

	IEnumerator MoveBack(){
		float timeMoving = totalTime;
		
		while(timeMoving > 0){
			timeMoving -= Time.deltaTime;
			platform1.rigidbody.MovePosition(originalPosition1 + timeMoving/totalTime * platform1Change);
			platform2.rigidbody.MovePosition(originalPosition2 + timeMoving/totalTime * platform2Change);
			platform1.GetComponent<IndivPlat>().onMove();
			platform2.GetComponent<IndivPlat>().onMove();
			yield return null;
		}
		
		platform1.rigidbody.MovePosition(originalPosition1);
		platform2.rigidbody.MovePosition(originalPosition2);
		platform1.rigidbody.position = originalPosition1;
		platform2.rigidbody.position = originalPosition2;
		busy = false;
	}


}
