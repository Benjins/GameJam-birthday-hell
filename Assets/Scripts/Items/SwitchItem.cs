using UnityEngine;
using System.Collections;

public class SwitchItem : MonoBehaviour {
	
	public Sprite onSprite;
	public Sprite offSprite;
	public GameObject target;

	SpriteRenderer spriteRenderer;

	//Setting activated will automatically switch the sprite
	bool activated{
		get{
			return Activated;
		}
		set{
			Activated = value;
			spriteRenderer.sprite = (Activated? onSprite : offSprite);
			if(target != null){
				target.SendMessage("OnSwitched", Activated, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	bool Activated = false;

	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player")
			activated = !activated;
	}
}
