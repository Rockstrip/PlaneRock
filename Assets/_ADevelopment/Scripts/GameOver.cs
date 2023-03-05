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
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        audioSource.clip = audioClip;
    }
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
        audioSource.Play();
        content.SetActive(true);
    }
}
