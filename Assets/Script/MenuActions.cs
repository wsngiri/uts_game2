using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActions : MonoBehaviour {

	public void MENU_ACTIONS_GotoPage (string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
}
