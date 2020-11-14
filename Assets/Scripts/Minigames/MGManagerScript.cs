using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MGManagerScript : MonoBehaviour
{
    
    public List<GameObject> minigames;
    public Text chronoText;
    
    private bool playing;
    private double chronoTime;
    private int currentGame = -1;

    public void NextGame() {
        currentGame++;
        // currentGame = currentGame % minigames.Count;
        if(currentGame < minigames.Count - 1) {
            SetMiniGame(currentGame);
        } else {
            EndMiniGames();
        }
    }

    private void SetMiniGame(int i) {
        minigames.FindAll(g => g.activeSelf).ForEach(g => g.SetActive(false));
        minigames[i].SetActive(true);
    }

    private void EndMiniGames() {
        minigames.FindAll(g => g.activeSelf).ForEach(g => g.SetActive(false));
        playing = false;
        GameManager.Instance.Win(chronoTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        if(minigames.Count < 1) {
            Debug.LogError("No minigame found !");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playing) {
            chronoTime += Time.deltaTime;
            chronoText.text = chronoTime.ToString("F");
        }
    }
}
