using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public AudioClip musicMenu;
    [SerializeField]private AudioSource sourceMenu;
    private void Awake() {
        sourceMenu.PlayOneShot(musicMenu);
    }
    public void PlayButton(){
        SceneManager.LoadScene("GoalKeeper");
    }
}
