using System.Collections.Generic;
using UnityEngine;

public class ChoiceTracker : IChoiceTracker {
	private List<IDecisionTreeState> states;
	
	public ChoiceTracker() {
		this.states = new List<IDecisionTreeState>();
	}
	
	public IDecisionTreeState[] GetStates() {
		Debug.Log(states.Count);
		return states.ToArray();
	}
	
	public void AddState(IDecisionTreeState state) {
		Debug.Log(state.GetId());
		states.Add(state);
	}
}
