using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask layer;
    public int currentJumps;

    private Rigidbody2D _Rb;
    private InputManager _Inputmanager;
    private float _MoveInput;
    private float _FallMultiplier = 2f;
    private bool _FacingRight = true;
    private bool _Grounded;
    private int _ExtraJumps;

    private void Start()
    {
        _ExtraJumps = currentJumps;
        _Inputmanager = GetComponent<InputManager>();
        _Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_Grounded)
        {
            _ExtraJumps = currentJumps;
        }

        if(_Rb.velocity.y < 0)
        {
            _Rb.velocity += Vector2.up * Physics2D.gravity.y * (_FallMultiplier - 1) * Time.deltaTime;
        }

        if (_Inputmanager.Jump() && _ExtraJumps > 0)
        {
            _Rb.velocity = Vector2.up * jumpForce;
            _ExtraJumps--;
        }else if(_Inputmanager.Jump() && _ExtraJumps == 0 && _Grounded == true)
        {
            _Rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void FixedUpdate()
    {
        _Grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, layer);

        _MoveInput = Input.GetAxisRaw("Horizontal");
        _Rb.velocity = new Vector2(_MoveInput * speed, _Rb.velocity.y);
        if(!_FacingRight && _MoveInput > 0)
        {
            Flip();
        }else if(_FacingRight && _MoveInput < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _FacingRight = !_FacingRight;
        /*Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;*/

        this.gameObject.transform.Rotate(0f, 180f, 0f);
    }
}
