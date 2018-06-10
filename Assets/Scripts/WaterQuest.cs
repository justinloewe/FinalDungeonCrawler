using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterQuest : MonoBehaviour {

	public int eps = 10;
	//public GameObject finalBucket;
	public InventoryItem bucketInventoryItem;
	//private GUIText messageText;	//GUIElement
	private Text messageText;	//uGUI
	private string questMessage = "Suche einen Behälter,\n" +
		"um dieses saubere Wasser zu trinken.";
	private string questMessage2 = "Du brauchst einen leeren Behälter.";
	private bool gotQuest = false;
	private bool endedQuest = false;
	private string questEndedMessage = "<size=20>Gratulation!</size>\n" + 
		"Du hast die Aufgabe gelöst.";
	private GameObject player;
	private Inventory inventory;
	private PlayerController playerController;
	private EPController epController;

	void Start () {
		//finalBucket.SetActive(false);
		player = GameObject.FindGameObjectWithTag ("Player");
		playerController = player.GetComponent<PlayerController>();
		inventory = player.GetComponent<Inventory>();
		//messageText = GameObject.FindGameObjectWithTag ("Message").
		//	GetComponent<GUIText>();	//GUIElement
		messageText = GameObject.FindGameObjectWithTag ("Message").
			GetComponent<Text>();	//uGUI
		epController = GameObject.FindGameObjectWithTag("GameController").
			GetComponent<EPController>();

	}
	
	void OnTriggerEnter(Collider other) 
	{	
		if(other.gameObject == player)
		{
			if(inventory.RemoveItem(bucketInventoryItem))
			{

				//finalBucket.SetActive(true);
				//Runterfallenden Bucket erzeugen
				//Quaternion rot = new Quaternion();
				//Drehung des urspruenglichen Modells ausgleichen
				//rot.eulerAngles = new Vector3(-90,0,0);

				messageText.text = questEndedMessage;
				epController.AddPoints (eps);
				endedQuest = true;
			}
			else
			{
				if(endedQuest)
					messageText.text = "";
				if(gotQuest && !endedQuest)
					messageText.text = questMessage2;
				if(!gotQuest && !endedQuest)
					messageText.text = questMessage;
				gotQuest = true;
			}
		}
	}
	
	void OnTriggerExit(Collider other) 
	{	
		if(other.gameObject == player)
		{
			messageText.text = "";
		}
	}
}

