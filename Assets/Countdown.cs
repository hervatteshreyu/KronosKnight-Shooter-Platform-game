using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour
{
    public float timeStart = 5;
    public Text textBox;
    public GameObject enemyPrefab;
    public Transform spawn_point;
    private bool timeStop = false;
    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeStop)
        {
            timeStart -= Time.deltaTime;
            textBox.text = timeStart.ToString("F2");
        }
        if(timeStart <= 0 && !timeStop)
        {
            timeStop = true;
            textBox.text = "0.00";
            foreach(Transform spoint in spawn_point) {
                Instantiate(enemyPrefab, spoint.position, spoint.rotation);
            }
        }
    }
}
