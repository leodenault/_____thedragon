using UnityEngine;
using System.Collections;

public class TriggerDecision : DecisionTree.Listener {

	ChoicePanel choicePanel;

	public TriggerDecision(ChoicePanel choicePanel) {
		this.choicePanel = choicePanel;
	}

	public void Trigger()
	{
		DecisionTree.registerListener(this);
		choicePanel.GenerateOptions(DecisionTree.GetChoices().ToArray());
		choicePanel.Display(true);
	}
	
	public void Notify(string currentId) {
		choicePanel.Display(false);
	}
}
