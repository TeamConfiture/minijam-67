using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMinigameScript : MonoBehaviour
{
    public MGManagerScript manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown() {
        manager.NextGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
