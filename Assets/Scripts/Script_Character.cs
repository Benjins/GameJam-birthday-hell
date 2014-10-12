using UnityEngine;
using System.Collections;

//SCRIPT FROM UNITY DOCS http://docs.unity3d.com/Documentation/ScriptReference/CharacterController.Move.html


public class Script_Character : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public bool dead = false;
	public CharacterController controller;
	public GameObject follower;

	CameraScript cameraScript;

	// Use this for initialization
	void Start () {
		cameraScript = Camera.main.GetComponent<CameraScript>();
		controller = GetComponent<CharacterController> ();
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Player")){
			if(obj != gameObject){
				follower = obj;
				break;
			}
		}
	}

	
	void Update() {

		if (!dead) {
			if( (gameObject == cameraScript.Billy) == (CameraScript.charFollowing.Equals("Billy"))){
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), moveDirection.y, 0);
				moveDirection = transform.TransformDirection (moveDirection);
				moveDirection.x *= speed;
				if (controller.isGrounded) {
					if (Input.GetKey ("w")){
						moveDirection.y = jumpSpeed;
					}
				}
				controller.Move (moveDirection * Time.deltaTime);
			}
			else {
				if (transform.position.x > follower.transform.position.x + 2) {
					//youre to the right, so move left
					moveDirection = new Vector3 (-speed, moveDirection.y, 0);
				}
				else if (transform.position.x < follower.transform.position.x - 2) {
					//youre to the left, so move right
					moveDirection = new Vector3 (speed, moveDirection.y, 0);
				}
				else {
					moveDirection = new Vector3 (0, moveDirection.y, 0);
				}
				if (transform.position.y < (follower.transform.position.y - 1)) {
					//jump
					if (controller.isGrounded) {
						moveDirection.y = jumpSpeed;
						Debug.Log ("AI Jumped");
					}
				}
				controller.Move (moveDirection * Time.deltaTime);
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;
	}


}
