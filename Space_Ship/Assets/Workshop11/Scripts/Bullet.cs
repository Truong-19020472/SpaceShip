using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bullet : MonoBehaviour
{
    private GameObject enemy;
    private Rigidbody2D riBullet;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
        riBullet = GetComponent<Rigidbody2D>();
        riBullet.velocity = transform.right * 20f;
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(transform.gameObject);
    }*/
   
}

