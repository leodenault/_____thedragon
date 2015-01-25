﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueDisplay : MonoBehaviour {

	public int dialogueNumber = 0;
	public int displayedChars;
	public string dialogue;
	public int textWidth = 40;
	public Text TextDisp;
	float spot;
	public bool displaying;
	bool scrolling;
	string[] KDialog;
	string[] EDialog;
	string[] DDialog;
	//public KingDialogue KD;
	//public ElderDialogue ED;
	//public DragonDialogue DD;

	// Use this for initialization
	void Start () {
		displaying = false;
		spot = 0;
		scrolling = false;
		displayedChars = 0;
		dialogue = "";
		KDialog = new string[7];
		KDialog [0] = "There have been reports of a disturbance in";
		KDialog [1] = "in the village outside the grazing plains.";
		KDialog [2] = "I need you to go investigate.";
		KDialog [3] = "Do not fail me.";
		KDialog [4] = "";
		KDialog [5] = "You make your way back to the king, who rewards you richly";
		KDialog [6] = "for restoring balance to his kingdom.";
		EDialog = new string[5];
		EDialog [0] = "There is a ...... dragon ......";
		EDialog [1] = "in the ...... please help us ......";
		EDialog [2] = ". . . You must ...... the dragon.";
		EDialog [3] = "... .. . .. . . .... ...... .... ... ...............";
		EDialog [4] = ".......................................";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate()
	{
		if(scrolling)
		{
			if(spot < dialogue.Length)
			{
				TextDisp.text = dialogue.Substring(0,(int)spot);
				spot+= .5f;
			}
			else
			{
				scrolling = false;
				TextDisp.transform.parent.Find("Image").active = true;
			}
		}
		if(displaying && !scrolling)
		{
			if(Input.GetAxis("Interact") != 0)
			{
				displaying = false;
				spot = 0;
				TextDisp.transform.parent.Find("Image").active = false;
				TextDisp.transform.parent.active = false;
			}
		}
	}

	string getDialogue(int dialogueNumber) {
		//get the correct text from another function
		if(dialogueNumber == 0)
		{
			//KingDialogue KD;
			//KD.load ();
			return KDialog[0]+"\n"+KDialog[1];
		}
		if (dialogueNumber == 1) {
			return KDialog [2] + "\n" + KDialog [3];
		}
		if(dialogueNumber == 2)
		{
			//ElderDialogue ED;
			//ED.load ();
			return EDialog[0]+"\n"+EDialog[1];
		}
		if (dialogueNumber == 3) {
			//ElderDialogue ED;
			//ED.load ();
			return EDialog [2] + "\n" + EDialog [3];
		}
		if (dialogueNumber == 4) {
			//ElderDialogue ED;
			//ED.load ();
			return EDialog [4];
		}
		return "This is 20 char now. Let's see what happens when we add more characters. We'll see when we see. what happens when " +  
				"like i give the string a ridiculous amput of text, like way more thast we wou;d eeeeeeeeeever need, but its good to test this shot ya know?"; //placeholder
	}

	int getNumChars (int stringMarker) {
		//get the correct number of characters to display on the screen
		int charNum = textWidth;
		int place = stringMarker;
		string piece = "";
		bool tooShort = false;

		if (place+textWidth < dialogue.Length) {
			piece = dialogue.Substring (place, textWidth);
		} else {
			piece = dialogue.Substring(place);
			tooShort = true;
		}
		if (!tooShort) {
			for (; !(piece[charNum-1].Equals (' ')); charNum--) {
			}
		} else {
			charNum = piece.Length;
		}
		return charNum;
	}
	
	public void displaytext (int num) {

		//bool done = false;
		//bool pressed = false;
		//int dialogueMarker = 0; //where you are in the string
		scrolling = true;
		displaying = true;
		dialogue = getDialogue (num);
			TextDisp.text = dialogue;
		//TextDisp.text = "out of getDialogue";
		//int lineNum = 0; //how many lines of text are currently displayed
		//int charNum = 0; //how many characters are currently displayed
		/*while (!done) {
			dialogueMarker = displayFragment (dialogueMarker);
			if (dialogueMarker >= dialogue.Length) {
				done = true;
				break;
			}*/
			/*while (!pressed) {
				StartCoroutine (keyPress(pressed));
			}*/
		//}
		TextDisp.transform.parent.active = true;
	
	}

	IEnumerator keyPress (bool pressed) {
		if (Input.anyKey) {
			pressed = true;
			yield return new WaitForSeconds(0);
		}
		yield return new WaitForSeconds (5);
	}

	int displayFragment(int initial) {
		int length = getNumChars (initial);
		if (initial + length < dialogue.Length) {
			int length2 = getNumChars (initial + length);
			string fragment = dialogue.Substring (initial, length) + "\n" +
							  dialogue.Substring (initial + length, length2);
			TextDisp.text = fragment;
			return initial + length + length2;
		} else {
			string fragment = dialogue.Substring (initial, length);
			TextDisp.text = fragment;
			return initial + length;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.transform.tag == "Player" && !col.isTrigger) {
			displaytext(0);
		}
	}

	void OnGUI () {

	}
}