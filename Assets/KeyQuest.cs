using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyQuest : MonoBehaviour {

	public int eps = 13;
	//public GameObject finalBucket;
	public InventoryItem goldenKeyInventoryItem;
	//private GUIText messageText;	//GUIElement
	private Text messageText3;	//uGUI
	private string questMessage = "Bringe den goldenen Schlüssel,\n" +
		"vom anderen Ende des Labyrinths her.";
	private string questMessage2 = "Finde den goldenen Schlüssel.";
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
		messageText3 = GameObject.FindGameObjectWithTag ("Message").
			GetComponent<Text>();	//uGUI
		epController = GameObject.FindGameObjectWithTag("GameController").
			GetComponent<EPController>();

	}

	void OnTriggerEnter(Collider other) 
	{	
		if(other.gameObject == player)
		{
			if(inventory.RemoveItem(goldenKeyInventoryItem))
			{

				//finalBucket.SetActive(true);
				//Runterfallenden Bucket erzeugen
				//Quaternion rot = new Quaternion();
				//Drehung des urspruenglichen Modells ausgleichen
				//rot.eulerAngles = new Vector3(-90,0,0);

				messageText3.text = questEndedMessage;
				epController.AddPoints (eps);
				endedQuest = true;
			}
			else
			{
				if(endedQuest)
					messageText3.text = "";
				if(gotQuest && !endedQuest)
					messageText3.text = questMessage2;
				if(!gotQuest && !endedQuest)
					messageText3.text = questMessage;
				gotQuest = true;
			}
		}
	}

	void OnTriggerExit(Collider other) 
	{	
		if(other.gameObject == player)
		{
			messageText3.text = "";
		}
	}
}
