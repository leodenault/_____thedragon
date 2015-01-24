using System.Collections.Generic;

public class DecisionTreeState : IDecisionTreeState {
	private string info;
	private string id;
	private List<string> choices;
	
	public DecisionTreeState(string id, string info) {
		this.id = id;
		this.info = info;
		this.choices = new List<string>();
	}
	
	public string GetStateEpilogue() {
		return info;
	}
	
	public string GetId() {
		return id;
	}
	
	public void AddChoice(string choice) {
		choices.Add(choice);
	}
	
	public List<string> GetChoices() {
		return choices;
	}
}
