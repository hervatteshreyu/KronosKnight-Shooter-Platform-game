using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneIndex;
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
