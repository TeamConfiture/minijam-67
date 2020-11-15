using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackMinigameScript : MonoBehaviour
{
    public int sheetCount = 20;
     public MGManagerScript manager;
    public GameObject sheetPrefab;
    public Transform instantiationPoint;

    private Vector3 startPoint;

    void Start() {
        startPoint = instantiationPoint.position;
        startPoint += new Vector3(0, 0, -0.5f);
    }

    void OnMouseDown() {
        if(sheetCount == 0) {
            manager.NextGame();
        } else {
            sheetCount--;
            GameObject sheet = Instantiate(sheetPrefab, startPoint, Quaternion.Euler(0, 0, Random.Range(0,360)));
            sheet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-200,200), 200+Random.Range(0,200)));
            Destroy(sheet, 5);
        }
    }
}
