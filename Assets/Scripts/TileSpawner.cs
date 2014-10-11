using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MapType{
	public Color key;
	public GameObject tilePrefab;
}

public class TileSpawner : MonoBehaviour {

	public Texture2D tileMap;

	public List<MapType> colorKeys;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[ContextMenu("Spawn Tiles")]
	public void SpawnTiles(){
		if(tileMap != null || true){

			Dictionary<Color,GameObject> colorKeysDict = new Dictionary<Color, GameObject>();

			foreach(MapType elem in colorKeys){
				if(elem.tilePrefab == null){
					Debug.LogError("Null Tile Prefab in TileSpawner.colorKeys");
				}
				colorKeysDict.Add(elem.key, elem.tilePrefab);
			}

			foreach(Transform child in transform){
				DestroyImmediate(child.gameObject,false);
			}

			for(int x = 0; x < tileMap.width; x++){
				for(int y = 0; y < tileMap.height; y++){
					Color pixel = tileMap.GetPixel(x,y);
					GameObject prefab = null;

					//If the color is one we recognize
					if(colorKeysDict.ContainsKey(pixel)){
						prefab = colorKeysDict[pixel];
					}

					//Spawn the prefab
					if(prefab != null){
						GameObject tile = Instantiate(prefab, new Vector3(x,y,0), Quaternion.identity) as GameObject;
						tile.transform.parent = transform;
					}
				}
			}
		}
	}
}
