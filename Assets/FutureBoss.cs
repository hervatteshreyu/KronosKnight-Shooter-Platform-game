using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FutureBoss : MonoBehaviour
{
    public int health;
    public int bulletDamage;
    private int bulletHits;
    public GameObject impactEffect;
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float RotateSpeed;
    private float _angle;
    public float Radius;
    private Vector3 startingPosition;
    public enum BossActionType
    {
        Idle,
        JumpAttack,
        CircleAttack
    }
    private BossActionType eCurState = BossActionType.Idle;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        bulletHits = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(bulletHits);
        if (health <= 0)
        {
            GameObject x = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            SceneManager.LoadScene("FutureDoneCutscene");
        }
        switch (eCurState)
        {
            case BossActionType.JumpAttack:
                transform.position = new Vector3(startingPosition.x, startingPosition.y + Mathf.PingPong(Time.time, 1), startingPosition.z);
                break;
            case BossActionType.CircleAttack:
                _angle += RotateSpeed * Time.deltaTime;
                var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle), 0) * Radius;
                transform.position = startingPosition + offset;
                break;
            case BossActionType.Idle:
                transform.position = startingPosition;
                break;
        }
        if (bulletHits == 4)
        {
            bulletHits = 0;
            if (eCurState == BossActionType.Idle)
            {
                eCurState = BossActionType.JumpAttack;
            }
            else if (eCurState == BossActionType.JumpAttack)
            {
                eCurState = BossActionType.CircleAttack;
            }
            else if (eCurState == BossActionType.CircleAttack)
            {
                eCurState = BossActionType.Idle;
            }
            Attack();
        }
    }

    private void Attack()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Instantiate(bulletPrefab, new Vector3(firepoint.position.x, firepoint.position.y + 0.2f, firepoint.position.z), firepoint.rotation);
        Instantiate(bulletPrefab, new Vector3(firepoint.position.x, firepoint.position.y + 0.3f, firepoint.position.z), firepoint.rotation);
        Instantiate(bulletPrefab, new Vector3(firepoint.position.x, firepoint.position.y + -0.2f, firepoint.position.z), firepoint.rotation);
    }

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Debug.Log(collision.gameObject.name);
            bulletHits++;
            health -= bulletDamage;
        }
    }
}
