using UnityEngine;
using System.Collections;

public class SwitchItem : ItemBase {

	public new bool useGravity = false;
	public Texture2D onSprite;
	public Texture2D offSprite;

	//Setting activated will automatically switch the sprite
	bool activated{
		get{
			return Activated;
		}
		set{
			Activated = value;
			renderer.material.mainTexture = (Activated? onSprite : offSprite);
		}
	}

	bool Activated = false;

	public override void OnPickup(ItemCarrier pickedUpBy){
		activated = !activated;
	}
}
