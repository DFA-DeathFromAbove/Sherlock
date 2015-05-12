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
			desc = "The desk is covered in film and scripts.";
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
			desc = "One of the scenes from 'The Diamond Thief.' If I had a camera, I could take a close look at the film";
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
		if(name.ToLower () == "safe")
		{
			objectName = "safe";
			discovered = false;
			change = false;
			desc = "A safe hidden behind the set. Requires a 3-digit passcode to open.";
		}
		if(name.ToLower () == "saw blade")
		{
			objectName = "saw blade";
			discovered = false;
			change = false;
			desc = "The murder weapon. It appears to be clean, but fingerprints might still linger.";
		}
		if(name.ToLower () == "camera")
		{
			objectName = "camera";
			discovered = false;
			change = false;
			desc = "A constant-wind camera. It appears to have some negatives inside the reel";
		}
		if(name.ToLower () == "set")
		{
			objectName = "set";
			discovered = false;
			change = false;
			desc = "The set resembles a high security bank, with a pedastal for the diamond.";
		}
		if(name.ToLower () == "camera stands")
		{
			objectName = "camera stands";
			discovered = false;
			change = false;
			desc = "Various cameras are pointed at the set.";
		}
		if(name.ToLower () == "negatives")
		{
			objectName = "negatives";
			discovered = false;
			change = false;
			desc = "Some undeveloped film. Until it's developed, I have no idea what it's for.";
		}
		if(name.ToLower () == "costumes")
		{
			objectName = "costumes";
			discovered = false;
			change = false;
			desc = "Used by the actors and actresses of the film. Full of various costumes.";
		}
		if(name.ToLower () == "boot print")
		{
			objectName = "boot print";
			discovered = false;
			change = false;
			desc = "This print seems somewhat old, but detailed in the saw dust.";
		}
		if(name.ToLower () == "cutting table")
		{
			objectName = "cutting table";
			discovered = false;
			change = false;
			desc = "This looks like a table used for measuring and cutting wood, but the saw blade is missing.";
		}
		if(name.ToLower () == "tool cabinet")
		{
			objectName = "tool cabinet";
			discovered = false;
			change = false;
			desc = "The cabinet is filled with variuos tools, from hammers to wood glue.";
		}
		if(name.ToLower () == "props")
		{
			objectName = "props";
			discovered = false;
			change = false;
			desc = "Several props, finished and unfinished, are laying about. There's extreme detail in the work.";
		}
		if(name.ToLower () == "projector")
		{
			objectName = "projector ";
			discovered = false;
			change = false;
			desc = "This projector is most likely used to test the film, and ensure that the movie looks like what the director has in mind.";
		}
		if(name.ToLower () == "screen")
		{
			objectName = "screen";
			discovered = false;
			change = false;
			desc = "The screen is blank, since the projector isn't running anything right now.";
		}
		if(name.ToLower () == "film canisters")
		{
			objectName = "film canisters";
			discovered = false;
			change = false;
			desc = "Various film canisters lie about, each with various labels.";
		}
		if(name.ToLower () == "ash tray")
		{
			objectName = "ash tray";
			discovered = false;
			change = false;
			desc = "The ash tray is cold, and hasn't been used recently. There's a used cigar resting in it.";
		}
		if(name.ToLower () == "chemical wash")
		{
			objectName = "chemical wash";
			discovered = false;
			change = false;
			desc = "This is a chemical wash used for developing negatives. The room has to be kept dark, otherwise the film is ruined.";
		}
		if(name.ToLower () == "costume rack")
		{
			objectName = "costume rack";
			discovered = false;
			change = false;
			desc = "The rack has various costume, from ball gowns to a thief outfit.";
		}
		if(name.ToLower () == "makeup tables")
		{
			objectName = "makeup tables";
			discovered = false;
			change = false;
			desc = "Various kinds of makeup are strewn across the tables.";
		}
		if(name.ToLower () == "mirrors")
		{
			objectName = "mirrors";
			discovered = false;
			change = false;
			desc = "The mirrors are lit up, allowing the actors to get a better view.";
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
