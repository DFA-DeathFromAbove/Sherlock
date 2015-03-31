/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monster : MonoBehaviour {

	public string monsterName = "Unset Name";
	
	public List<BodyPart> bodyParts = new List<BodyPart>();
	
	private List<Skill> skills = new List<Skill>();
	
	private TextController output;
	private Room room;
	private Maps maps;
	private Player player;
	
	private string shape;
	private string physique;
	private string desc;
	private ArrayList idleDescs = new ArrayList();
	private ArrayList searchDescs = new ArrayList();
	
	private int maxHealth;
	private int curHealth;
	private int damage;
	private int accuracy;
	private int speed;
	private int dodging;
	
	private double distance;
	
	private float lastAnimation;
	private float lastAttack;
	private float attackCooldown = 5f;
	private float animationCooldown = 5f;
	
	private bool canSee = true;
	private bool isFighting = true;
	
	void Awake()
	{
		player = GameObject.Find("Scripts").GetComponent<Player>();
		maps = GameObject.Find("Scripts").GetComponent<Maps>();
		output = GameObject.Find("Scripts").GetComponent<TextController>();
		lastAnimation = Time.time;
		lastAttack = Time.time;
	}
	
	void Update()
	{
		if(isFighting)
		{
			Attack ();
		}
		else
		{
			Animate ();
		}
	}
	
	public void DamageHealth(int pDamage)
	{
		curHealth -= pDamage;
		if(curHealth <= 0)
		{
			Die();
		}
	}
	
	private void Die()
	{
		output.AppendMain("A " + monsterName + " is vanquished!"); //TODO: ADD death variance
		room.DeleteMonster(this);
		Destroy(this);
	}
	
	public void SetupMonster(string pName, float pDifficulty, Room pRoom)
	{
		if(pName.ToLower() == "black rat")
		{
			room = pRoom;
			monsterName = pName;
			maxHealth = (int)(5*pDifficulty);
			curHealth = maxHealth;
			accuracy = 10;
			speed = 10;
			damage = 1;
			dodging = 10;
			SetParts("quad");
			desc = "You see a black rat.  A well known rodent that thrives in the presence of humans, it feeds on the waste and left-overs of society.";
			idleDescs.Add("A black rat struts about the area, lacking interest in your presence.");
			skills.Add(new Skill("bite", this));
			skills.Add(new Skill("tackle", this));
		}
		if(pName.ToLower() == "undulating blob")
		{
			room = pRoom;
			monsterName = pName;
			maxHealth = (int)(10*pDifficulty);
			curHealth = maxHealth;
			accuracy = 10;
			speed = 1;
			damage = 3;
			dodging = 1;
			SetParts("base");
			bodyParts.Add(new BodyPart("tendril"));
			desc = "You see an undulating blob.  It pulses slowly as if it is breathing, a dim glow radiating from within.  Small tendrils gyrate slowly, searching for something to eat.";
			idleDescs.Add("An undulating blob flickers dimly as it's tendril latches onto some rotting remains.");
			skills.Add(new Skill("whip", this));
		}
	}
	
	public string GetDesc()
	{
		return desc;
	}
	
	private void Animate()
	{
		if(Time.time - lastAnimation > animationCooldown && room == maps.ActiveRoom())
		{
			output.AppendMain(idleDescs[Random.Range(0, idleDescs.Count-1)].ToString());
			lastAnimation = Time.time;
			animationCooldown = Random.Range (5f, 12f);
		}
	}
	
	private void Attack()
	{
		if(Time.time - lastAttack > attackCooldown && room == maps.ActiveRoom())
		{
			if(canSee)
			{
				Skill usedSkill = skills[Random.Range(0,skills.Count-1)];
				output.AppendMain("A " + monsterName + usedSkill.attackDescription_1[0] + "leg."); //TODO: Update with bodypart choosing function
				player.DamageHealth(damage); //TODO: Update with player wounding function
				lastAttack = Time.time;
				attackCooldown = Random.Range(3f,6f);
			}
			else
			{
				output.AppendMain(searchDescs[Random.Range(0, searchDescs.Count-1)].ToString());
				lastAttack = Time.time;
				attackCooldown = Random.Range(3f, 6f);
			}
		}
	}
	
	private void SetParts(string type)
	{
		if(type == "quad")
		{
			bodyParts.Add(new BodyPart("head"));
			bodyParts.Add(new BodyPart("reye"));
			bodyParts.Add(new BodyPart("leye"));
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
		if(type == "base")
		{
			bodyParts.Add(new BodyPart("head"));
			bodyParts.Add(new BodyPart("back"));
			bodyParts.Add(new BodyPart("chest"));
		}
	}
}
*/