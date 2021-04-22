using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour
{
    public GameObject boss;
    public bool isFuture;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        if(!isFuture)
            health = boss.GetComponent<pastboss>().health;
        else
            health = boss.GetComponent<FutureBoss>().health;
        this.GetComponent<Text>().text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFuture)
            health = boss.GetComponent<pastboss>().health;
        else
            health = boss.GetComponent<FutureBoss>().health;
        if (health <= 0)
            health = 0;
        this.GetComponent<Text>().text = health.ToString();
    }
}
