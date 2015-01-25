using UnityEngine;
using System.Collections;

public class InitDecisionTree : MonoBehaviour {

	// Use this for initialization
	public DialogueDisplay disp;
	bool once = true;
	void Start () 
	{
		
		DecisionTree.Init();
		if(DecisionTree.IsCurrentState("start"))
		disp.displaytext(0);
		once = false;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
