using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    float _speed { get; }
    float _AOE { get; }
    int _damage { get; }
    LayerMask _destructible { get; }
    
    void OnTriggerEnter2D(Collider2D other);
}
