using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoremIpsumScrolling : MonoBehaviour
{
	int nbWordsErased = 0;
	const int TOTAL_WORDS = 11;
	float distanceScrolled = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0,1.2f, 0)*Time.deltaTime;
		distanceScrolled += 1.2f*Time.deltaTime;
		if(distanceScrolled >= 48.0f)// hauteur du TextMeshPro, hardcodée (je sais c'est pas beau)
			EndGame();
    }
	
	public void WordErased()
	{
		nbWordsErased++;
		if(nbWordsErased == TOTAL_WORDS)
			EndGame();
	}
	
	void EndGame()
	{
		if(nbWordsErased == TOTAL_WORDS)
			Debug.Log("Success!");//passer au minijeu suivant
		else
			Debug.Log("Failure!");//reset le minijeu
	}
}
