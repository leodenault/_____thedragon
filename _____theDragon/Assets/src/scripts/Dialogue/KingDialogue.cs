using UnityEngine;
using System.Collections;

public class KingDialogue : MonoBehaviour {

	public string[] database;
	public int size = 5;

	// Use this for initialization
	void Start () {
		load ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void load () {
		database = new string[size];
		database [0] = "There have been reports of a disturbance in the village";
		database [1] = "outside the grazing plains. Go Investigate.";
		database [2] = "";
		database [3] = "You make your way back to the king, who rewards you richly";
		database [4] = "for restoring balance to his kingdom.";
	}
}
