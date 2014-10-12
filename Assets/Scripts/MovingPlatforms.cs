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

	// Use this for initialization

	void Start () {
		platform1 = transform.GetChild(0);
		platform2 = transform.GetChild(1);

		originalPosition1 = platform1.position;
		originalPosition2 = platform2.position;
	}

	public void OnSwitched(bool state){
		if(state){
			StartCoroutine(MoveTorward());
		}
		else{
			StartCoroutine(MoveBack());
		}
	}

	IEnumerator MoveTorward(){
		float timeMoving = 0.0f;

		while(timeMoving < totalTime){
			timeMoving += Time.deltaTime;
			platform1.rigidbody.MovePosition(originalPosition1 + timeMoving/totalTime * platform1Change);
			platform2.rigidbody.MovePosition(originalPosition2 + timeMoving/totalTime * platform2Change);
			yield return null;
		}

		platform1.rigidbody.MovePosition(originalPosition1 + platform1Change);
		platform2.rigidbody.MovePosition(originalPosition2 + platform2Change);
	}

	IEnumerator MoveBack(){
		float timeMoving = totalTime;
		
		while(timeMoving > 0){
			timeMoving -= Time.deltaTime;
			platform1.rigidbody.MovePosition(originalPosition1 + timeMoving/totalTime * platform1Change);
			platform2.rigidbody.MovePosition(originalPosition2 + timeMoving/totalTime * platform2Change);
			yield return null;
		}
		
		platform1.rigidbody.MovePosition(originalPosition1);
		platform2.rigidbody.MovePosition(originalPosition2);
	}
}
