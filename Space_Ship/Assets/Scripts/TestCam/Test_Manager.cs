using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Manager : MonoBehaviour
{
    public static Test_Manager instance;
    private bool isPauseGame = false;

    private void Awake()
    {
        instance = this;
        StartCoroutine(AutoSpawnFrog());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPauseGame)
            {
                // resume game
                isPauseGame = false;
                Debug.LogError("Resume game");

                if (OnResumeGame != null)
                {
                    OnResumeGame();
                }
            }
            else
            {
                // pasue game
                isPauseGame = true;
                Debug.LogError("Pause game");

                if (OnPauseGame != null)
                {
                    OnPauseGame("hey hey");
                }
            }
        }
    }

    public Action<string> OnPauseGame; 
    /*action là một lại delegate nhưng không có kiểu trả về (void) 
      delegate là kiểu tham chiếu trong c# tới 1 hàm hoặc 1 phương thức */                            
    public Action OnResumeGame;


    IEnumerator AutoSpawnFrog()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (isPauseGame == false)
            {
                SpawnFrog();
            }
        }
    }

    [SerializeField] private GameObject frogPrefab;
    private GameObject tempFrog;
    
    private void SpawnFrog()
    {
        tempFrog = SimplePool.Spawn(frogPrefab);
        tempFrog.transform.position = new Vector3(8.8f, UnityEngine.Random.Range(-2f, 2), -1);

    }
    
}
