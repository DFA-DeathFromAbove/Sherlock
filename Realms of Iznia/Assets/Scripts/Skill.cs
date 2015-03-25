using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill{
	
	public int skillLevel = 1;
	
	public double skillExp = 0;
	
	public string skillName = "Not Found";
	public string attackRange = "any"; //any/all + upper/lower/arm/leg
	
	public List<string> attackDescription_1 = new List<string>();
	public List<string> attackDescription_2 = new List<string>();
	public List<BodyPart> attacksWith = new List<BodyPart>();
	
	public Skill(string pName, Monster pMonster)
	{
		skillName = pName;
		if(skillName == "bite")
		{
			attackRange = "any";
			attacksWith.Add(pMonster.bodyParts.Find(x => x.name == "head"));
			attackDescription_1.Add(" rushes at you with an open maw, biting at your ");
		}
		if(skillName == "tackle")
		{
			attackRange = "any lower";
			attacksWith.Add(pMonster.bodyParts.Find(x => x.name == "chest"));
			attacksWith.Add(pMonster.bodyParts.Find(x => x.name == "back"));
			attackDescription_1.Add(" scurries around frantically, throwing it's weight into your ");
		}
		if(skillName == "whip")
		{
			attackRange = "any";
			attacksWith.Add(pMonster.bodyParts.Find(x => x.name == "tendril"));
			attackDescription_1.Add(" attatches it's tendril to your ");
//			attackDescription_2.Add(", sharp thorns gouging out your skin.");
		}
	}
	
	public Skill(string pName, Player pPlayer, int pLevel, double pExp)
	{
		skillName = pName;
		if(skillName == "punch")
		{
			skillLevel = pLevel;
			skillExp = pExp;
			attackRange = "any";
			attacksWith.Add(pPlayer.bodyParts.Find(x => x.name == "rhand"));
			attacksWith.Add(pPlayer.bodyParts.Find(x => x.name == "lhand"));
			attackDescription_1.Add("You swing your clenched fist at ");
//			attackDescription_2.Add(" leaving a large welt.");
		}
	}
	
}
