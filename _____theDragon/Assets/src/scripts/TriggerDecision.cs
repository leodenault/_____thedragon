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
<<<<<<< HEAD
		string[] options = {"kill dragon", "talk to dragon"};
		choicePanel.GenerateOptions(options);
=======
		choicePanel.GenerateOptions(DecisionTree.GetChoices().ToArray());
>>>>>>> f60cff2762743ac9d9e625d48898a71a22ad88bc
		choicePanel.Display(true);
	}
	
	public void Notify(string currentId) {
		choicePanel.Display(false);
	}
}
