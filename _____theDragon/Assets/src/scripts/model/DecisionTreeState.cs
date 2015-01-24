using System.Collections.Generic;

public class DecisionTreeState : IDecisionTreeState {
	private string info;
	private List<string> choices;
	
	public DecisionTreeState(string info) {
		this.info = info;
		this.choices = new List<string>();
	}
	
	public string GetStateInfo() {
		return info;
	}
	
	public void AddChoice(string choice) {
		choices.Add(choice);
	}
	
	public List<string> GetChoices() {
		return choices;
	}
}
