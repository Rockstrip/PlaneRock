using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameOver : MonoBehaviour
{
    [SerializeField] private PlaneController planeController;
    [SerializeField] private GameObject content;

    private void OnEnable()
    {
        planeController.barrierEntered.AddListener(OnBarrierEntered);
    }  
    private void OnDisable()
    {
        planeController.barrierEntered.RemoveListener(OnBarrierEntered);
    }

    private void OnBarrierEntered()
    {
        Time.timeScale = 0f;
        content.SetActive(true);
    }

    public void OnButtonRetryClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
