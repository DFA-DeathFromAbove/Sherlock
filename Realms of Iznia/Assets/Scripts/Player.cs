using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	private TextController output;
	private Maps maps;
	
	public string playerName;
	
	// Use this for initialization
	void Awake()
	{
		output = gameObject.GetComponent<TextController>();
		maps = gameObject.GetComponent<Maps>();
		
		LoadPlayerPrefs();
		WelcomePlayer();
	}
	
	public void Reset()
	{
		playerName = "New Player";
		WelcomePlayer();
	}
	
	void WelcomePlayer()
	{
		if(playerName == "New Player")
		{
			output.AppendMain("The land of Iznia welcomes a new hero... \nWhat name do you take?");
			output.SetGameState("New Player");
		}
		else
		{
			output.AppendMain("The land of Iznia welcomes the return of the hero " + playerName + ".");
		}
	}
	
	void LoadPlayerPrefs()
	{
		playerName = PlayerPrefs.GetString("playerName", "New Player");
	}
}
