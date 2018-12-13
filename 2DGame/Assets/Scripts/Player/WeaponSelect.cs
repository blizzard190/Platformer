using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour {

    public GameObject CurrentWeapon;
    public List<GameObject> _Weapons;

    private GameObject _SelectedWeapon;
    private PlayerShoot _PlayerShoot;
    private int _weapon;
    private InputManager _playerInput;

    void Start()
    {
        _weapon = 0;
        _playerInput = GetComponent<InputManager>();
        CurrentWeapon = _Weapons[_weapon];
        _SelectedWeapon = CurrentWeapon;
        _PlayerShoot = GetComponent<PlayerShoot>();
        WeaponSpawn();
    }

    void Update()
    {
        if (_playerInput.WeaponSwitchUp())
        {
            _weapon++;
            SwitchUp();
        }
        if (_playerInput.WeaponSwitchDown())
        {
            SwitchDown();
            //_weapon--;
        }
    }

    private void SwitchDown()
    {
        if (_weapon == 0)
        {
            _weapon = _Weapons.Count - 1;
            Destroy(_SelectedWeapon);
            CurrentWeapon = _Weapons[_weapon];
        }else
        {
            _weapon--;
            Destroy(_SelectedWeapon);
            CurrentWeapon = _Weapons[_weapon];
        }
        WeaponSpawn();
    }

    private void SwitchUp()
    {
        if (_weapon == _Weapons.Count)
        {
            _weapon = 0;
            Destroy(_SelectedWeapon);
            CurrentWeapon = _Weapons[_weapon];
        }
        else
        {
            Destroy(_SelectedWeapon);
            CurrentWeapon = _Weapons[_weapon];
        }
        WeaponSpawn();
    }

    private void WeaponSpawn()
    {
        GameObject Target = this.transform.GetChild(1).gameObject;
        _SelectedWeapon = Instantiate(CurrentWeapon, Target.transform.position, Target.transform.rotation) as GameObject;
        _SelectedWeapon.transform.parent = Target.gameObject.transform;
        _PlayerShoot.SetFirePoint(_SelectedWeapon.transform.GetChild(0).gameObject);
    }
}
