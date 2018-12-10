using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu {

    private void Start()
    {
       _Menu = GameObject.FindGameObjectsWithTag(targetMenu);

        HideMenu();
    }

    public void PauseControl()
    { 
        if(Time.timeScale > 0)
        {
            Time.timeScale = 0;
            ShowMenu();
        }else if(Time.timeScale <= 0)
        {
            Time.timeScale = 1;
            HideMenu();
        }
    }
}
    