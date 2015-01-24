using System.Collections.Generic;

public static class DecisionTree {
	private static IDictionary<IDecisionTreeState, IDictionary<string, IDecisionTreeState>> stateChoiceToState;
	
	private static IDecisionTreeState start;
	private static IDecisionTreeState dragon;
	
	private static IDecisionTreeState current;
	
	private bool initialized = false;
	
	public static void Init() {
		if (!initialized) {
			stateChoiceToState = new Dictionary<IDecisionTreeState, IDictionary<string, IDecisionTreeState>>();
			initStates();
			setupChoices();
			initialized = true;
		}
	}
	
	private static void initStates() {
		start = new DecisionTreeState("start", "");
		dragon = new DecisionTreeState("dragon", "");
		
		current = start;
	}
	
	private static void createChoice(IDecisionTreeState state, string choice, IDecisionTreeState nextState) {
		state.AddChoice(choice);
		
		if (!stateChoiceToState.ContainsKey(state)) {
			stateChoiceToState.Add(state, new Dictionary<string, IDecisionTreeState>());
		}
		stateChoiceToState[state].Add(choice, nextState);
	}
	
	// Here's where the magic happens
	private static void setupChoices() {
		createChoice(start, "LOL", dragon);
		createChoice(start, "NOPE", start);
	}
	
	public static List<string> GetChoices() {
		return current.GetChoices();
	}
	
	public static void SelectChoice(string choice) {
		current = stateChoiceToState[current][choice];
	}
	
	public static bool IsCurrentState(string id) {
		return current.GetId().Equals(id);
	}
}
