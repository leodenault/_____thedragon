using UnityEngine;
using System.Collections;

public class InitDecisionTree : MonoBehaviour {

	// Use this for initialization
	public DialogueDisplay disp;
	bool once = true;
	bool first = true;
	void Start () 
	{
		
		DecisionTree.Init();
		if (DecisionTree.IsCurrentState ("start"))
			disp.displaytext (0);

		//disp.displaytext(1);
		once = false;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if (first == true && Input.GetKey (KeyCode.Space)) {
						disp.displaytext (1);
						first = false;
				}
	}
}
