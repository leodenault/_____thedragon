using UnityEngine;
using System.Collections;

public class DialogueDisplay : MonoBehaviour {

	public int dialogueNumber;
	public int displayedChars;
	public string dialogue;
	public int textWidth = 20;

	// Use this for initialization
	void Start () {
		displayedChars = 0;
		dialogue = "";
		//put character into dialogue state
		//check if the dialogue has options?
		//determine which text to display
		//bring up dialogue box
		//bring up portriat?
		displaytext ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	string getDialogue(int dialogueNumber) {
		//get the correct text from another function
		return ""; //placeholder
	}
	
	int getNumChars (int dialogueNumber, int stringMarker) {
		//get the correct number of characters to display on the screen
		int charNum = 0;
		int place = stringMarker;
		bool done = false;
		while (!done) {
			while (!(dialogue[place].Equals (' ')) && dialogue.Length > place) {
				place++;
			}
			if (charNum + place > textWidth || place >= dialogue.Length) {
				return charNum;
			} else {
				charNum = charNum + place;
			}
		}
		return charNum;
	}
	
	void displaytext () {
		//Rect textBoxArea;
		Rect textBoxArea = Rect.MinMaxRect (0, 0, Screen.width, Screen.height/4);
		//textBoxArea.y = 0;
		//textBoxArea.width = Screen.width;
		//textBoxArea.height = Screen.height/4;
		bool done = false;
		int dialogueMarker = 0; //where you are in the string
		dialogue = getDialogue (dialogueNumber);
		int lineNum = 0; //how many lines of text are currently displayed
		int charNum = 0; //how many characters are currently displayed
		while (!done) {
			if (Input.GetKey(KeyCode.Return)) {
				while (lineNum < 2) {
					charNum = getNumChars(dialogueNumber, dialogueMarker);
					GUI.Box (textBoxArea,dialogue.Substring (dialogueMarker, charNum));
					dialogueMarker = dialogueMarker + charNum;
					if (dialogueMarker > dialogue.Length) {
						done = true;
						break;
					}
					lineNum++;
				}
			}
		}
		Rect emptyRect = Rect.MinMaxRect (0, 0, 0, 0);
		//emptyRect.x = 0;
		//emptyRect.y = 0;
		//emptyRect.width = 0;
		//emptyRect.height = 0;
		while (Input.GetKey(KeyCode.Return)) {
			GUI.Box (emptyRect, "");
		}
	}
}