using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

	private TextController textController;
	
	public string objectName = "";
	bool discovered = false;
	bool change = false;
	bool pickup = false;
	string desc = "";
	string changeDesc = "";
	string secret = "";
	string zoomDesc = "";
	
	public void Awake()
	{
		textController = GameObject.Find("Scripts").GetComponent<TextController>();
	}
	
	public void SetupObject(string name)
	{
		if(name.ToLower() == "door")
		{
			objectName = "door";
			discovered = false;
			change = false;
			desc = "This is a description of the object in question.";
			changeDesc = "The door has been opened.";
			zoomDesc = "There are small scratches on the door, but nothing important.";
		}
		
		if(name.ToLower () == "desk")
		{
			objectName = "desk";
			discovered = false;
			change = false;
			desc = "The desk is covered in film and scrpits.";
			changeDesc = "After pushing the desk aside, you discover a hidden passage.";
			secret = "Hidden Passage";
			zoomDesc = "One of the scripts has the name of the movie. It's called 'The Diamond Theif.' Ironic.";
		}
		if(name.ToLower () == "boot")
		{
			objectName = "boot";
			discovered = false;
			change = false;
			desc = "One of the director's. While the boot is clean, it certainly doesn't smell that way.";
		}
		if(name.ToLower () == "corpse")
		{
			objectName = "corpse";
			discovered = false;
			change = false;
			desc = "You see the corpse of the director here.  He lies motionless, his mouth agape with a silent scream.  A slash wound on his chest is a dark burgandy.  His neck has been sliced open.";
		}
		if(name.ToLower () == "wallet")
		{
			objectName = "wallet";
			discovered = false;
			change = false;
			desc = "This belongs to the director, and still has his ID in it. If there was any cash in it, it's gone now.";
		}
		if(name.ToLower () == "film reel")
		{
			objectName = "film reel";
			discovered = false;
			change = false;
			desc = "One of the scenes from 'The Diamond Theif.' If I had a camera, I could take a close look at the film";
		}
		if(name.ToLower () == "painting")
		{
			objectName = "painting";
			discovered = false;
			change = false;
			desc = "Some sort of post-modernism painting. The colors feel off, and the painting itself is atrocious.";
		}
		if(name.ToLower () == "hidden passage")
		{
			objectName = "hidden passage";
			discovered = false;
			desc = "The passage seems to lead into the courtyard.";
			zoomDesc = "The passage seems to lead into the courtyard. Nothing else is notable.";
		}
		if (name.ToLower () == "magnifying glass" || name.ToLower() == "magnifying") 
		{
			objectName = "magnifying glass";
			desc = "A magnifying glass. Use this to get a closer look at potential clues.";
		}
		if (name.ToLower () == "clue") 
		{
			objectName = "clue";
			desc = "This is a pickup object test to see if the pickup function works.";
			pickup = true;
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
			textController.GetMaps().ActiveRoom().AddInteractable(secret);
		}
		return changeDesc;
	}

	public string Magnify()
	{
		return zoomDesc;
	}

	public string PickUp()
	{
		if (pickup == false) 
		{
			return "You can't take this with you.";
		}
		else 
		{
			return "Added to inventory.";
		}
	}
}
