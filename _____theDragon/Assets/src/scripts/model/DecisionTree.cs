using System.Collections.Generic;
using UnityEngine;

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
	
	private static IDecisionTreeState end;
	
	private static IDecisionTreeState current;

	private static bool init = false;

	private static ChoiceTracker choiceTracker;
	private static EpilogData epilogData;
	private static List<Listener> listeners;

	private static string s1 = "King asks you to face dragon and resolve the conflict";
	private static string s2 = "You made the brave decision to fight the dragon";
	private static string s3 = "Though you were brave, your action angered the dragon and he kills you";
	private static string s4 = "You manage to keep calm infront of dragon and start talking to him";
	private static string s5 = "Dragon asks you to sing for him and you accept it";
	private static string s6 = "Dragon is impressed by your attitude and sings for you in return";
	private static string s7 = "You have a very good conversation with dragon and he makes you a dragon";
	private static string s8 = "You do not trust dragon and kills him earning a handsome reward from the king";

	
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
		killDragonreturnHome = new DecisionTreeState ("Kill dragon and return home",s8);
		
		end = new DecisionTreeState("end", "");

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
		createChoice (talkandsingToDragon, "Dragon wants to sing", dragonSings);
		createChoice (dragonSings, "You become dragon", turnintoDragon);
		createChoice (talkandsingToDragon, "Kill the dragon and return Home", killDragonreturnHome);
	}
	
	private static void notifyListeners(string currentId) {
		foreach (Listener listener in listeners) {
			if(listener != null)
			listener.Notify(currentId);
		}
	}
	
	public static void registerListener(Listener listener) {
		if (!listeners.Contains(listener)) {
			listeners.Add(listener);
		}
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
	
	public static void GoToEnd() {
		choiceTracker.AddState(current);
		current = end;
	}
}
