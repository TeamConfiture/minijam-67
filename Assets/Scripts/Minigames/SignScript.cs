using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript : MonoBehaviour
{
    float reduceFactor = 1000;
    float progress;
    public float objective;
    Vector3 oldPos = Vector3.zero;
    bool writing;
    public GameObject signatureSprite;
    SpriteRenderer theRenderer;
    public MGManagerScript managerScript;

    // Start is called before the first frame update
    void Start()
    {
        if (signatureSprite != null) {
            theRenderer = signatureSprite.GetComponent<SpriteRenderer>();
            theRenderer.color = new Color (1, 1, 1, 0); 
        } else {
            Debug.Log("No Signature attached !");
        }
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
        if (writing) {
            Vector3 newPos =  Input.mousePosition;
            if (newPos.x < 0 || newPos.y < 0 || newPos.x > Screen.width || newPos.y > Screen.height) {
                writing = false;
            } else {
                float delta = Vector3.Distance(oldPos, newPos) / reduceFactor;
                progress += delta;
                theRenderer.color = new Color (1, 1, 1, progress/objective); 
                //Debug.Log("Current : "+progress+"; delta : "+delta+"; objective : "+objective);
                if (progress >= objective) {
                    Objective();
                    writing = false;
                    progress = 0;
                }
            }
        }
    }

    void Objective() {
        Debug.Log("Document signed !");
        managerScript.NextGame();
    }
}
