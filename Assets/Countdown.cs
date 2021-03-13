using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour
{
    private float timeRunning = 0;
    public float timeStart = 5;
    public Text textBox;
    public GameObject enemyPrefab;
    public GameObject activeEnemy;
    public Transform spawn_point;
    private bool timeStop = false;
    private bool allEnemiesDead = false;
    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString("F2");
        timeRunning = timeStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeStop)
        {
            timeRunning -= Time.deltaTime;
            textBox.text = timeRunning.ToString("F2");
        }
        if(timeRunning <= 0 && !timeStop)
        {
            timeStop = true;
            textBox.text = "0.00";
            foreach(Transform spoint in spawn_point) {
                activeEnemy= Instantiate(enemyPrefab, spoint.position, spoint.rotation);
            }
        }
        if (timeStop)
        {
            foreach (Transform spoint in spawn_point)
            {
                if (activeEnemy != null)
                {
                    allEnemiesDead = false;
                }
                else
                {
                    allEnemiesDead = true;
                }
            }
            if (allEnemiesDead)
            {
                timeRunning = timeStart;
                timeStop = false;
            }
        }
    }
}
