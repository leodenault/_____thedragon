using UnityEngine;
using System.Collections;

public class DragonInitiator : MonoBehaviour {

	public ChoicePanel choicePanel;
	public DialogueDisplay disp;
	bool displaying;
	bool once,first, once2,once3,once4;
	// Use this for initialization
	void Start () {
		once = true;
		once2 = true;
		once3 = true;
		once4 = true;
		first = false;
		if(DecisionTree.IsCurrentState("start"))
		{
			TriggerDecision decision = new TriggerDecision(choicePanel);
			decision.Trigger();
		}
	}

	void Update()
	{
		if(once && DecisionTree.IsCurrentState("talk to dragon"))
		{
			disp.displaytext(5);
			displaying = true;
			once = false;
			first = true;
		}

		if (first && (Input.GetKey (KeyCode.Space) || Input.GetKey("e")) && !disp.displaying) {
						disp.displaytext (6);
						first = false;

				}

		if(!first && !once && !disp.displaying && once2)
		{
			TriggerDecision decision = new TriggerDecision(choicePanel);
			decision.Trigger();
			once2 = false;
		}
		
		if( DecisionTree.IsCurrentState("Kill dragon and return home"))
		Application.LoadLevel("Throne_Room");
		if(DecisionTree.IsCurrentState("talk and sing to dragon") && once3)
		{
			disp.displaytext(7);
			once3 =  false;
		}

		if(!once3 && !disp.displaying && once4)
		{
			disp.displaytext(8);
			once4 =  false;	
		}
		//Debug.Log(DecisionTree.getCurrentState());

	}
}
