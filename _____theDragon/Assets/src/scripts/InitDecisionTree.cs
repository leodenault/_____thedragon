using UnityEngine;
using System.Collections;

public class InitDecisionTree : MonoBehaviour {

	// Use this for initialization
	public DialogueDisplay disp;
	bool once = true;
	bool first = true;
	bool done = false;
	public GameObject vil1, vil2;
	DecisionTree.Listener listener;
	void Start () 
	{
		
		DecisionTree.Init();
		DecisionTree.registerListener(listener);
		if (DecisionTree.IsCurrentState ("start")) {
			disp.displaytext (0);
			once = false;
		}
		else
		{
			if(DecisionTree.IsCurrentState("Kill dragon and return home"))
			{
				disp.displaytext(14);
				done = true;
				vil1.active = true;
				vil2.active = true;
			}

					}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if (first && Input.GetKey (KeyCode.Space) && DecisionTree.IsCurrentState ("start")) {
						disp.displaytext (1);
						first = false;
				}

				if(done && !disp.displaying)
			{
				Application.LoadLevel("Epilogue");
			}

	}
}
