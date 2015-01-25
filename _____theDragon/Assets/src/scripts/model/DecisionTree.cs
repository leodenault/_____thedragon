using System.Collections.Generic;


public static class DecisionTree {
	private static IDictionary<IDecisionTreeState, IDictionary<string, IDecisionTreeState>> stateChoiceToState;

	private static IDecisionTreeState start;
	private static IDecisionTreeState dragon;
	
	private static IDecisionTreeState current;

	private static bool init = false;

	private static ChoiceTracker choiceTracker;
	private static EpilogData epilogData;
	
	public static void Init() {
		if (!init) {
			stateChoiceToState = new Dictionary<IDecisionTreeState, IDictionary<string, IDecisionTreeState>>();
			choiceTracker = new ChoiceTracker();
			epilogData = new EpilogData(choiceTracker);
			
			initStates();
			setupChoices();
			init = true;
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
	
	public static void selectChoice(string choice) {
		choiceTracker.AddState(current);
		current = stateChoiceToState[current][choice];
	}
	
	public static string getCurrentState()
	{
		return current.GetId();
	} 

	public static bool IsCurrentState(string id) {
		return current.GetId().Equals(id);
	}
	
	public static string GetEpilogue() {
		return epilogData.print_epilog();
	}
}
