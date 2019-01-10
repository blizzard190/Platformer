using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour, IWeapon {

    [SerializeField]
    private float AOE;
    public LayerMask des;
    public float timer;
    public float speed;
    public int damage;

    public virtual float _AOE
    {
        get
        {
            return AOE;
        }
    }

    public virtual int _damage
    {
        get
        {
            return damage;
        }
    }

    public LayerMask _destructible
    {
        get
        {
            return des;
        }
    }

    public virtual float _speed
    {
        get
        {
            return speed;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Envirment") || other.CompareTag("Enemy") || other.CompareTag("Destructable"))
        {
            Collider2D[] objToDamage = Physics2D.OverlapCircleAll(transform.position, AOE, _destructible);
            for (int i = 0; i < objToDamage.Length; i++)
            {
                objToDamage[i].GetComponent<Destruction>().health -= _damage;
                Debug.Log(objToDamage[i].GetComponent<Destruction>().health);
            }
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AOE);
    }
}
