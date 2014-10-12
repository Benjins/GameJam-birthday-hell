using UnityEngine;
using System.Collections;

public class MovingPlatforms : MonoBehaviour {

	Transform platform1;
	Transform platform2;

	public Vector3 platform1Change;
	public Vector3 platform2Change;

	// Use this for initialization
	void Start () {
		platform1 = transform.GetChild(0);
		platform2 = transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSwitched(bool state){
		if(state){
			platform1.position += platform1Change;
			platform2.position += platform2Change;
		}
		else{
			platform1.position -= platform1Change;
			platform2.position -= platform2Change;
		}
	}
}
