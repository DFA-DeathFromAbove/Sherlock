using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class TextController : MonoBehaviour {

	public Text mainOut;
	public Text mainIn;
	public Text locationText;
	public Text playerNameText;
	
	public string gameState;

	public Inventory inventory;
	
	private Player player;
	private Commands commands;
	private Maps maps;
	
	void Start()
	{
		maps = gameObject.GetComponent<Maps>();
		player = gameObject.GetComponent<Player>();
		commands = gameObject.AddComponent<Commands>();
		inventory = gameObject.AddComponent<Inventory>();
		EventSystem.current.SetSelectedGameObject(mainIn.transform.parent.gameObject);
		playerNameText.text = player.playerName;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Return))
		{
			PushInput(mainIn.text);
			//mainOut.text += "\n" + mainIn.text;
			mainIn.transform.parent.GetComponent<InputField>().text = "";
			EventSystem.current.SetSelectedGameObject(mainOut.gameObject); //Silly code needed for SetSelectedGameObject to refresh
			EventSystem.current.SetSelectedGameObject(mainIn.transform.parent.gameObject);
		}
		if(mainOut.text.Length > 10000)
		{
			mainOut.text = mainOut.text.Substring(2000);
		}
	}
	
	public Maps GetMaps()
	{
		return maps;
	}
	
	public void PushInput(string input)
	{
		if(input.Length < 1)
		{
			return;
		}
		List<string> inputArray = input.ToLower().Split(' ').ToList();
		List<string> updatedArray = new List<string>();
		foreach(string parsedIn in inputArray)
		{
			string updatedIn = parsedIn.Trim(' ');
			if(updatedIn != "")
			{
				updatedArray.Add(updatedIn);
			}
		}
		updatedArray.TrimExcess();
		ParseInput(updatedArray);
	}
	
	private void Swap(double[,] subjectArray, int a, int b)
	{
		double weight = subjectArray[a,0];
		double value = subjectArray[a,1];
		subjectArray[a,0] = subjectArray[b,0];
		subjectArray[a,1] = subjectArray[b,1];
		subjectArray[b,0] = weight;
		subjectArray[b,1] = value;
	}
	
	private void ParseInput(List<string> inputArray)
	{
		if(inputArray[0] == "knapsack")
		{
			double[,] itemTable = new double[,] {{0.29, 99},{0.34, 104},{0.45, 161},{0.22,55},{0.71,321},{0.13,29},{0.39,103},{0.23,76},{0.33,89},{0.05,71},{0.02,10},{0.5,200}};
			for(int i = 0; i < 11; i++)
			{
				if(itemTable[i,1]/itemTable[i,0] < itemTable[i+1,1]/itemTable[i+1,0])
				{
					Swap(itemTable, i, i+1);
				}
			}
		}
		string combinedInput = "";
		foreach(string parsedIn in inputArray)
		{
			combinedInput += parsedIn;
			if(inputArray.Last<string>() != parsedIn)
			{
				combinedInput += " ";
			}
		}
		AppendMain(">"+combinedInput);
		if(gameState == "find occurance")
		{
			string[] inputs = mainIn.text.ToLower().Split(':');
			string[] searched = inputs[1].Split(new string[] {inputs[0]}, System.StringSplitOptions.None);
			string locations = "";
			int position = 0;
			foreach(string myString in searched)
			{
				locations += (position + myString.Length) + ", ";
				position+=myString.Length;
			}
			AppendMain(inputs[0] + " was found " + searched.Length + " times at " + locations);
			gameState = "Default";
			return;
		}
		if(mainIn.text.ToLower() == "reset")
		{
			SetGameState ("Reset");
			AppendMain ("Are you sure you want to delete everything and start a new character? (Yes/No)");
			return;
		}
		if(gameState == "New Player")
		{
			player.playerName = mainIn.text;
			AppendMain ("Are you sure you want to name your character '"+player.playerName+"'? (Yes/No)");
			gameState = "Name Confirmation";
			return;
		}
		if(gameState == "Name Confirmation")
		{
			if(mainIn.text.ToLower() == "yes" || mainIn.text.ToLower() == "ye" || mainIn.text.ToLower() == "y")
			{
				AppendMain ("Welcome to the case, "+player.playerName+".");
				gameState = "Default";
				maps.SetActive("main",0);
				playerNameText.text = player.playerName;
				return;
			}
			else if(mainIn.text.ToLower() == "no" || mainIn.text.ToLower() == "n")
			{
				AppendMain("What is your name?");
				gameState = "New Player";
				return;
			}
			else
			{
				AppendMain("Please type yes or no.");
				return;
			}
		}
		if (gameState == "End Confirmation")
		{

			if(mainIn.text.ToLower() == "yes" || mainIn.text.ToLower() == "ye" || mainIn.text.ToLower() == "y")
			{
				AppendMain ("Please choose which suspect is the murderer: Richard or Gerard?");
				gameState = "Accusation";
				return;
			}
			else if(mainIn.text.ToLower() == "no" || mainIn.text.ToLower() == "n")
			{
				AppendMain("I think I'll come back when I have enough information.");
				gameState = "Default";
				return;
			}
			else
			{
				AppendMain("Please type yes or no.");
				return;
			}

		}
		if (gameState == "Accusation") 
		{
			
			if(mainIn.text.ToLower() == "richard")
			{
				AppendMain("After thorough investigation, I've gathered enough evidence to say that Richard is the killer. While the murder weapon did have Gerard's fingerprints on it, it's seen in the most recent scene of the film that Richard was wearing gloves. Yet in his moment of greed, he removed the gloves to better access the wallet in the director's pocket. As proof, in this safe should be the diamond! \n\nYou open to safe to find the large diamond that disappeared. Richard is convicted of murder and sentenced to prison.\nGOOD END");
				return;
			}
			else if(mainIn.text.ToLower() == "gerard")
			{
				AppendMain("After thorough investigation, I believe that Gerard is the true killer. After being constantly pressured by the director for perfection and receiving much critisism, he finally snapped, using one of his tool to kill the director. His fingerprints are clearly on it, and as proof, the boot print in the shop matches the directors. \n\n The police arrest Gerard, who is constantly claiming he is innocent. Upon opening the safe you find that the diamond is not there, and during the arrest, Richard is nowhere to be seen.\nBAD END");
				return;
			}
			else
			{
				AppendMain("Please choose one of the suspects.");
				return;
			}
		}
		if(gameState == "Reset")
		{
			if(mainIn.text.ToLower() == "yes")
			{
				Reset();
				return;
			}
			else if(mainIn.text.ToLower() == "no")
			{
				player.Reset();
				Reset();
				return;
			}
			else
			{
				AppendMain("Please enter 'yes' or 'no'");
				return;
			}
		}
		if(gameState == "Default")
		{
			if(inputArray[0] == null)
			{
				AppendMain ("No Input");
				return;
			}
			if(commands.FindCommand(inputArray[0]) == "Not Found")
			{
				AppendMain (combinedInput + " is not understood.");
				return;
			}
			if(commands.FindCommand(inputArray[0]) == "up")
			{
				if(maps.ActiveRoom().up == null)
				{
					AppendMain ("You find not a single exit above you.");
					return;
				}
				else
				{
					AppendMain ("You go up.");
					maps.SetActive(maps.ActiveRoom().up);
					return;
				}
			}
			if(commands.FindCommand(inputArray[0]) == "down")
			{
				if(maps.ActiveRoom().down == null)
				{
					AppendMain ("You find not a single exit below you.");
					return;
				}
				else
				{
					AppendMain ("You go down.");
					maps.SetActive(maps.ActiveRoom().down);
					return;
				}
			}
			if(commands.FindCommand(inputArray[0]) == "north")
			{
				if(maps.ActiveRoom().north == null)
				{
					AppendMain ("You find not a single exit to the north.");
					return;
				}
				else
				{
					AppendMain ("You move north.");
					maps.SetActive(maps.ActiveRoom().north);
					return;
				}
			}
			if(commands.FindCommand(inputArray[0]) == "east")
			{
				if(maps.ActiveRoom().east == null)
				{
					AppendMain ("You find not a single exit to the east.");
					return;
				}
				else
				{
					AppendMain ("You move east.");
					maps.SetActive(maps.ActiveRoom().east);
					return;
				}
			}
			if(commands.FindCommand(inputArray[0]) == "south")
			{
				if(maps.ActiveRoom().south == null)
				{
					AppendMain ("You find not a single exit to the south.");
					return;
				}
				else
				{
					AppendMain ("You move south.");
					maps.SetActive(maps.ActiveRoom().south);
					return;
				}
			}
			if(commands.FindCommand(inputArray[0]) == "west")
			{
				if(maps.ActiveRoom().west == null)
				{
					AppendMain ("You find not a single exit to the west.");
					return;
				}
				else
				{
					AppendMain ("You move west.");
					maps.SetActive(maps.ActiveRoom().west);
					return;
				}
			}
			if(commands.FindCommand(inputArray[0]) == "look")
			{
				if(inputArray.Count() <= 1)
				{
					AppendMain(maps.ActiveRoom().desc);
					AppendMain(maps.ActiveRoom().LookAround());
					return;
				}
				if(inputArray.Count() > 1)
				{
					int skip = 0;
					if(inputArray[1].ToLower() == "at")
					{
						skip++;
					}
					if(commands.FindNPC(inputArray[1+skip]) != null)
					{
						AppendMain(commands.FindNPC(inputArray[1+skip]).GetDesc());
						return;
					}
					if(commands.FindObject(inputArray[1+skip]) != null)
					{
						AppendMain(commands.FindObject(inputArray[1+skip]).Observe());
						return;
					}
					if(inputArray[1+skip].ToLower() == "inventory")
					{
						inventory.ListAll();
					}
					else
					{
						AppendMain("Look at what?");
					}
				}
			}
			if(commands.FindCommand(inputArray[0]) == "get")
			{
				if(inputArray[1] != null)
				{
					if(commands.FindObject(inputArray[1]) != null)
					{
						AppendMain (commands.FindObject(inputArray[1]).PickUp());
						if(commands.FindObject(inputArray[1]).PickUp() == "Added to inventory.")
						{
							inventory.AddInteractable(inputArray[1]);
							maps.ActiveRoom().DeleteInteractable(commands.FindObject(inputArray[1]));
						}
					}
					else
					{
						AppendMain("Get what?");
					}
				}
				else
				{
					AppendMain("Get what?");
				}
			}
			if(commands.FindCommand(inputArray[0]) == "find")
			{
				if(commands.FindCommand(inputArray[1]) == "occurance")
				{
					AppendMain ("Find occurance of what string?");
					SetGameState ("find occurance");
					return;
				}
				else
				{
					AppendMain("Find what?");
					return;
				}
			}
			if(commands.FindCommand(inputArray[0]) == "move")
			{
				if(inputArray.Count() <= 1)
				{
					AppendMain("Move what or where?");
					return;
				}
				if(inputArray.Count() > 1)
				{
					if(commands.FindObject(inputArray[1]) != null)
					{
						AppendMain(commands.FindObject(inputArray[1]).Interact());
						return;
					}
					else
					{
						AppendMain("Move what or where?");
						return;
					}
				}
			}
			if(commands.FindCommand(inputArray[0]) == "use")
			{
				if(inputArray.Count() <= 1)
				{
					AppendMain("Use what?");
					return;
				}
				if(inputArray.Count() == 2)
				{
					if(inventory.HasItem(inputArray[1]) == true)
					{
						AppendMain ("Use "+inputArray[1]+" on what?");
						return;
					}
					else
					{
						AppendMain ("You don't have " + inputArray[1] + ".");
						return;
					}
				}
				if(inputArray.Count() > 2)
				{
					int skip = 0;
					if(inputArray[1].ToLower () == "magnifying")
					{
						if(inputArray[1].ToLower() == "magnifying" && inputArray[2].ToLower() == "glass")
						{
							skip++;
						}
						if(inputArray[2+skip].ToLower() == "on")
						{
							skip++;
						}
						if(commands.FindObject(inputArray[2+skip]) != null)
						{
							AppendMain(commands.FindObject(inputArray[2+skip]).Magnify());
							return;
						}
					}
					if(inputArray[1].ToLower () == "fingerprint")
					{
						if(inputArray[1].ToLower() == "fingerprint" && inputArray[2].ToLower() == "kit")
						{
							skip++;
						}
						if(inputArray[2+skip].ToLower() == "on")
						{
							skip++;
						}
						if(commands.FindObject(inputArray[2+skip]) != null)
						{
							AppendMain(commands.FindObject(inputArray[2+skip]).Dust());
							return;
						}
						if(inventory.HasItem(inputArray[2+skip]) == true)
						{
							AppendMain(commands.FindInventory(inputArray[2+skip]).Dust());
							return;
						}
					}
					if(inputArray[1].ToLower() == "negatives" && inventory.HasItem("negatives") == true)
					{
						if(inputArray[2].ToLower() == "on")
						{
							skip++;
						}
						if(commands.FindObject(inputArray[2+skip]) != null)
						{
							AppendMain(commands.FindObject(inputArray[2+skip]).Chemical());
							return;
						}
					}
					if(inputArray[1].ToLower() == "filmreel" && inventory.HasItem("filmreel") == true)
					{
						if(inputArray[2+skip].ToLower() == "on")
						{
							skip++;
						}
						if(inputArray[2+skip].ToLower() == "projector")
						{
							AppendMain("You turn the projector on, and the screen starts to show images.");
							maps.ActiveRoom().AddInteractable("projection");
							inventory.DeleteInteractable(commands.FindObject("filmreel"));
							maps.ActiveRoom().DeleteInteractable(commands.FindObject("screen"));
							return;
						}
					}
					if(inputArray[1].ToLower() == "photos" && inventory.HasItem("photos") == true)
					{
						if(inputArray[2].ToLower() == "on")
						{
							skip++;
						}
						if(commands.FindObject(inputArray[2+skip]) != null)
						{
							commands.FindObject(inputArray[2+skip]).Win();
							return;
						}
					}
					else
					{
						AppendMain("You can't do that.");
						return;
					}
				}
			}
			if(commands.FindCommand(inputArray[0]) == "question")
			{
				int skip = 0;
				if(inputArray.Count() <= 1)
				{
					AppendMain("Question who?");
					return;
				}
				if(inputArray.Count() == 2)
				{
					if(commands.FindNPC(inputArray[1]) != null)
					{
						AppendMain(commands.FindNPC(inputArray[1]).GetInfo());
						return;
					}
					else
					{
						AppendMain("That person is not here.");
						return;
					}
				}
				if(inputArray.Count() > 2)
				{
					if(inputArray[2].ToLower() == "about")
					{
						skip++;
					}
					if(commands.FindNPC(inputArray[1]) != null && inputArray.Count() > 3 + skip)
					{
						commands.FindNPC(inputArray[1]).AskAbout(inputArray[2+skip]+" "+inputArray[3+skip]);
						return;
					}
					else if(commands.FindNPC(inputArray[1]) != null)
					{
						commands.FindNPC(inputArray[1]).AskAbout(inputArray[2+skip]);
						return;
					}
					else
					{
						AppendMain("That person is not here.");
						return;
					}
				}
			}
		}
	}
	
	private void Reset()
	{
		Application.LoadLevel ("main");
	}
	
	public void SetGameState(string newGameState)
	{
		gameState = newGameState;
	}
	
	public void AppendMain(string append)
	{
		mainOut.text = mainOut.text + "\n" + append;
	}
}
