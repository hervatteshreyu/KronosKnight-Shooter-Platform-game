using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour
{
    public GameObject boss;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = boss.GetComponent<pastboss>().health;
        this.GetComponent<Text>().text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        health = boss.GetComponent<pastboss>().health;
        if (health <= 0)
            health = 0;
        this.GetComponent<Text>().text = health.ToString();
    }
}
