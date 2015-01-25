using UnityEngine;
using System.Collections;

public class TriggerDecision : DecisionTree.Listener {

	ChoicePanel choicePanel;
	string[] test;
	public TriggerDecision(ChoicePanel choicePanel) {
		this.choicePanel = choicePanel;
	}

	public void Trigger()
	{
		
		DecisionTree.registerListener(this);
		test = DecisionTree.GetChoices().ToArray();
		choicePanel.GenerateOptions(test);
		choicePanel.Display(true);

	}
	
	public void Notify(string currentId) {
		choicePanel.Display(false);
	}
}
