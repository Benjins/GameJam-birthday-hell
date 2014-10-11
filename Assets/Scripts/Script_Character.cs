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

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}

	
	void Update() {
		//if (this.transform.position.z != 0) {
			//transform.Translate(new Vector3(0, 0, -this.transform.position.z));
		//}
		if (!dead) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), moveDirection.y, 0);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection.x *= speed;
			if (controller.isGrounded) {
				if (Input.GetKey ("w"))
					moveDirection.y = jumpSpeed;
			}
			controller.Move (moveDirection * Time.deltaTime);
		} else {

		}
		moveDirection.y -= gravity * Time.deltaTime;
	}


}
