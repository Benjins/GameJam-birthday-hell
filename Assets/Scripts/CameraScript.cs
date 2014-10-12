using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public static bool isFollowing;
	public static string charFollowing;
	public GameObject Billy;
	public GameObject Brett;

	// Use this for initialization
	void Start () {
		isFollowing = false;
		charFollowing = "Billy";
		this.transform.parent = Billy.transform;
		this.transform.position = new Vector3(Billy.transform.position.x, Billy.transform.position.y, -40);
		AudioSource a = this.GetComponent<AudioSource> ();
		a.Play (0);
		//AudioSource.PlayClipAtPoint (music, transform.position);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("o")) {
			//switch characters
			if (charFollowing.Equals ("Billy")) {
				charFollowing = "Brett";
				this.transform.parent = Brett.transform;
				this.transform.position = new Vector3(Brett.transform.position.x, Brett.transform.position.y, -40);
			} 
			else {
				charFollowing = "Billy";
				this.transform.parent = Billy.transform;
				this.transform.position = new Vector3(Billy.transform.position.x, Billy.transform.position.y, -40);
			}
			Debug.Log ("switched when "+charFollowing+"'s y was "+this.transform.position.y);
		}
		if (Input.GetKeyDown ("p")) {
			//toggle follow me
			isFollowing = !isFollowing;
		}
	}
}
