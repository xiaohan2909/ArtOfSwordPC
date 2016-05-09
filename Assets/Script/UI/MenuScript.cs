using UnityEngine;
using System.Collections;

	/// <summary>
	/// Title screen script
	/// </summary>
	public class MenuScript : MonoBehaviour
{
	private int buttonWidth = 150;
	private int labelWidth = 180;
	private int buttonHeight = Screen.height/10;
	private int authorLabelWidth =Screen.width/3;
	private int authorLabelHeight =Screen.height/6;
	void OnGUI()
	{

		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect LabelRect = new Rect(
			Screen.width / 2 - (labelWidth / 2),
			( Screen.height / 5) - (buttonHeight / 2),
			labelWidth,
			buttonHeight
			);
		Rect buttonRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			( 2*Screen.height / 6) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		Rect buttonRect2  = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			( 3*Screen.height / 6) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		Rect buttonRect3  = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			( 4*Screen.height / 6) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		Rect buttonRect4  = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			( 5*Screen.height / 6) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		Rect authorLabel  = new Rect(
			2*Screen.width / 3 ,
			( 5*Screen.height / 6),
			authorLabelWidth,
			authorLabelHeight
			);
		GUI.skin.label.fontSize=30;
		GUI.Label(LabelRect, LanguageScript.Instance.getKeyValue("gameTitle"));
		GUI.skin.label.fontSize=14;
		GUI.Label(authorLabel, LanguageScript.Instance.getKeyValue("authorInfo"));
		// Draw a button to start the game
		if(GUI.Button(buttonRect,LanguageScript.Instance.getKeyValue("startGame")))
		{
			Application.LoadLevel("SelectAI");
		}
		if(GUI.Button(buttonRect2,LanguageScript.Instance.getKeyValue("gameHelp")))
		{
			Application.LoadLevel("GameHelp");
		}
		if(GUI.Button(buttonRect3,LanguageScript.Instance.getKeyValue("changLanguage")))
		{	
			LanguageScript.Instance.changLanguage();
			Application.LoadLevel("StartMenu");
		}
		if(GUI.Button(buttonRect4,LanguageScript.Instance.getKeyValue("quitGame")))
		{	// On Click, 退出游戏
			Application.Quit(); 
		}
	}
}