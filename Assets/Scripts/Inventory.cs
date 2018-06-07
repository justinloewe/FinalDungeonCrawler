using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    //public Image[] guiItemImages;
    public InventoryUIManager uiManager;
	private Dictionary<InventoryItem,int> items = new Dictionary<InventoryItem,int>();

	void Start()
	{
		UpdateView();
	}

	public bool AddItem(InventoryItem ip)
	{
		if (!items.ContainsKey(ip))
		{
			//if (items[ip] < guiItemImages.Length)
			items.Add(ip,1);
			//else
			//	return false;
		}
		else
		{
			items[ip]++;
		}
		UpdateView();
		return true;
	}

	public bool RemoveItem(InventoryItem ip)
	{
		if (items.ContainsKey(ip))
		{
			if (items[ip] > 0)
			{
				items[ip] --;

				if (items[ip] <= 0)
				{
					items.Remove(ip);
				}
				UpdateView();
				return true;
			}
		}
		return false;
	}

	void UpdateView()
	{
        uiManager.UpdateUI(items);
	}
}
