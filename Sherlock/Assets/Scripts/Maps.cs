﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maps : MonoBehaviour {

	public List<Room> mainArea = new List<Room>();
	public List<Room> hiddenArea = new List<Room>();
	public Room theVoid;
	
	private Room activeRoom;
	
	void Start()
	{
		InitializeRooms();
		SetRoomDescriptions();
	}
	
	private void InitializeRooms()
	{
		theVoid = gameObject.AddComponent<Room>();
		for(int i = 0; i < 6; i++)
		{
			mainArea.Insert(0,gameObject.AddComponent<Room>());
		}
		for(int i = 0; i < 5; i++)
		{
			hiddenArea.Insert(0,gameObject.AddComponent<Room>());
		}
	}
	
	public void SetActive(string area, int roomNumber)
	{
		if(area == "main")
		{
			if(roomNumber < mainArea.Count && mainArea[roomNumber] != null)
			{
				activeRoom.SwitchActive();
				activeRoom = mainArea[roomNumber];
				activeRoom.SwitchActive();
			}
		}
		if(area == "hidden")
		{
			if(roomNumber < hiddenArea.Count && hiddenArea[roomNumber] != null )
			{
				activeRoom.SwitchActive();
				activeRoom = hiddenArea[roomNumber];
				activeRoom.SwitchActive();
			}
		}
		else
		{
			Debug.Log("Could not find area in Maps->SetActive");
		}
	}
	
	public void SetActive(Room room)
	{
		activeRoom.SwitchActive();
		activeRoom = room;
		activeRoom.SwitchActive();
	}
	
	public Room ActiveRoom()
	{
		return activeRoom;
	}
	
	void SetRoomDescriptions()
	{
		theVoid.title = "The Void";
		theVoid.desc = "Swirling darkness envelopes you.  Where are you but within your own lack of existance?";
		theVoid.SwitchActive(true);
		activeRoom = theVoid;
		
		mainArea[0].title = "Office";
		mainArea[0].desc = "The Director's office. You see a large, solid wood desk facing a wall. A large, ugly painting hangs to the right. The director's body is seen on the floor, with obvious stab wounds.";
		mainArea[0].south = mainArea[1];
		
		mainArea[1].title = "Stage";
		mainArea[1].desc = "A large, open room. The set takes up the majority of the space, a fake bank vault with a large pedastol in the middle.";
		mainArea[1].north = mainArea[0];
		mainArea[1].east = mainArea[5];
		mainArea[1].south = mainArea[3];
		
		mainArea[2].title = "Woodshop";
		mainArea[2].desc = "NPC2 is sitting in the corner. The room is full of sawdust, and unfinished prop pieces lie against every wall. Towards one end of the room lies a saw table.";
		mainArea[2].east = mainArea[3];
		
		mainArea[3].title = "Projector Room";
		mainArea[3].desc = "You enter the narrow room, and a projector lies in the middle of the floor. Facing opposite you is a large screen upon which projections would be cast. To the left is a filled ash tray.";
		mainArea[3].north = mainArea[1];
		mainArea[3].south = mainArea[4];
		mainArea[3].west = mainArea[2];
		
		mainArea[4].title = "Negative Development Room";
		mainArea[4].desc = "A dimly, red-lit room lies through the narrow passages. In front of you lies a large chemical wash and lines from which negatives would be strung.";
		mainArea[4].north = mainArea[3];
		
		mainArea[5].title = "Changing Room";
		mainArea[5].desc = "A large, bright room that contains numerous make-up tables, a costume rack, and mirrors.";
		mainArea[5].west = mainArea[1];
		
		hiddenArea[0].title = "Secret Room";
		hiddenArea[0].desc = "You walk into a small, cramped space. There are cobwebs everywhere, and a lone lightbulb provides the only light. On the ground lies a camera with some negative film.";
	}
}
