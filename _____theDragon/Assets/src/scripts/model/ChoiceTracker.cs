using System.Collections.Generic;

public class ChoiceTracker : IChoiceTracker {
	private List<IDecisionTreeState> states;
	
	public ChoiceTracker() {
		this.states = new List<IDecisionTreeState>();
	}
	
	public IDecisionTreeState[] getStates() {
		return states.ToArray();
	}
	
	public void addState(IDecisionTreeState state) {
		states.Add(state);
	}
}
