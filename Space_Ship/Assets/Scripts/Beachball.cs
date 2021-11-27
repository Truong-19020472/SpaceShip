using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Beachball : MonoBehaviour
{
    Vector2 begin;
    Rigidbody2D riball;
    public Text score;
    int scorePlayer;
    int scoreEnemy;
    int numberBall ;

    public SpriteRenderer defeat;
    public SpriteRenderer victory;
    // Start is called before the first frame update
    void Start()
    {
     begin = transform.position;   
     riball = GetComponent<Rigidbody2D>();
     numberBall = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(scorePlayer == (numberBall/2) + 1 || scoreEnemy == (numberBall/2) + 1) {
            Time.timeScale = 0;
            if(scorePlayer > scoreEnemy) {
                
                victory.enabled = true;
            }
            else 
            defeat.enabled = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "player") 
        {
            riball.velocity = new Vector2(8,10);
            return;
        }
        if(other.gameObject.name == "enemy") 
        {
            riball.velocity = new Vector2 (-8,10);
            return;
        }
        if(other.gameObject.name == "brick") 
        {

            if(transform.position.x > 0) {
                scorePlayer ++;
                score.text = scorePlayer + " - " + scoreEnemy;
                // numberBall--;
            }
            else {
                scoreEnemy ++;
                score.text = scorePlayer + " - " + scoreEnemy;
                // numberBall--;
            }
            transform.position = begin;
            riball.velocity = Vector2.zero;
            riball.isKinematic = true;
            StartCoroutine(SleepForNextTurn());
        }
    }
    IEnumerator SleepForNextTurn() {
        yield return new WaitForSeconds(2f);
        riball.isKinematic = false;
    }
}
