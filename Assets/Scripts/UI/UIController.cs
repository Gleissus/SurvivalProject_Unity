using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] private TMP_Text XPtext;
    [SerializeField] private TMP_Text Leveltext;
    [SerializeField] private TMP_Text WaveLevelText;
    
   

    public static UIController GetInstance() => instance;
    private void Awake()
    {
        instance = this;           
    }

    private void Start()
    {
        XPtext.text = "XP: 0";
        Leveltext.text = "LEVEL: 0";
        WaveLevelText.text = "WAVE: 1";
    }

    public void PrintXPAmount(int value)
    {
        XPtext.text = "XP: " + value.ToString();
    }

    public void PrintLevelAmount(int value)
    {
        Leveltext.text = "LEVEL: " + value.ToString();
    }

    public void PrintWaveLevel(int value)
    {
        WaveLevelText.text = "WAVE: " + value.ToString();
    }
}
