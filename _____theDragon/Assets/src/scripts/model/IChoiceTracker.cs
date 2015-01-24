public interface IChoiceTracker {
	IDecisionTreeState[] GetStates();
	void AddState(IDecisionTreeState id);
}
