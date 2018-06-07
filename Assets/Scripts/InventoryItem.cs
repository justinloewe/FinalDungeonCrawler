using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory Item")]
public class InventoryItem : ScriptableObject {

	public string itemName;
	public Sprite sprite;
	public AudioClip picSound;
	public GameObject prefab;

}
