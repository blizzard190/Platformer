using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    [SerializeField]
    private GameObject _FirePoint;
    private InputManager _PlayerInput;
    private GameObject _Weapon;
    private WeaponSelect _Weapons;

    void Start()
    {
        _PlayerInput = GetComponent<InputManager>();
        _Weapons = GetComponent<WeaponSelect>();
    }

    void Update()
    {
        if (_PlayerInput.Shoot())
        {
            _Weapon = _Weapons.CurrentWeapon;
            Instantiate(_Weapon, _FirePoint.transform.position, _FirePoint.transform.rotation);
        }
    }
}
