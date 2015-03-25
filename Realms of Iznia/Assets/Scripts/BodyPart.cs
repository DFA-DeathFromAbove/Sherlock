using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BodyPart {

	public string name = "Not Found";
	
	private List<Wound> wounds = new List<Wound>();
	
	public BodyPart(string pName)
	{
		name = pName;
	}
}
