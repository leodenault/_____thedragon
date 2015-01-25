using UnityEngine;
using System.Collections;

public class InitDecisionTree : MonoBehaviour {

	// Use this for initialization
	public DialogueDisplay disp;
	void Start () 
	{
		
		DecisionTree.Init();
		disp.displaytext(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
