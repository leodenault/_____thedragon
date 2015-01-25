using UnityEngine;
using System.Collections;

public class TriggerDecision : MonoBehaviour, DecisionTree.Listener {

	public ChoicePanel choicePanel;

	// Use this for initialization
	void Start ()
	{
		DecisionTree.registerListener(this);
		string[] options = {"kill dragon", "talk to dragon"};
		choicePanel.GenerateOptions(options);
		choicePanel.Display(true);
	}
	
	public void Notify(string currentId) {
		choicePanel.Display(false);
	}
}
