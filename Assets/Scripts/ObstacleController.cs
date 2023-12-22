using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Point.score = 0;
            Lives.lives--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
