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
	public bool onRope;

	CameraScript cameraScript;

	Animator anim;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		cameraScript = Camera.main.GetComponent<CameraScript>();
		anim = GetComponentInChildren<Animator>();
		onRope = false;
	}

	void FixedUpdate(){
		Vector3 position = transform.position;
		position.z = 0;
		transform.position = position;
	}
	
	void Update() {
		if (Application.loadedLevel == 2 && transform.position.y < 6) {
			Application.LoadLevel (Application.loadedLevel);
		}
		else if (Application.loadedLevel == 3 && transform.position.y < 9) {
			Application.LoadLevel (Application.loadedLevel);
		}

		if (!dead) {
			if ((CameraScript.charFollowing == "Billy") == (cameraScript.Billy == gameObject)) {
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), moveDirection.y, 0);
				moveDirection = transform.TransformDirection (moveDirection);
				moveDirection.x *= speed;

				if(anim){
					anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis ("Horizontal")));
				}

				if(Input.GetAxis ("Horizontal") != 0){
					transform.localScale = new Vector3( Mathf.Sign(Input.GetAxis ("Horizontal")), 
					                                    transform.localScale.y, 
					                                    transform.localScale.z);
				}

				if (controller.isGrounded || onRope) {
					if (Input.GetKey ("w")){
						moveDirection.y = jumpSpeed;
						if(anim){
							//anim.SetTrigger("Jump");
						}
					}
					else{
						if(anim){
							anim.SetTrigger("Land");
						}
					}
				}
				controller.Move (moveDirection * Time.deltaTime);
			}
			else {
				if(CameraScript.isFollowing){
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

					if (anim)
						anim.SetFloat("Speed", Mathf.Abs(moveDirection.x));

					if (this.transform.position.y < (follower.transform.position.y - 1)) {
						//jump
						if (controller.isGrounded || onRope) {
							moveDirection.y = jumpSpeed;
						}
					}

					if(moveDirection.x != 0){
						transform.localScale = new Vector3(Mathf.Sign(moveDirection.x), 
						                                   transform.localScale.y, 
						                                   transform.localScale.z);
					}
				}
				else{
					moveDirection.x = 0;
					if(anim){
						anim.SetFloat("Speed",0);
					}
				}
				controller.Move (moveDirection * Time.deltaTime);
			}
		}
		if (!controller.isGrounded) {
			moveDirection.y -= gravity * Time.deltaTime;
		} 
		else {
			moveDirection.y = 0;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Rope") {
			if (this.GetComponent<ItemCarrier> ().carriedItem == null) {
				onRope = true;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Rope") {
			onRope = false;
		}
	}


}
