using UnityEngine;
using System.Collections;

public class SwitchItem : ItemBase {

	public new bool useGravity = false;
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
				target.SendMessage("OnSwitched", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	bool Activated = false;

	public override void OnPickup(ItemCarrier pickedUpBy){
		activated = !activated;
	}
}
