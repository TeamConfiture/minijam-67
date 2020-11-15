using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public MGManagerScript manager;

    public Sprite right;
    public Sprite wrong;
    public Sprite empty;
    public SpriteRenderer box;
    public bool rightOrWrong;

    public SpriteRenderer result;

    private bool clickedBox = false;
    
    public int nbrRightBoxes;
    //private bool[] boxes = new ArrayList<bool>(nbrBoxes);
    private static int nbrBoxesChecked = 0;
    private static int rightAnswers = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        result.sprite = null;

        if(nbrBoxesChecked == nbrRightBoxes)
        {
            if(rightAnswers == nbrRightBoxes)
            {
                Debug.Log("Nice");
                result.sprite = right;
                manager.NextGame();
            } else
            {
                Debug.Log("Your stupid");
                result.sprite = wrong;
                //yield return new WaitForSeconds(2);
                //result.sprite = null;
            }
        }
        
    }

    void OnMouseDown()
    {
        Debug.Log("clicked");

        ChecksBox();

     
        
    }

    public void ChecksBox()
    {
        //img = GetComponent<Sprite>();

        if (rightOrWrong)
        {
            CheckRightBox();
        }
        else
        {
            CheckWrongBox();
        }
    }

    public void CheckRightBox()
    {

        if (!clickedBox)
        {
            clickedBox = true;
            Debug.Log("Check right box");
            box.sprite = right;
            rightAnswers++;
            nbrBoxesChecked++;
        }
        else
        {
            Debug.Log("Already clicked this box");
        }
        
    }

    public void CheckWrongBox()
    {
        if (!clickedBox)
        {
            clickedBox = true;
            box.sprite = wrong;
            nbrBoxesChecked++;
        }
        else
        {
            clickedBox = false;
            box.sprite = empty;
            nbrBoxesChecked--;
        }

        
    }

}
