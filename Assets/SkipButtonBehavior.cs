using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButtonBehavior : MonoBehaviour
{
    public bool isStart;
    public bool isPast;
    public bool isFuture;
    public bool isEnd;

    public void OnButtonPress()
    {
        if (isStart)
            SceneManager.LoadScene("PastScene");
        else if (isPast)
            SceneManager.LoadScene("FutureScene");
        else if (isFuture)
            SceneManager.LoadScene("EndScene");
        else
            SceneManager.LoadScene("StartMenuScene");
    }
}
