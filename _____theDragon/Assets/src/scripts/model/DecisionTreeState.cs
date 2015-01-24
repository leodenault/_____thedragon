public class DecisionTreeState : IDecisionTreeState {
	private string info;
	
	public DecisionTreeState(string info) {
		this.info = info;
	}
	
	public string GetStateInfo() {
		return info;
	}
}
