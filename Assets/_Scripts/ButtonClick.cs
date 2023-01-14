using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [NonSerialized] public bool IsRestartClicked;
    [NonSerialized] public bool IsStartClicked;
    [NonSerialized] public bool IsEndRestartClicked;
    
    // Вызов функций при нажатии на кнопку
    public void IsRestartClick()
    {
        IsRestartClicked = true;
    }

    public void IsStartClick()
    {
        IsStartClicked = true;
    }

    public void IsEndRestartClick()
    {
        IsEndRestartClicked = true;
    }
}
