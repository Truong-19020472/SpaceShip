using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class football : MonoBehaviour
{
    Rigidbody2D riBall;
    public GameObject player;
    public GameObject enemy;
    Vector3 beginPosition;
    public static bool isGoUp = true;
    // Start is called before the first frame update
    void Start()
    {
        beginPosition = transform.position;
        riBall = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        riBall.velocity = Vector2.ClampMagnitude(riBall.velocity, 15);
        if(transform.position.y < -5.3f || transform.position.y > 5.3f) {
            transform.position = beginPosition; 
            riBall.velocity = Vector2.zero;
            riBall.isKinematic = true;
            StartCoroutine(Sleep());
        }
    }
    void OnCollisionEnter2D (Collision2D other) {
        if(other.gameObject.name == "Keeper") {
            riBall.AddForce(-(player.transform.position - transform.position) , ForceMode2D.Impulse);
            isGoUp = true;
            // riBall.velocity = -(player.transform.position - transform.position)*10;
        }
        if(other.gameObject.name == "Enemy") {
            riBall.AddForce((transform.position - enemy.transform.position), ForceMode2D.Impulse);
            isGoUp = false;
        }

    }
    public Text score;
    int scorePlayer = 0;
    int scoreEnemy = 0 ;
    void OnTriggerEnter2D (Collider2D other) {
        if(other.gameObject.name == "GoalEnemy") {
            scorePlayer ++;
            score.text = scorePlayer + " - " + scoreEnemy;
        }
        else{
            scoreEnemy ++;
            score.text = scorePlayer + " - " + scoreEnemy;
        }
    }
    IEnumerator Sleep() {
        yield return new WaitForSeconds(0.5f);
        riBall.isKinematic = false;
        
    }
}
