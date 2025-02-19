using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState { IDLE, WALKING, JUMPING }
public class PLAYERMOVEMENT : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed = 3f;
    private Vector2 _dir;
    private PlayerState _currentState;
    private bool Jumping = false;
    public LayerMask groundMask;
    public AudioClip jumpingClip;
    public float JumpForce = 4f, sphereRadius = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _dir = new Vector2(Input.GetAxis("Horizontal"), 0);
      
        Jump();
        if (_dir.magnitude == 0)
        {
            _currentState = PlayerState.IDLE;
        }
        else if (_dir.magnitude != 0)
        {
            _currentState = PlayerState.WALKING;
        }
        else
        {
            _currentState = PlayerState.JUMPING;
        }


    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_dir.x * speed, _rb.velocity.y);
        ApplyForce();
    }

    public PlayerState GetCurrentState()
    {
        return _currentState;
    }

    public Vector2 GetDirection()
    {
        return _dir;
    }

    void Jump()
    {
        _currentState = PlayerState.JUMPING;
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jumping = true;
            AudioManager.instance.PlayAudio(jumpingClip, "jumpingSoundObject", false);
        }

    }

    void ApplyForce()
    {
        if (Jumping)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(Vector2.up * JumpForce * _rb.gravityScale, ForceMode2D.Impulse);
            Jumping = false;
        }
    }

    private bool IsGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2), sphereRadius, groundMask);
        return collider != null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Jumping = false;
        }
       
        
    }
}


