using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoremIpsumScrolling : MonoBehaviour
{
	int nbWordsErased = 0;
	const int TOTAL_WORDS = 10;
	float distanceScrolled = 0;

	public MGManagerScript managerScript;
	public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
    }
	
	void OnEnable()
	{
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0,1.2f, 0)*Time.deltaTime;
		distanceScrolled += 1.4f*Time.deltaTime;
		if(distanceScrolled >= 33.0f)// hauteur du texte, hardcodée (je sais c'est pas beau)
			EndGame();
    }
	
	public void WordErased()
	{
		nbWordsErased++;
		Debug.Log(nbWordsErased);
		if(nbWordsErased >= TOTAL_WORDS)
			EndGame();
	}
	
	void EndGame()
	{
		if(nbWordsErased >= TOTAL_WORDS)
		{
			managerScript.NextGame();
		}
		else
		{
			transform.position = new Vector3(0,0,0);
			Component[] words = GetComponentsInChildren<EraseScript>();
			foreach(EraseScript word in words)
				word.Reset();
				
			nbWordsErased = 0;
			distanceScrolled = 0;
		}
	}
	
	void OnDisable()
	{
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
	}
}
