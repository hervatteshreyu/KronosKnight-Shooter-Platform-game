using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class dialog : MonoBehaviour
{

    public GameObject speech1;
    public GameObject speech2;
    public GameObject speech3;
    public GameObject speech4;

    private void Start()
    {
        StartCoroutine("createBubbles");
    }

    IEnumerator createBubbles()
    {
        speech1 = Instantiate(speech1, this.transform);
        yield return new WaitForSeconds(5);
        Destroy(speech1);
        speech2 = Instantiate(speech2, this.transform);
        yield return new WaitForSeconds(5);
        Destroy(speech2);
        speech3 = Instantiate(speech3, this.transform);
        yield return new WaitForSeconds(5);
        Destroy(speech3);
        speech4 = Instantiate(speech4, this.transform);
        yield return new WaitForSeconds(5);
        Destroy(speech4);
        SceneManager.LoadScene("PastScene");
    }
}