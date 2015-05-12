using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

	private TextController textController;
	
	public string objectName = "";
	bool discovered = false;
	bool change = false;
	string desc = "";
	string changeDesc = "";
	string secret = "";
	
	public void Awake()
	{
		textController = GameObject.Find("Scripts").GetComponent<TextController>();
	}
	
	public void SetupObject(string name)
	{
		if(name.ToLower() == "door")
		{
			objectName = "Door";
			discovered = false;
			change = false;
			desc = "This is a description of the object in question.";
			changeDesc = "The door has been opened.";
		}
		if(name.ToLower () == "table")
		{
			objectName = "Table";
			discovered = false;
			change = false;
			desc = "The table is covered in bottles and lab papers.";
			changeDesc = "After pushing the table aside, you discover a hidden passage.";
			secret = "Hidden Passage";
		}
		if(name.ToLower () == "hidden passage")
		{
			objectName = "Hidden Passage";
			discovered = false;
			desc = "The passage seems to lead into the courtyard.";
		}
		if(name.ToLower () == "film reel")
		{
			objectName = "Film Reel";
			discovered = false;
			desc = "A film reel from the nearby camera.";
			changeDesc = "After inserting the reel, a projection appears on the wall.";
		}
	}

	public string Observe()
	{
		if(discovered == false)
		{
			discovered = true;
		}
		return desc;
	}

	public string Interact()
	{
		if(change == false)
		{
			change = true;
		}
		if (secret != "") 
		{
//			SetupObject (secret);
			textController.GetMaps().ActiveRoom().AddInteractable(secret);
		}
		return changeDesc;
	}
}
