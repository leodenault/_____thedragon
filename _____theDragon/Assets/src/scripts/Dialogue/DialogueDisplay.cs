using UnityEngine;
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
		//loadarrays ();
		KDialog = new string[7];
		KDialog [0] = "There have been reports of a disturbance";
		KDialog [1] = "in the village across the grazing plains.";
		KDialog [2] = "I need you to go investigate.";
		KDialog [3] = "Do not fail me.";
		KDialog [4] = "";
		KDialog [5] = "You make your way back to the king, who rewards you richly";
		KDialog [6] = "for restoring balance to his kingdom.";
		EDialog = new string[5];
		EDialog [0] = "There is... zzz... a dragon ... in";
		EDialog [1] = "... the .. zzzzzz .. please.. help us...";
		EDialog [2] = "Zzzz... You must... zzzzzzzz... the dragon.";
		EDialog [3] = "Now go! Zzzzzzzzz... .. . .. . . .... ......";
		EDialog [4] = ".......................................";
		DDialog = new string[20];
		DDialog [0] = "Oh, hello there. The king must have sent you.";
		DDialog [1] = "I'm sorry that I've stopped producing gold for the village.";
		DDialog [2] = "You see, my newest egg didn't hatch, and I am still in mourning.";
		DDialog [3] = "Please, kind stranger, sing me a lullaby to ease my pain?";
		DDialog [4] = "";
		DDialog [5] = "Thank you, kind stranger.";
		DDialog [6] = "It aches a little less now, I think.";
		DDialog [7] = "I would like to sing you a song of my own now, as thanks.";
		DDialog [8] = "";
		DDialog [9] = "The dragon song settles deep inside your belly,";
		DDialog [10] = "and you begin to notice strange and wonderful things";
		DDialog [11] = "changing within you. You close your eyes, and when you open them";
		DDialog [12] = "You have become a dragon. You open your eyes to a new world,";
		DDialog [13] = "a new life, and a new level of greatness for you to achieve.";
		DDialog [14] = "";
		DDialog [15] = "You sing the dragon a lullaby to the best of your ability.";
		DDialog [16] = "It seems good enough for the creature, and so you say farewell.";
		DDialog [17] = "";
		DDialog [18] = "You thank the dragon, but you think you should return to the king";
		DDialog [19] = "as soon as possible now that your quest is complete.";
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
			if(Input.GetKeyDown(KeyCode.Space))
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
		if (dialogueNumber == 5) {
			return DDialog [0] + "\n" + DDialog [1];
		}
		if (dialogueNumber == 6) {
			return DDialog [2] + "\n" + DDialog [3];
		}
		if (dialogueNumber == 7) {
			return DDialog[5]+"\n"+DDialog[6];
		}
		if (dialogueNumber == 8) {
			return DDialog[7];
		}
		if (dialogueNumber == 9) {
			return DDialog [9];
		}
		if (dialogueNumber == 10) {
			return DDialog[10]+"\n"+DDialog[11];
		}
		if (dialogueNumber == 11) {
			return DDialog[12]+"\n"+DDialog[13];
		}
		if (dialogueNumber == 12) {
			return DDialog[15]+"\n"+DDialog[16];
		}
		if (dialogueNumber == 13) {
			return DDialog[18]+"\n"+DDialog[19];
		}

		if (dialogueNumber == 14) {
			return KDialog[5]+"\n"+KDialog[6];
		}
		return ""; //placeholder
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
		TextDisp.transform.active = true;
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

	/*void loadarrays() {
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
		DDialog = new string[20];
		DDialog [0] = "Oh, hello there. The king must have sent you.";
		DDialog [1] = "I'm sorry that I've stopped producing gold for the village.";
		DDialog [2] = "You see, my newest egg didn't hatch, and I am still in mourning.";
		DDialog [3] = "Please, kind stranger, sing me a lullaby to ease my pain?";
		DDialog [4] = "";
		DDialog [5] = "Thank you, kind stranger.";
		DDialog [6] = "It aches a little less now, I think.";
		DDialog [7] = "I would like to sing you a song of my own now, as thanks.";
		DDialog [8] = "";
		DDialog [9] = "The dragon song settles deep inside your belly,";
		DDialog [10] = "and you begin to notice strang and wonderful things";
		DDialog [11] = "changing within you. You close your eyes, and when you open them";
		DDialog [12] = "You have become a dragon. You open your eyes to a new world,";
		DDialog [13] = "a new life, and a new level of greatness for you to achieve.";
		DDialog [14] = "";
		DDialog [15] = "You sing the dragon a lullaby to the best of your ability.";
		DDialog [16] = "It seems good enough for the creature, and so you say farewell.";
		DDialog [17] = "";
		DDialog [18] = "You thank the dragon, but you think you should return to thh king";
		DDialog [19] = "as soon as possible no that your quest is complete.";
	}*/
}
