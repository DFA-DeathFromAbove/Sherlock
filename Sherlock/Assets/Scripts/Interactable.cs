using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

	private TextController textController;
	
	public string objectName = "";
	
	public void Awake()
	{
		textController = GameObject.Find("Scripts").GetComponent<TextController>();
	}
	
	public void SetupObject(string name)
	{
		if(name.ToLower() == "door")
		{
			objectName = "Door";
		}
	}
}
