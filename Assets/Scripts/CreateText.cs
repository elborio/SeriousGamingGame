using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateText : MonoBehaviour {

	public InputField input;
	public GameObject [] abc;
	public float characterSpacing;

	public GameObject endPlatform;

	public string answer;

	private Text inputText;
	private GameObject[] typedWord; //word that has been typed.

	int currentChar;

	void Start()
	{
		inputText = input.textComponent;
		typedWord = new GameObject[0];

		endPlatform.transform.position = transform.position + new Vector3(calculateWordDistance(answer),0,0);
		Debug.DrawLine(transform.position,transform.position + new Vector3(calculateWordDistance(answer),0,0),Color.red);
		//Instantiate(abc[1],transform.position,transform.rotation);
	}

	public void OnTextChanged()
	{
		float createAtPosition = 0;
		clearGameobjects(typedWord);
		typedWord = new GameObject[input.text.Length];

		for(int i = 0; i < input.text.Length; i++)
		{
			//convert character to abc position.
			currentChar = (int)char.ToUpper(inputText.text[i])-65;

			//instantiate a 3d character.
			GameObject character = Instantiate(abc[currentChar],transform.position+ new Vector3 (createAtPosition,0,0),Quaternion.Euler(new Vector3(0,180,0))) as GameObject;
			//correct the position subtracting the extends so it is left aligned.
			character.transform.position = character.transform.position + new Vector3(character.GetComponent<Renderer>().bounds.extents.x,0,0);
			//next start position for character creation. Take width of last created character.
			createAtPosition = createAtPosition + character.GetComponent<Renderer>().bounds.size.x + characterSpacing;

			//Create a word consisting of the 3d characters.
			typedWord[i] = character;
		}
		AddColliders();
	}

	void clearGameobjects(GameObject[] gameObjects)
	{
		foreach(GameObject g in gameObjects)
		{
			GameObject.Destroy(g);
		}
	}

	void OnApplicationQuit()
	{
		clearGameobjects(typedWord); //cleanup purposes.
	}

	float calculateWordDistance(string word)
	{
		float distance = 0;
		int i = 0;
		foreach(char c in word)
		{
			//convert character to abc position.
			currentChar = (int)char.ToUpper(c)-65;
			Debug.Log(currentChar);
			distance = distance + abc[currentChar].GetComponent<Renderer>().bounds.size.x + characterSpacing;
			i++;
		}
		distance += endPlatform.GetComponent<Renderer>().bounds.extents.x;
		Debug.Log(i);
		return distance;
	}

	void AddColliders()
	{
		//if the character matches the one on the answer add a collider to the character.
		for(int i = 0; i< answer.Length; i++)
		{
			if(answer[i].Equals(inputText.text[i]))
			{
				typedWord[i].AddComponent<MeshCollider>();
				typedWord[i].GetComponent<Renderer>().material.color = Color.green;
			}
			else{
				typedWord[i].GetComponent<Renderer>().material.color = Color.red;
			}
		}
	}
}
