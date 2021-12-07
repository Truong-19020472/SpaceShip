using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageG : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    int scorePlayer = 0;
    int scoreEnemy = 0 ;
    public Rigidbody2D ball;
    public static ManageG instance;

    [SerializeField] private Button restart;
    [SerializeField] private Button exit, Music, NoMusic;
    [SerializeField] private Image lost, win;
    [SerializeField] private GameObject popup;

    [SerializeField] private AudioSource sourceInGame;
    [SerializeField] private AudioClip clap, finishLevel;
    void Awake() {
        if(instance == null) {
            instance = this;
        }
        else{
            Destroy(gameObject);
            }
        popup.SetActive(false);
        //
        // lost.enabled = false;
        // win.enabled = false;
        // Time.timeScale = 0;
        //
        restart.onClick.AddListener(PlayAgain);
        exit.onClick.AddListener(Exit);
        Music.onClick.AddListener(TurnOffMusic);
        NoMusic.onClick.AddListener(TurnOnMusic);
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(football.isGoUp) {
            ball.AddForce(new Vector2(3,3), ForceMode2D.Force);
        }
        else ball.AddForce(new Vector2(-3,-3), ForceMode2D.Force);
    }
    public void ChangeScore(bool playerWin) {
        if(playerWin) {
            scorePlayer ++;
        }
        else scoreEnemy ++;
        DisplayScore();
        
    }
    void DisplayScore() {
        score.text = scorePlayer + " - " + scoreEnemy;
        if(PlayMusic) {
            sourceInGame.PlayOneShot(clap);
        }
        EndRound();
    }
    private void PlayAgain(){
        popup.SetActive(false);
        NewGame();
    }
    private void Exit(){
        // UnityEditor.EditorApplication.isPlaying = false;
        SceneManager.LoadScene("GoalMenu");
    }
    void NewGame() {
        scorePlayer = 0;
        scoreEnemy = 0;
        win.enabled = false;
        lost.enabled = false;
        Time.timeScale = 1;
        DisplayScore();
    }
    void EndRound(){
        if(scorePlayer == 5 || scoreEnemy == 5) {
            Time.timeScale = 0;
            popup.SetActive(true);
            if(PlayMusic) {
                sourceInGame.PlayOneShot(finishLevel);
            }
            
            if(scorePlayer > scoreEnemy) {
                win.enabled = true;
            }
            else lost.enabled = true;
        }
    }
    private bool PlayMusic = true;
    void TurnOffMusic() {
        NoMusic.enabled = true;
        Music.enabled = false;
        NoMusic.gameObject.GetComponent<Image>().enabled = true;
        Music.gameObject.GetComponent<Image>().enabled = false;
        PlayMusic = false;
    }
    void TurnOnMusic(){
        NoMusic.enabled = false;
        Music.enabled = true;
         NoMusic.gameObject.GetComponent<Image>().enabled = false;
        Music.gameObject.GetComponent<Image>().enabled = true;
        PlayMusic = true;
    }
    
}
