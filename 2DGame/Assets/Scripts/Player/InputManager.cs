using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public bool Shoot()
    {
        return Input.GetKeyDown(KeyCode.W);
    }

    public bool Jump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool Bomb()
    {
        return Input.GetKeyDown(KeyCode.R);
    }

    public bool WeaponSwitchUp()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    public bool WeaponSwitchDown()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }
}
