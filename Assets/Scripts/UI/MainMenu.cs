using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] SimpleButton button1;
    [SerializeField] SimpleButton button2;
    [SerializeField] SimpleButton button3;

    [SerializeField] Image image1;
    [SerializeField] Image image2;
    [SerializeField] Image image3;


    private void Start()
    {
        button1.OnClick += ChangeRed;
        button2.OnClick += ChangeGreen;
        button3.OnClick += () => image3.color = Color.black;
    }

    void ChangeRed()
    {
        image1.color = Color.red;
    }

    void ChangeGreen() => image2.color = Color.green;

}
