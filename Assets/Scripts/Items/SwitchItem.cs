using UnityEngine;
using System.Collections;

public class SwitchItem : MonoBehaviour {
	
	public Texture2D onSprite;
	public Texture2D offSprite;
	public GameObject target;

	//Setting activated will automatically switch the sprite
	bool activated{
		get{
			return Activated;
		}
		set{
			Activated = value;
			renderer.material.mainTexture = (Activated? onSprite : offSprite);
			if(target != null){
				target.SendMessage("OnSwitched", Activated, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	bool Activated = false;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player")
			activated = !activated;
	}
}
