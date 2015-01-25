using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public string[] database;
	public int size = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void load() {
		database = new string[size];
		database [0] = "Oh, hello there. The king must have sent you.";
		database [1] = "I'm sorry that I've stopped producing gold for the village.";
		database [2] = "You see, my newest egg didn't hatch, and I am still in mourning.";
		database [3] = "Please, kind stranger, sing me a lullaby to ease my pain?";
		database [4] = "";
		database [5] = "Thank you, kind stranger.";
		database [6] = "It aches a little less now, I think.";
		database [7] = "I would like to sing you a song of my own now, as thanks.";
		database [8] = "";
		database [9] = "The dragon song settles deep inside your belly,";
		database [10] = "and you begin to notice strang and wonderful things";
		database [11] = "changing within you. You close your eyes, and when you open them";
		database [12] = "You have become a dragon. You open your eyes to a new world,";
		database [13] = "a new life, and a new level of greatness for you to achieve.";
		database [14] = "";
		database [15] = "You sing the dragon a lullaby to the best of your ability.";
		database [16] = "It seems good enough for the creature, and so you say farewell.";
		database [17] = "";
		database [18] = "You thank the dragon, but you think you should return to thh king";
		database [19] = "as soon as possible no that your quest is complete.";
	}
}
