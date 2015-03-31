using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {
	
	public string npcName = "";
	private string[,] dialogue = new string [100,2];
	private TextController textController;

	void Awake()
	{
		textController = GameObject.Find ("Scripts").GetComponent<TextController>();
	}

	public void SetupNPC(string name)
	{
		if(name.ToLower() == "jon")
		{
			npcName = name;
			dialogue [0, 0] = "";
			dialogue [0, 1] = "I don't know anything about";
			dialogue [1, 0] = "hello";
			dialogue [1, 1] = "Hello, how are you?";
		}
		if(name.ToLower() == "greg")
		{
			npcName = name;
			dialogue [0, 0] = "";
			dialogue [0, 1] = "What are you talking about? I know nothing about ";
			dialogue [1, 0] = "hello";
			dialogue [1, 1] = "What do you want? Can't you see I'm busy?";
		}
	}

	public void AskAbout(string input)
	{
		for(int i = 0; i < dialogue.Length; i++)
			{
				if(dialogue[i,0] != null)
				{
					if(dialogue[i,0].Length >= input.Length)
					{
						if(dialogue[i,0].Substring(0,input.Length) == input)
						{
							Response(i);
						}
					}
				}
			}	
		Response(0, input);
	}
	
	public string GetDesc()
	{
		//TODO: Add actual function
		return "This is a dummy description.";
	}

	public string GetInfo()
	{
		//ToDo: add individualized responses
		return "I don't know much.";
	}

	private void Response(int location, string input)
	{
		textController.AppendMain(dialogue[location,1] + input);
	}

	private void Response(int location)
	{
		textController.AppendMain(dialogue[location,1]);
	}

}
