﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseScript : MonoBehaviour
{
    float reduceFactor = 1000;
    float progress;
    public float objective;
    Vector3 oldPos = Vector3.zero;
    bool writing, erased;
    //public GameObject signatureSprite;
    SpriteRenderer theRenderer;

    // Start is called before the first frame update
    void Start()
    {
			erased = false;
            theRenderer = gameObject.GetComponent<SpriteRenderer>();
            theRenderer.color = new Color (1, 1, 1, 0); 
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Fire1")) {
            oldPos = Input.mousePosition;
            writing = true;
            //Debug.Log("Started to write");
        } else if (Input.GetButtonUp("Fire1")) {
            if (writing) {
                writing = false;
                //Debug.Log("Stopped writing");
                oldPos = Vector3.zero;
            }
        }
        
    }
	
	void OnMouseOver()
	{
		if (writing) {
            Vector3 newPos =  Input.mousePosition;
            if (newPos.x < 0 || newPos.y < 0 || newPos.x > Screen.width || newPos.y > Screen.height) {
                writing = false;
            } else {
                float delta = Vector3.Distance(oldPos, newPos)*Time.deltaTime / reduceFactor;
                progress += delta;
                theRenderer.color = new Color (1, 1, 1, progress/objective); 
                // Debug.Log("Current : "+progress+"; delta : "+delta+"; objective : "+objective);
                if (progress >= objective&& !erased) {
                    Objective();
                    writing = false;
					erased = true;
                }
            }
        }
	}

    void Objective() {
        transform.parent.GetComponent<LoremIpsumScrolling>().WordErased();
    }
	
	public void Reset()
	{
		erased = false;
		progress = 0;
		theRenderer.color = new Color (1, 1, 1, 0); 
	}
}
