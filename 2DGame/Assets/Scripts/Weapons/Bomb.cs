using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    [SerializeField]
    private float _AOE;
    public float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Collider2D[] objToDamage = Physics2D.OverlapCircleAll(transform.position, _AOE);
            foreach(Collider2D g in objToDamage)
            {
                if(g.GetComponent<Destruction>())
                    GetComponent<Destruction>().health -= 1;
            }
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _AOE);
    }
}
