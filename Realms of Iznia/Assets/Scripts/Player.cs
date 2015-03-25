using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public GameObject healthBar;
	public GameObject manaBar;
	
	public List<BodyPart> bodyParts = new List<BodyPart>();
	public List<Skill> skills = new List<Skill>();
	
	private TextController output;
	private Maps maps;
	
	public string playerName;
	public int level;
	public int experience;
	public int maxHealth;
	public int curHealth;
	public int maxMana;
	public int curMana;
	
	// Use this for initialization
	void Awake()
	{
		output = gameObject.GetComponent<TextController>();
		maps = gameObject.GetComponent<Maps>();
		
		LoadPlayerPrefs();
		WelcomePlayer();
	}
	
	void Update()
	{
		
	}
	
	public void Reset()
	{
		playerName = "New Player";
		WelcomePlayer();
	}
	
	public void DamageHealth(int damage)
	{
		curHealth -= damage;
		if(curHealth <= 0)
		{
			output.AppendMain("You have died!");
			curHealth = maxHealth;
			maps.SetActive("startingFarm", 3);
		}
		healthBar.GetComponent<RectTransform>().anchorMax = new Vector2(curHealth/(float)maxHealth, 0.57f);
	}
	
	public void Attack(string skill, Monster monster)
	{
		if(skill == "punch")
		{
			output.AppendMain(skills.Find(x => x.skillName == "punch").attackDescription_1[0] + "a " + monster.monsterName + ".");
			monster.DamageHealth(5); //TODO: Add skill variables
		}
	}
	
	void SetBodyParts()
	{
		bodyParts.Add(new BodyPart("head"));
		bodyParts.Add(new BodyPart("neck"));
		bodyParts.Add(new BodyPart("chest"));
		bodyParts.Add(new BodyPart("back"));
		bodyParts.Add(new BodyPart("abdomen"));
		bodyParts.Add(new BodyPart("rarm"));
		bodyParts.Add(new BodyPart("larm"));
		bodyParts.Add(new BodyPart("rleg"));
		bodyParts.Add(new BodyPart("lleg"));
		bodyParts.Add(new BodyPart("rhand"));
		bodyParts.Add(new BodyPart("lhand"));
		bodyParts.Add(new BodyPart("rfoot"));
		bodyParts.Add(new BodyPart("lfoot"));
	}
	
	void WelcomePlayer()
	{
		if(playerName == "New Player")
		{
			output.AppendMain("The land of Iznia welcomes a new hero... \nWhat name do you take?");
			output.SetGameState("New Player");
		}
		else
		{
			output.AppendMain("The land of Iznia welcomes the return of the hero " + playerName + ".");
		}
	}
	
	void LoadPlayerPrefs()
	{
		playerName = PlayerPrefs.GetString("playerName", "New Player");
		level = PlayerPrefs.GetInt ("level", 0);
		experience = PlayerPrefs.GetInt ("experience", 0);
		maxHealth = PlayerPrefs.GetInt ("maxHealth", 10);
		curHealth = PlayerPrefs.GetInt ("curHealth", 10);
		maxMana = PlayerPrefs.GetInt ("maxMana", 10);
		curMana = PlayerPrefs.GetInt ("curMana", 10);
		skills.Add(new Skill("punch", this, PlayerPrefs.GetInt("punchLv", 1), PlayerPrefs.GetFloat("punchExp", 0)));
	}
}
