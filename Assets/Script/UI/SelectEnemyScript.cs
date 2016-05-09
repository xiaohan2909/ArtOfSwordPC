using UnityEngine;
using System.Collections;

public class SelectEnemyScript : MonoBehaviour {
	public static int hardLevel = 0;
	private  string[] aiNames=new string[]{"primaryGladiator","MediumGladiator","JuniorGladiator","returnMenu"};
	private  string[] levelNames=new string[]{"aniTest","aniTest","aniTest","StartMenu"};
	private  int buttonHeight = Screen.height/10;		
	void OnGUI()
	{
		const int buttonWidth = 150;
		LanguageScript.Instance.getKeyValue("");
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		Rect[] buttonRects =new Rect[4]; 
		for(int i=0; i<buttonRects.Length;i++){
			 buttonRects[i] = new Rect(
				Screen.width / 2 - (buttonWidth / 2),( (i+1)*Screen.height / 5) - (buttonHeight / 2),
				buttonWidth,buttonHeight );
			if(GUI.Button(buttonRects[i],LanguageScript.Instance.getKeyValue( aiNames[i])))
			{
				hardLevel=i;
				Application.LoadLevel(levelNames[i]);
			}
		}
	}
}
