using System.Collections.Generic;

public static class DecisionTree {
	private static IDecisionTreeState start;
	
	private static IDecisionTreeState current;
	
	public static void Init() {
		initStates();
		setupChoices();
	}
	
	private static void initStates() {
		start = new DecisionTreeState("");
		
		current = start;
	}
	
	private static void setupChoices() {
		start.AddChoice("LOL");
		start.AddChoice("NOPE");
	}
	
	public static List<string> GetChoices() {
		return current.GetChoices();
	}


}
