using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

	private TextController textController;
	private Commands commands;
	public Inventory inventory;
	
	public string objectName = "";
	bool discovered = false;
	bool change = false;
	bool pickup = false;
	bool magnified = false;
	bool fingerprint = false;
	bool chemical = false;
	bool photo = false;
	string dust = "";
	string detail = "";
	string detail2 = "";
	string desc = "";
	string changeDesc = "";
	string secret = "";
	string zoomDesc = "";
	
	public void Awake()
	{
		textController = GameObject.Find("Scripts").GetComponent<TextController>();
		commands = GameObject.Find ("Scripts").GetComponent<Commands>();
	}
	
	public void SetupObject(string name)
	{
		if(name.ToLower() == "door")
		{
			objectName = "door";
			discovered = false;
			change = false;
			pickup = false;
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
			detail = "filmreel";
			magnified = false;
			zoomDesc = "One of the scripts has the name of the movie. It's called 'The Diamond Thief.' Ironic. There's also a filmreel for the movie on it. Looks like the desk was moved recently...";
		}
		if(name.ToLower () == "boot")
		{
			objectName = "boot";
			discovered = false;
			change = false;
			pickup = true;
			desc = "One of the director's. While the boot is clean, it certainly doesn't smell that way.";
			zoomDesc = "Perhaps this sawdust came from the workshop.";
		}
		if (name.ToLower () == "director's chair") 
		{
			objectName = "director's chair";
			discovered = false;
			change = false;
			pickup = false;
			desc = "This is the chair the director uses when filming.";
			zoomDesc = "No more director now.";
		}
		if(name.ToLower () == "corpse")
		{
			objectName = "corpse";
			magnified = false;
			discovered = false;
			change = false;
			detail = "wallet";
			detail2 = "boot";
			desc = "You see the corpse of the director here.  He lies motionless, his mouth agape with a silent scream.  A slash wound on his chest is a dark burgandy.  His neck has been sliced open.";
			zoomDesc = "On the corpse's body, you find a wallet, and you see that his boots have some sawdust on them.";
		}
		if(name.ToLower () == "wallet")
		{
			objectName = "wallet";
			discovered = false;
			change = false;
			pickup = true;
			fingerprint = true;
			desc = "This belongs to the director, and still has his ID in it. If there was any cash in it, it's gone now.";
			dust = "The wallet has Richard's fingerprints on it.";
			zoomDesc = "There is the ID, but no money. The director was never one to carry extensive amounts of bills with him";
		}
		if(name.ToLower () == "filmreel")
		{
			objectName = "filmreel";
			discovered = false;
			change = false;
			pickup = true;
			fingerprint = true;
			desc = "One of the scenes from 'The Diamond Thief.' If I had a camera, I could take a close look at the film";
			dust = "The filmreel has Clara's fingerprints on it.";
			zoomDesc = "Perhaps a projector could magnify the images on the film";
		}
		if(name.ToLower () == "painting")
		{
			objectName = "painting";
			discovered = false;
			change = false;
			desc = "Some sort of post-modernism painting. The colors feel off, and the painting itself is atrocious.";
			zoomDesc = "It only gets uglier the closer you look.";
		}
		if(name.ToLower () == "hidden passage")
		{
			objectName = "hidden passage";
			discovered = false;
			desc = "The passage seems to lead down into a dingy storage room. (type 'd' to go down, 'u' to come back up)";
			zoomDesc = "The passage seems to lead into the storage room. Nothing else is notable.";
		}
		if(name.ToLower () == "safe")
		{
			objectName = "safe";
			discovered = false;
			change = false;
			photo = true;
			desc = "A safe hidden behind the set. Requires a 3-digit passcode to open.";
			zoomDesc = "There's got to be a passcode somewhere around here.";
		}
		if(name.ToLower () == "sawblade")
		{
			objectName = "sawblade";
			discovered = false;
			change = false;
			pickup = true;
			fingerprint = true;
			desc = "The murder weapon. It appears to be clean, but fingerprints might still linger.";
			dust = "The sawblade has Gerrard's fingerprints on it.";
			zoomDesc = "Sharp.";
		}
		if(name.ToLower () == "camera")
		{
			objectName = "camera";
			discovered = false;
			change = false;
			desc = "A constant-wind camera. It appears to have some negatives inside the reel";
			zoomDesc = "Those negatives are in a very prime and sensitive state.";
		}
		if(name.ToLower () == "set")
		{
			objectName = "set";
			discovered = false;
			change = false;
			detail = "safe";
			desc = "The set resembles a high security bank, with a pedastal for the diamond.";
			zoomDesc = "You see a bit of torn background. Behind it is a safe, with a three-digit lock.";
		}
		if(name.ToLower () == "camera stands")
		{
			objectName = "camera stands";
			discovered = false;
			change = false;
			desc = "Various cameras are pointed at the set.";
			zoomDesc = "One camera appears to be missing.";
		}
		if(name.ToLower () == "negatives")
		{
			objectName = "negatives";
			discovered = false;
			change = false;
			pickup = true;
			desc = "Some undeveloped film. Until it's developed, I have no idea what it's for.";
			zoomDesc = "I can't see what's on the negatives.";
		}
		if(name.ToLower () == "costumes")
		{
			objectName = "costumes";
			discovered = false;
			change = false;
			desc = "Used by the actors and actresses of the film. Full of various costumes.";
			zoomDesc = "Lots of fabric.";
		}
		if(name.ToLower () == "boot print")
		{
			objectName = "boot print";
			discovered = false;
			change = false;
			desc = "This print seems somewhat old, but detailed in the saw dust.";
			zoomDesc = "This print matches the boot print of the director.";
		}
		if(name.ToLower () == "cutting table")
		{
			objectName = "cutting table";
			discovered = false;
			change = false;
			desc = "This looks like a table used for measuring and cutting wood, but the sawblade is missing.";
			zoomDesc = "Lots of wood has been cut here.";
		}
		if(name.ToLower () == "tool cabinet")
		{
			objectName = "tool cabinet";
			discovered = false;
			change = false;
			desc = "The cabinet is filled with variuos tools, from hammers to wood glue.";
			zoomDesc = "Nothing really important here.";
		}
		if(name.ToLower () == "props")
		{
			objectName = "props";
			discovered = false;
			change = false;
			desc = "Several props, finished and unfinished, are laying about. There's extreme detail in the work.";
			zoomDesc = "The detail is quite impressive.";
		}
		if(name.ToLower () == "projector")
		{
			objectName = "projector ";
			discovered = false;
			change = false;
			desc = "This projector is most likely used to test the film, and ensure that the movie looks like what the director has in mind.";
			zoomDesc = "Looks like it needs a film.";
		}
		if(name.ToLower () == "screen")
		{
			objectName = "screen";
			discovered = false;
			change = false;
			desc = "The screen is blank, since the projector isn't running anything right now.";
			zoomDesc = "The projector is used to project an image onto the screen.";
		}
		if(name.ToLower () == "projection")
		{
			objectName = "projection";
			discovered = false;
			change = false;
			desc = "The last few scenes of 'The Diamond Thief' play on the screen. You see something in the bottom right corner that's out of place.";
			zoomDesc = "You see the shadow of Richard, the main actor. He's wearing gloves, and looks poised to steal the diamond.";
		}
		if(name.ToLower () == "film canisters")
		{
			objectName = "film canisters";
			discovered = false;
			change = false;
			desc = "Various film canisters lie about, each with various labels.";
			zoomDesc = "Nothing super important to see.";
		}
		if(name.ToLower () == "ash tray")
		{
			objectName = "ash tray";
			discovered = false;
			change = false;
			desc = "The ash tray is cold, and hasn't been used recently. There's a used cigar resting in it.";
			zoomDesc = "Cold ashes.";
		}
		if(name.ToLower () == "chemical wash")
		{
			objectName = "chemical wash";
			discovered = false;
			change = false;
			chemical = true;
			desc = "This is a chemical wash used for developing negatives. The room has to be kept dark, otherwise the film is ruined.";
			zoomDesc = "Looks ready to take some negatives.";
		}
		if(name.ToLower () == "costume rack")
		{
			objectName = "costume rack";
			discovered = false;
			change = false;
			desc = "The rack has various costume, from ball gowns to a thief outfit.";
			zoomDesc = "Many, many costumes.";
		}
		if(name.ToLower () == "makeup tables")
		{
			objectName = "makeup tables";
			discovered = false;
			change = false;
			desc = "Various kinds of makeup are strewn across the tables.";
			zoomDesc = "Pretty.";
		}
		if(name.ToLower () == "mirrors")
		{
			objectName = "mirrors";
			discovered = false;
			change = false;
			desc = "The mirrors are lit up, allowing the actors to get a better view.";
			zoomDesc = "How beautiful of a person you are.";
		}
		if (name.ToLower () == "magnifying glass" || name.ToLower() == "magnifying") 
		{
			objectName = "magnifying glass";
			desc = "A magnifying glass. Use this to get a closer look at potential clues.";
		}
		if (name.ToLower () == "fingerprint kit" || name.ToLower () == "fingerprint") 
		{
			objectName = "fingerprint kit";
			desc = "A kit you can use to dust objects for fingerprints.";
			pickup = true;
		}
		if (name.ToLower () == "photos") 
		{
			objectName = "photos";
			desc = "The photo appears to have three numbers on it.";
			pickup = true;
			zoomDesc = "Upon closer examination, the number appear to be a 3-digit numerical sequence.";
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
		if (objectName == "desk") 
		{
			textController.GetMaps().ActivateHidden();
		}
		return changeDesc;
	}

	public string Magnify()
	{
		if(magnified == false)
		{
			magnified = true;
			if(detail != "")
			{
				textController.GetMaps().ActiveRoom().AddInteractable(detail);
			}
			if(detail2 != "")
			{
				textController.GetMaps().ActiveRoom().AddInteractable(detail2);
			}
		}
		return zoomDesc;
	}
	public string Dust()
	{
		if (fingerprint == true)
		{
			return dust;
		}
		else 
		{
			return "No fingerprints were found.";
		}
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

	public string Chemical()
	{
		if (chemical == true) {
			textController.inventory.AddInteractable ("photos");
			textController.inventory.DeleteInteractable (commands.FindInventory ("negatives"));
			return "The negatives were turned into photos!";
		}
		else 
		{
			return "You can't do that.";
		}
	}
	public void Win()
	{
		Debug.Log (photo);
		if (photo == true)
		{
			textController.AppendMain("WARNING: Opening the safe requires a conviction. Are you ready to solve the mystery? (yes/no)");
			textController.gameState = "End Confirmation";
		}
		else
		{
			textController.AppendMain("You can't do that.");
		}
	}
}
