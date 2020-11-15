using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "You won in " + GameManager.Instance.Chrono.ToString("F") + " seconds ! (ending scene in 3 seconds)";
        StartCoroutine(ChangeScene(3));
    }

 IEnumerator ChangeScene(int index,float delay = 2f)
     {
          yield return new WaitForSeconds(delay);
          SceneManager.LoadScene(nextScene);
     }
}
