using UnityEngine;
using System.Collections;

public class TriggerDecision : MonoBehaviour, DecisionTree.Listener {

	public ChoicePanel choicePanel;

	// Use this for initialization
	void Start ()
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
