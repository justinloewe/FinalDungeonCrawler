using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour {

    [Serializable]
    public struct InventoryTile {
        public Image imageRenderer;
        public Text countTextRenderer;
        public Text textRenderer;
    }

    [SerializeField]
    private InventoryTile[] tiles;

    public void UpdateUI(Dictionary<InventoryItem, int> inventory) {
        int i = 0;
        foreach (InventoryItem item in inventory.Keys) {
            if (i < tiles.Length) {
                tiles[i].imageRenderer.sprite = item.sprite;
                tiles[i].textRenderer.text = item.name;
                tiles[i].countTextRenderer.text = inventory[item].ToString();
            }
            i++;
        }

        for (int j = i; j < tiles.Length; j++) {
            tiles[j].imageRenderer.sprite = null;
            tiles[j].textRenderer.text = "";
            tiles[j].countTextRenderer.text = "";
        }
    }

}
