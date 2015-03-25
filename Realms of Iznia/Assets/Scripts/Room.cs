﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Room : MonoBehaviour{

	public Room north = null;
	public Room east = null;
	public Room south = null;
	public Room west = null;
	public Room up = null;
	public Room down = null;
	
	public List<Interactable> interactables = new List<Interactable>();
	
	public string title;
	public string desc;
	public bool isActive = false;
	
	private List<Monster> monsters = new List<Monster>();
	
	private Text locationText;
	private Text locationTitle;
	
	private Text nExit;
	private Text eExit;
	private Text sExit;
	private Text wExit;
	private Text uExit;
	private Text dExit;
	
	private GameObject[,] mapPoints = new GameObject[7,7];
	
	void Awake()
	{
		FindObjects();
	}
	
	public void AddMonster(string monster, int difficulty)
	{
		monsters.Add(gameObject.AddComponent<Monster>());
		monsters[monsters.OfType<Monster>().Count()-1].SetupMonster(monster, difficulty, this);
	}
	
	public string SeeMonsters()
	{
		string returnedString = "";
		if(monsters.Count > 0)
		{
			returnedString = "You see: ";
			foreach(Monster monster in monsters)
			{
				if(monster != null)
				{
					if(monster == monsters.ElementAt(monsters.OfType<Monster>().Count()-1))
						returnedString += "and ";
					returnedString += "a " + monster.monsterName;
					if(monster == monsters.ElementAt(monsters.OfType<Monster>().Count()-1))
						returnedString += ".";
					else
						returnedString += ", ";
				}
			}
		}
		else
		{
			returnedString = "You see: No Monsters";
		}
		return returnedString;
	}
	
	public List<Monster> GetMonsters()
	{
		return monsters;
	}
	
	public void DeleteMonster(Monster monster)
	{
		if(monsters.Contains(monster))
		{
			monsters.Remove(monster);
		}
	}
	
	public void SwitchActive()
	{
		isActive = !isActive;
		if(isActive)
		{
			locationTitle.text = title;
			locationText.text = desc;
			AssignExits();
			DrawMiniMap(3,3);
		}
	}
	public void SwitchActive(bool active)
	{
		isActive = active;
		if(isActive)
		{
			locationTitle.text = title;
			locationText.text = desc;
			AssignExits();
			DrawMiniMap(3,3);
		}
	}
	
	private void AssignExits()
	{
		if(north != null)
			nExit.text = "N";
		else
			nExit.text = "";
		if(east != null)
			eExit.text = "E";
		else
			eExit.text = "";
		if(south != null)
			sExit.text = "S";
		else
			sExit.text = "";
		if(west != null)
			wExit.text = "W";
		else
			wExit.text = "";
		if(up != null)
			uExit.text = "V";
		else
			uExit.text = "";
		if(down != null)
			dExit.text = "V";
		else
			dExit.text = "";
	}
	
	public void DrawMiniMap(int x, int y)
	{
		if(x == 3 && y == 3)
		{
			for(int i = 0; i <= 6; i++)
			{
				for(int j = 0; j <=6; j++)
				{
					mapPoints[i,j].SetActive(false);
				}
			}
			mapPoints[x,y].SetActive(true);
		}
		
		if(x > 6 || x < 1 || y > 6 || y < 1)
			return;
		if(north != null && !mapPoints[x,y+1].activeSelf)
		{
			mapPoints[x,y+1].SetActive(true);
			north.DrawMiniMap(x, y+1);
		}
		if(east != null && !mapPoints[x+1,y].activeSelf)
		{
			mapPoints[x+1,y].SetActive(true);
			east.DrawMiniMap(x+1,y);
		}
		if(south != null && !mapPoints[x,y-1].activeSelf)
		{
			mapPoints[x,y-1].SetActive(true);
			south.DrawMiniMap(x, y-1);
		}
		if(west != null && !mapPoints[x-1,y].activeSelf)
		{
			mapPoints[x-1,y].SetActive(true);
			west.DrawMiniMap(x-1,y);
		}
	}
	
	private void FindObjects()
	{
		locationTitle = GameObject.Find("LocationTitle").GetComponent<Text>();
		locationText = GameObject.Find ("LocationText").GetComponent<Text>();
		nExit = GameObject.Find ("NExit").GetComponent<Text>();
		eExit = GameObject.Find ("EExit").GetComponent<Text>();
		sExit = GameObject.Find ("SExit").GetComponent<Text>();
		wExit = GameObject.Find ("WExit").GetComponent<Text>();
		uExit = GameObject.Find ("UExit").GetComponent<Text>();
		dExit = GameObject.Find ("DExit").GetComponent<Text>();
		SetMiniMapPoints();
	}
	
	private void SetMiniMapPoints()
	{
		for(int i = 0; i <= 6; i++)
		{
			for(int j = 0; j <= 6; j++)
			{
				mapPoints[i,j] = GameObject.Find("MM("+i+","+j+")");
			}
		}
	}
}