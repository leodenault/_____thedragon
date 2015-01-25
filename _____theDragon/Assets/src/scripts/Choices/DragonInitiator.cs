using UnityEngine;
using System.Collections;

public class DragonInitiator : MonoBehaviour {

	public ChoicePanel choicePanel;
	public DialogueDisplay disp;
	bool displaying;
	public Sprite dragon;
	bool once,first, once2,once3,once4,once5,once6,once7,once8,once9;
	// Use this for initialization
	void Start () {
		once = true;
		once2 = true;
		once3 = true;
		once4 = true;
		once5 = true;
		once6 = true;
		once7 = true;
		once8 = true;
		once9 = true;

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
		if(DecisionTree.IsCurrentState("kill dragon"))
		{
			DecisionTree.GoToEnd();
			Application.LoadLevel("Epilogue");
		}
		if( DecisionTree.IsCurrentState("Kill dragon and return home"))
		Application.LoadLevel("Throne_Room");
		if(DecisionTree.IsCurrentState("talk and sing to dragon") && once3)
		{
			disp.displaytext(12);
			once3 =  false;
		}

		if(!once3 && !disp.displaying && once4)
		{
			disp.displaytext(7);
			once4 =  false;	
		}

		if(!once4 && !disp.displaying && once6)
		{
			disp.displaytext(8);
			once6 =  false;	
		}

		if(!disp.displaying && DecisionTree.IsCurrentState("talk and sing to dragon") && once5)
		{
			TriggerDecision decision = new TriggerDecision(choicePanel);
			decision.Trigger();
			once5 =  false;
		}

		if(DecisionTree.IsCurrentState("dragon Sings") && once7 && !once5 && !disp.displaying)
		{
			disp.displaytext(9);
			once7 = false;
		}

		if(!once7 && !disp.displaying && once8)
		{
			disp.displaytext(10);
			once8 =  false;	
		}

		if(!once8 && !disp.displaying && once9)
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite = dragon;
			disp.displaytext(11);
			once9 =  false;	
		}
		if(!once9 && !disp.displaying)
		{
			DecisionTree.GoToEnd();
			Application.LoadLevel("Epilogue");
		}
		Debug.Log(DecisionTree.getCurrentState());

	}
}
