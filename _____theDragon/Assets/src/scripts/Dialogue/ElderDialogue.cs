using UnityEngine;
using System.Collections;

public class ElderDialogue : MonoBehaviour {

	public string[] database;
	public int size = 5;
	// Use this for initialization
	void Start () {
		load ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void load(){
		database = new string[size];
		database [0] = "There is a ...... dragon ......";
		database [1] = "in the ...... please help us ......";
		database [2] = ". . . You must ...... the dragon.";
		database [3] = "... .. . .. . . .... ...... .... ... ...............";
		database [4] = ".......................................";
	}
}
