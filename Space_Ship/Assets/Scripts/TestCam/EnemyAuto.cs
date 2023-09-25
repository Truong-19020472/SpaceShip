using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAuto : MonoBehaviour
{
    private void Start()
    {
        Test_Manager.instance.OnPauseGame += PauseGame; // nếu OnPauseGame thì dừng di chuyển
        Test_Manager.instance.OnResumeGame += ResumeGame;//ngược lại
    }

    private bool isMoving = true;
    private void PauseGame(string eventString) 
    {
        Debug.LogError(eventString);
        isMoving = false;
    }

    private void ResumeGame()
    {
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position += new Vector3(-5 * Time.deltaTime, 0, 0);
        }

        if (transform.position.x < -9)
        {
            SimplePool.Despawn(gameObject);
            //gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
