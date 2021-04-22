using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog_Past_Done : MonoBehaviour
{
    public GameObject speech1;
    public GameObject speech2;
    public GameObject speech3;
    public GameObject speech4;
    public GameObject pastPower;

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
        pastPower = Instantiate(pastPower);
        Rigidbody2D rb = pastPower.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x-2f, rb.velocity.y);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("FutureScene");
    }
}
