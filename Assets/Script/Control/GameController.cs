using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private string[] scriptNames = new string[]{"PrimarySwordmanScript","MediumGladiatorScript","GoodGladiatorScript"};
	public delegate void GameEndMessage();
	public static event GameEndMessage gameIsEnding;
	// Use this for initialization
	void Start () {
		scriptLoad();
		HealthScript.healthBecomeZero+=onGameEnd;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onGameEnd(){
		gameIsEnding();
	}
	public void scriptLoad(){
		for(int i=0;i<scriptNames.Length;i++){
			if(SelectEnemyScript.hardLevel==i){
				GameObject.Find("enemyRole").AddComponent(scriptNames[i]);
			}
		
		}
	}
}
