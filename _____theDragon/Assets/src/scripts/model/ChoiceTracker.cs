using System.Collections.Generic;

public class ChoiceTracker : IChoiceTracker {
	private List<IDecisionTreeState> states;
	
	public ChoiceTracker() {
		this.states = new List<IDecisionTreeState>();
	}
	
	public IDecisionTreeState[] GetStates() {
		return states.ToArray();
	}
	
	public void AddState(IDecisionTreeState state) {
		states.Add(state);
	}
}
