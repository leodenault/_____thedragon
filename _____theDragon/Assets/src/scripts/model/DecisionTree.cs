using System.Collections.Generic;


public static class DecisionTree {
	public interface Listener {
		void Notify(string currentId);
	}
	
	private static IDictionary<IDecisionTreeState, IDictionary<string, IDecisionTreeState>> stateChoiceToState;

	private static IDecisionTreeState start;
	private static IDecisionTreeState killDragon;
	private static IDecisionTreeState dragonKills;
	private static IDecisionTreeState talkToDragon;
	private static IDecisionTreeState talkandsingToDragon;
	private static IDecisionTreeState dragonSings;
	private static IDecisionTreeState turnintoDragon;
	private static IDecisionTreeState killDragonreturnHome;
	
	private static IDecisionTreeState current;

	private static bool init = false;

	private static ChoiceTracker choiceTracker;
	private static EpilogData epilogData;
	private static List<Listener> listeners;

	private string s1 = "";
	private string s2 = "You made the brave decision to fight the dragon";
	private string s3 = "Though you were brave, your action angered the dragon and he kills you";
	private string s4 = "You manages to keep calm infront of";
	private string s5;
	private string s6;
	private string s7;

	
	public static void Init() {
		if (!init) {
			stateChoiceToState = new Dictionary<IDecisionTreeState, IDictionary<string, IDecisionTreeState>>();
			choiceTracker = new ChoiceTracker();
			epilogData = new EpilogData(choiceTracker);
			listeners = new List<Listener>();
			
			initStates();
			setupChoices();
			init = true;
		}
	}
	
	private static void initStates() {
		start = new DecisionTreeState("start", s1);
		killDragon = new DecisionTreeState("kill dragon", s2);
		dragonKills = new DecisionTreeState("dragon kills", s3);
		talkToDragon = new DecisionTreeState("talk to dragon", s4);
		talkandsingToDragon = new DecisionTreeState("talk and sing to dragon", s5);
		dragonSings = new DecisionTreeState("dragon Sings", s6);
		turnintoDragon = new DecisionTreeState ("turn into dragon",s7);
		
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
		createChoice(start, "Kill the dragon!", killDragon);
		createChoice(start, "Talk to the dragon", talkToDragon);
		createChoice (killDragon, "Dragon Kills you!", dragonKills);
		createChoice (talkToDragon, "Sing to the dragon", talkandsingToDragon);
		createChoice(talkToDragon, "Kill the dragon and return Home", killDragonreturnHome);
		createChoice (talkandsingToDragon, "Dragon wants to sing", turnintoDragon);
		createChoice (talkandsingToDragon, "Kill the dragon and return Home", killDragonreturnHome);

	}
	
	private static void notifyListeners(string currentId) {
		foreach (Listener listener in listeners) {
			listener.Notify(currentId);
		}
	}
	
	public static void registerListener(Listener listener) {
		listeners.Add(listener);
	}
	
	public static List<string> GetChoices() {
		return current.GetChoices();
	}
	
	public static void SelectChoice(string choice) {
		choiceTracker.AddState(current);
		current = stateChoiceToState[current][choice];
		notifyListeners(current.GetId());
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
