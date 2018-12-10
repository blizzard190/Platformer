using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase {
    private Rigidbody2D _Rb;

	void Start () {
        _Rb = GetComponent<Rigidbody2D>();
        _Rb.velocity = transform.right * speed;
	}

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
