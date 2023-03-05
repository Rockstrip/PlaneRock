using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
public class MenuController : MonoBehaviour
{
    public GameObject panel;

    public void OpenPanel()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

}
