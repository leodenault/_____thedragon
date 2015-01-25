﻿using UnityEngine;
using System.Collections;

public class DragonFight : MonoBehaviour {

	public DialogueDisplay disp;
	bool once = true;
	bool first = true;
	bool done = false;

	// Use this for initialization
	void Start () {
		DecisionTree.Init ();
		if (DecisionTree.IsCurrentState ("talk")) {
			disp.displaytext (5);
			bool once = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (!once && first && Input.GetKey (KeyCode.Space)) {
			disp.displaytext (6);
			first = false;
		} else if (!once && !first && Input.GetKey (KeyCode.Space) && !done) {
			disp.displaytext (7);
			done = true;
		}
	}
}