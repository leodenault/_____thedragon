using UnityEngine;
using System.Collections;

public class DragonInitiator : MonoBehaviour {

	public ChoicePanel choicePanel;

	// Use this for initialization
	void Start () {
		TriggerDecision decision = new TriggerDecision(choicePanel);
		decision.Trigger();
	}
}
