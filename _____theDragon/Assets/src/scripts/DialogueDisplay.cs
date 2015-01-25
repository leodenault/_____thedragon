using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueDisplay : MonoBehaviour {

	public int dialogueNumber = 0;
	public int displayedChars;
	public string dialogue;
	public int textWidth = 40;
	public Text TextDisp;
	int spot;
	bool scrolling;
	// Use this for initialization
	void Start () {
		spot = 0;
		scrolling = false;
		displayedChars = 0;
		dialogue = "";
		TextDisp.text = dialogue;
		displaytext();
		//put character into dialogue state
		//check if the dialogue has options?
		//determine which text to display
		//bring up portriat?
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
				TextDisp.text = dialogue.Substring(0,spot);
				spot++;
			}
			else
			{
				scrolling = false;
			}
		}
	}

	string getDialogue(int dialogueNumber) {
		//get the correct text from another function
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
	
	public void displaytext () {

		bool done = false;
		bool pressed = false;
		int dialogueMarker = 0; //where you are in the string
		scrolling = true;
		dialogue = getDialogue (dialogueNumber);
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
		TextDisp.text = dialogue;
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
			//TextDisp.text = "Start!";
			//dialogue = getDialogue(0);
			//TextDisp.text = dialogue;
			//int i = getNumChars (0);
			//TextDisp.text = i.ToString();
			//TextDisp.text = dialogue.Substring(0, i) + "\n" + dialogue.Substring (i);
			//displayFragment (0);
			displaytext();
		}
	}

	void OnGUI () {

	}
}