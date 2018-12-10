using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject[] _Menu;
    public string targetMenu;

    public void HideMenu()
    {
        foreach (GameObject g in _Menu)
        {
            g.SetActive(false);
        }
    }

    public void ShowMenu()
    {
        foreach (GameObject g in _Menu)
        {
            g.SetActive(true);
        }
    }
}
