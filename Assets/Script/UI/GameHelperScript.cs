using UnityEngine;
using System.Collections;

public class GameHelperScript : MonoBehaviour {

	private int buttonWidth =  Screen.width/3;
	private int labelWidth = Screen.width/2;
	private int buttonHeight = Screen.height/10;
	private int labelHeight = 2*Screen.height/3;
	void OnGUI()
	{
		GUI.skin.label.fontSize=15;
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect LabelRect = new Rect(
			Screen.width / 2 - (labelWidth / 2),
			( Screen.height / 7) - (buttonHeight / 2),
			labelWidth,
			labelHeight
			);
		Rect buttonRect2  = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			( 6*Screen.height / 7) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		
		GUI.Label(LabelRect, LanguageScript.Instance.getKeyValue("basicOperation"));
		// Draw a button to start the game
		if(GUI.Button(buttonRect2,LanguageScript.Instance.getKeyValue("backToMenu")))
		{
			// On Click, 回主菜单
			Application.LoadLevel("StartMenu");
		}
	}
}
