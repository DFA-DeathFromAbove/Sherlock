using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {
	
	public string npcName = "";
	public string info = "";
	private string[,] dialogue = new string [100,2];
	private TextController textController;

	void Awake()
	{
		textController = GameObject.Find ("Scripts").GetComponent<TextController>();
	}

	public void SetupNPC(string name)
	{
		if(name.ToLower() == "richard")
		{
			npcName = name;
			dialogue [0, 0] = "";
			dialogue [0, 1] = "I don't know anything about ";
			dialogue [1, 0] = "murder";
			dialogue [1, 1] = "When the murder happened, I was practicing my lines in the changing room.";
			dialogue [2, 0] = "saw blade";
			dialogue [2, 1] = "Sorry, I haven't seen that before. Looks like something used in the wood shop.";
			dialogue [3, 0] = "boot";
			dialogue [3, 1] = "The director always wore those around the set.";
			dialogue [4, 0] = "boot print";
			dialogue [4, 1] = "The director frequently visited the wood shop to ensure the props were to his liking. He was very particluar about details.";
			dialogue [5, 0] = "wallet";
			dialogue [5, 1] = "That looks like the director's. I can even see his id in it.";
			dialogue [6, 0] = "film reel";
			dialogue [6, 1] = "That's yesterday's shots for the movie. I play the theif in the film, you should watch it if we finish it after this incident is over.";
			dialogue [7, 0] = "negative";
			dialogue [7, 1] = "That's some undeveloped film. Not sure what it's for, though.";
			dialogue [8, 0] = "costume rack";
			dialogue [8, 1] = "As you can see, all of the costumes are on the rack. The film was low budget, and I was surprised we got a real diamond just for the movie.";
			dialogue [9, 0] = "ash tray";
			dialogue [9, 1] = "The director tended to smoke while working. He thought it helped with his 'inspiration'.";
			dialogue [10, 0] = "props";
			dialogue [10, 1] = "I have to say, our guys in the wood shop do a great job on these  - They put great detail into them.";
			dialogue [11, 0] = "film canisters";
			dialogue [11, 1] = "The director wasn't just filming 'The Diamond Theif.' He had various other projects, but lately he was focusing on this one.";
			dialogue [12, 0] = "painting";
			dialogue [12, 1] = "Honestly, I don't know why the director has that. It's hideous.";
			dialogue [13, 0] = "director's chair";
			dialogue [13, 1] = "Well, clearly the director sat in it.";
			dialogue [14, 0] = "set";
			dialogue [14, 1] = "The set resembles a high security bank. I, the highly trained theif, break in to steal the diamond. That's the last scene we were filming.";
			dialogue [15, 0] = "richard";
			dialogue [15, 1] = "I'm the lead actor of the film. I play the diamond thief himself, 'Ricky Gonzalez.'";
			dialogue [16, 0] = "gerrard";
			dialogue [16, 1] = "We don't talk much. He spends most of his time working on props in the wood shop. Seems like a very reserved person.";
			dialogue [17, 0] = "clara";
			dialogue [17, 1] = "She's one of our camera crew. I see her all the time on set, working one of the cameras.";
			dialogue [18, 0] = "director";
			dialogue [18, 1] = "Always seemed like a good guy to me. He always pushed for perfection, good thing he hired me.";
			dialogue [19, 0] = "mitch ogden";
			dialogue [19, 1] = "Originally, he was supposed to play the diamond theif. I'm surprised he didn't take the job, seeing as how it pays more than teaching.";
			info = "Can I help you?";

		}
		if(name.ToLower() == "gerrard")
		{
			npcName = name;
			dialogue [0, 0] = "";
			dialogue [0, 1] = "What are you talking about? I haven't heard anything about ";
			dialogue [1, 0] = "murder";
			dialogue [1, 1] = "At the time, I was working on one of the props. He was always picky about them, asking me to change stuff last minute.";
			dialogue [2, 0] = "saw blade";
			dialogue [2, 1] = "That's the blade that went missing last night!";
			dialogue [3, 0] = "boot";
			dialogue [3, 1] = "I saw the director in those all the time. Surprised they're so clean, what with him coming in the shop all the time.";
			dialogue [4, 0] = "boot print";
			dialogue [4, 1] = "Yep, that's the directors all right. He wore those boots like his birthday suit.";
			dialogue [5, 0] = "cutting table";
			dialogue [5, 1] = "I use this all the time. Great for cutting up wood. Too bad I lost my saw blade last night...";
			dialogue [6, 0] = "film reel";
			dialogue [6, 1] = "Hey, I just work on props. I don't know anything about film or cameras.";
			dialogue [7, 0] = "negative";
			dialogue [7, 1] = "Looks like some film. Dunno what it's for, though.";
			dialogue [8, 0] = "costume rack";
			dialogue [8, 1] = "I only know how to make props. Leave sowing to the fashion designers.";
			dialogue [9, 0] = "tool cabinet";
			dialogue [9, 1] = "That's where I store all my tools. I suppose that's pretty obviuos though, hehe...";
			dialogue [10, 0] = "props";
			dialogue [10, 1] = "You like them? I made most of the props you see here, and thanks to the director's need for perfection, I'm proud of my work.";
			dialogue [11, 0] = "painting";
			dialogue [11, 1] = "I'm not much of an art fan, and I don't get this modern stuff. Just looks like a bunch of blobs to me.";
			dialogue [12, 0] = "set";
			dialogue [12, 1] = "I've been working on props to match this set. I designed the pedestal, as well as most of the other objects.";
			dialogue [13, 0] = "richard";
			dialogue [13, 1] = "He's the theif in the movie. He has a pretty big ego, if you ask me. Acting high and mighty all the time.";
			dialogue [14, 0] = "gerrard";
			dialogue [14, 1] = "I lead the construction part of the movie. I designed and built most of the props you see on the stage.";
			dialogue [15, 0] = "clara";
			dialogue [15, 1] = "I don't see her too often back here. She usually is filming the movie, or chatting with the theif, Richard.";
			dialogue [16, 0] = "mitch ogden";
			dialogue [16, 1] = "He was supposedly going to be the lead actor of the film, but he backed down. Couldn't leave his students with no teacher, right?";
			dialogue [17, 0] = "director";
			dialogue [17, 1] = "He was a good man. He pushed me to my limit, teaching me to go for the greatest works I could make. Bit pushy about it, though.";
			info = "What do you want?";
		}
		if(name.ToLower () == "clara") 
		{
			npcName = name;
			info = "How can I help you, sir?";
			dialogue [0, 0] = "";
			dialogue [0, 1] = "What are you talking about? I haven't heard anything about ";
			dialogue [1, 0] = "richard";
			dialogue [1, 1] = "A great actor thus far. Has played the part exceptionally well.";
			dialogue [2, 0] = "gerrard";
			dialogue [2, 1] = "Makes nice sets, works hard. Don't talk to him much otherwise";
			dialogue [3, 0] = "clara";
			dialogue [3, 1] = "I'm a camera operator. I work on many of the shots for the film.";
			dialogue [4, 0] = "murder";
			dialogue [4, 1] = "Really unfortunate. The filming was going so well, and he was a great guy to work for.";
			dialogue [5, 0] = "wallet";
			dialogue [5, 1] = "Looks like the director's wallet.";
			dialogue [6, 0] = "boots";
			dialogue [6, 1] = "Saw him wearing those all the time.";
			dialogue [7, 0] = "film reel";
			dialogue [7, 1] = "Looks like its from yesterday. Probably the developed takes.";
			dialogue [8, 0] = "set";
			dialogue [8, 1] = "Great design so far. The director likes to be a perfectionist, and our woodshop puts out some nice work.";
			dialogue [9, 0] = "saw blade";
			dialogue [9, 1] = "Looks like a blade from the woodshop.";
			dialogue [10, 0] = "painting";
			dialogue [10, 1] = "Never understood that painting. Not a great work of art in my opinion.";
			dialogue [11, 0] = "ash tray";
			dialogue [11, 1] = "Used quite often by the director as he was looking at film.";
			dialogue [12, 0] = "director's chair";
			dialogue [12, 1] = "Vacant now.";
			dialogue [13, 0] = "director";
			dialogue [13, 1] = "Always a good person to work for. Sad that he's gone.";
			dialogue [14, 0] = "mitch ogden";
			dialogue [14, 1] = "Great guy, good professor.";
			dialogue [15, 0] = "costume rack";
			dialogue [15, 1] = "Used often by the cast of the movie.";


		}
	}

	public void AskAbout(string input)
	{
		for(int i = 0; i < 100; i++) //TODO:  Method to find length of 2D Array
		{
			if(dialogue[i,0] != null)
			{
				if(dialogue[i,0].Length >= input.Length)
				{
					if(dialogue[i,0].Substring(0,input.Length) == input)
					{

						Response(i);
						return;
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
		return info;
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
