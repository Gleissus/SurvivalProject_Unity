using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] SimpleButton StartButton;
    [SerializeField] SimpleButton ExitButton;
  


    private void Start()
    {
        StartButton.OnClick += StartGame;
        ExitButton.OnClick += ExitGame;
        
    }

    private void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

}
