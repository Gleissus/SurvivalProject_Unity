using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] private TMP_Text XPtext;
    [SerializeField] private int currentXP = 0;


    public static UIController GetInstance() => instance;
    private void Awake()
    {
        instance = this;           
    }

    private void Start()
    {
        XPtext.text = "XP: " + currentXP.ToString();
    }

    public void IncreaseXP(int value)
    {
        currentXP += value;
        XPtext.text = "XP: " + currentXP.ToString();
    }
}
