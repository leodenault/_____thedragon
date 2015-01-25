using UnityEngine;
using System.Collections;

public class TriggerDecision : MonoBehaviour, DecisionTree.Listener {

	public ChoicePanel choicePanel;
	public Canvas canvas;

	// Use this for initialization
	void Start ()
	{
		DecisionTree.registerListener(this);
		string[] options = {"NOPE", "LOL"};
		choicePanel.GenerateOptions(options);
		choicePanel.Display(true);
	}
	
	public void Notify(string currentId) {
		Debug.Log(choicePanel);
		choicePanel.Display(false);
		Debug.Log("LOL");
	}
}
