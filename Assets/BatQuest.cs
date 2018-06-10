using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatQuest : MonoBehaviour {

	public int eps = 5;
	//public GameObject finalBucket;
	public InventoryItem wingsInventoryItem;
	//private GUIText messageText;	//GUIElement
	private Text messageText2;	//uGUI
	private string questMessage = "Töte die Fledermäuse,\n" +
		"mit diesen Steinen und bringe ihre Flügel her.";
	private string questMessage2 = "Besiege beide Gegner im Labyrinth.";
	private bool gotQuest = false;
	private bool startedQuest = false;
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
		messageText2 = GameObject.FindGameObjectWithTag ("Message").
			GetComponent<Text>();	//uGUI
		epController = GameObject.FindGameObjectWithTag("GameController").
			GetComponent<EPController>();

	}

	void OnTriggerEnter(Collider other) 
	{	
		if(other.gameObject == player)
		{
			if(!startedQuest && inventory.RemoveItem(wingsInventoryItem))
			{
				startedQuest = true;
				epController.AddPoints (eps);
			}
			if(startedQuest && inventory.RemoveItem(wingsInventoryItem))
			{
				//finalBucket.SetActive(true);
				//Runterfallenden Bucket erzeugen
				//Quaternion rot = new Quaternion();
				//Drehung des urspruenglichen Modells ausgleichen
				//rot.eulerAngles = new Vector3(-90,0,0);

				messageText2.text = questEndedMessage;
				epController.AddPoints (eps);
				endedQuest = true;
			}
			else
			{
				if(endedQuest)
					messageText2.text = "";
				if(gotQuest && !endedQuest)
					messageText2.text = questMessage2;
				if(!gotQuest && !endedQuest)
					messageText2.text = questMessage;
				gotQuest = true;
			}
		}
	}

	void OnTriggerExit(Collider other) 
	{	
		if(other.gameObject == player)
		{
			messageText2.text = "";
		}
	}
}