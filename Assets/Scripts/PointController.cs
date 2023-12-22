using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables
    
    [SerializeField] private TextMeshProUGUI scoreText;

    #endregion
    
    #region Private Variables
    
    private AudioSource _audioSource;
    
    #endregion
    #endregion

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    private void Start()
    {
        scoreText.text = "Point: " + Point.score.ToString();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            _audioSource.Play();
            Point.score += 10;
            scoreText.text = "Point: " + Point.score.ToString();
        }
    }
}
