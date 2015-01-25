using UnityEngine;
using System.Collections;

public class InitDecisionTree : MonoBehaviour {

	// Use this for initialization
	public DialogueDisplay disp;
	bool once = true;
	bool first = true;
	DecisionTree.Listener listener;
	void Start () 
	{
		DecisionTree.Init();
		DecisionTree.registerListener(listener);
		if (DecisionTree.IsCurrentState ("start")) {
			disp.displaytext (0);
			once = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if (first && Input.GetKey (KeyCode.Space)) {
						disp.displaytext (1);
						first = false;
				}
	}
}
