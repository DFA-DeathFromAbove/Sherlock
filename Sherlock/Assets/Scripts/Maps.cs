using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maps : MonoBehaviour {

	public List<Room> startingFarm = new List<Room>();
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
		for(int i = 0; i < 5; i++)
		{
			startingFarm.Insert(0,gameObject.AddComponent<Room>());
		}
	}
	
	public void SetActive(string area, int roomNumber)
	{
		if(area == "startingFarm")
		{
			if(roomNumber < startingFarm.Count && startingFarm[roomNumber] != null)
			{
				activeRoom.SwitchActive();
				activeRoom = startingFarm[roomNumber];
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
		
		startingFarm[0].title = "Abandoned Farmhouse - Hallway";
		startingFarm[0].desc = "Aged wood creaks upon your steps.  Sharp gashes adorn a dog sized hole that has been dug into the wall."
		+"  Scratching and scraping can be heard from below the floorboards.";
		startingFarm[0].north = startingFarm[1];
		startingFarm[0].south = startingFarm[2];
		startingFarm[0].up = startingFarm[3];
		
		startingFarm[1].title = "Abandoned Farmhouse - Kitchen";
		startingFarm[1].desc = "Once a kitchen; it can be called no longer.  Dead leaves litter the floor of a dead home.";
		startingFarm[1].south = startingFarm[0];
		startingFarm[1].east = startingFarm[4];
		
		startingFarm[2].title = "Abandoned Farmhouse - Front Yard";
		startingFarm[2].desc = "Once the sole pride of a farmer, nature has begun to erase this building from history."
		+"  Looking upon the abandoned building leaves you with a sense of forlorn memories; a nostalgia you can never hope to return to.";
		startingFarm[2].north = startingFarm[0];
		
		startingFarm[3].title = "Abandoned Farmhouse - Master Bedroom";
		startingFarm[3].desc = "Devoid of any rememberance of the comfort that once was, this once haven of sweet dreams has become a haven for termites and vagabonds.  It appears that someone has slept here recently.";
		startingFarm[3].down = startingFarm[0];
		startingFarm[3].AddNPC("Jon");
		startingFarm[3].AddNPC("Greg");
		
		startingFarm[4].title = "Abandoned Farmhouse - Pantry";
		startingFarm[4].desc = "Rotted meat lays strewn across the moldy floor.  A waft of warm air lifts upwards, making you gag and choke.";
		startingFarm[4].west = startingFarm[1];
	}
}
