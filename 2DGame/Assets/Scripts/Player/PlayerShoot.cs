using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    
    private GameObject _FirePoint;
    [SerializeField]
    private GameObject _Bomb;
    private GameObject _Weapon;
    private InputManager _PlayerInput;
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
            Instantiate(_Weapon.GetComponent<SetBullet>().bullet, _FirePoint.transform.position, _FirePoint.transform.rotation);
        }
        if (_PlayerInput.Bomb())
        {
            Instantiate(_Bomb, _FirePoint.transform.position + new Vector3(1,0,0), _FirePoint.transform.rotation);
        }
    }

    public void SetFirePoint(GameObject FirePoint)
    {
        _FirePoint = FirePoint;
    }
}
