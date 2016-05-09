using UnityEngine;
using System.Collections;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{
	public string winnerName="nobody";
	void OnGUI()
	{
		GUI.skin.label.fontSize=20;
		const int labelWidth = 250;
		const int buttonWidth = 120;
		const int buttonHeight = 60;
		Rect WordRect = new Rect(
			Screen.width / 2 - (labelWidth / 2),
			( Screen.height / 3) - (buttonHeight / 2),
			labelWidth,
			buttonHeight
			);
		GUI.Label(WordRect,winnerName+LanguageScript.Instance.getKeyValue("winTheGame")+"!");
		if (
				GUI.Button(
				// Center in X, 1/3 of the height in Y
					new Rect(
					Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 2) - (buttonHeight / 2),buttonWidth,buttonHeight),LanguageScript.Instance.getKeyValue("retry"))
			)
		{
			// Reload the level
			Application.LoadLevel("aniTest");
		}
		
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			LanguageScript.Instance.getKeyValue("backToMenu")
			)
			)
		{
			// Reload the level
			Application.LoadLevel("StartMenu");
		}
	}
}