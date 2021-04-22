using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButtonBehavior : MonoBehaviour
{

    public void OnButtonPress()
    {
        SceneManager.LoadScene("PastScene");
    }
}
