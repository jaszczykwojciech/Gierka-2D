using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private LayerMask _groundLayer;
    private bool _resetJump = false;
    [SerializeField]
    private float _speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movment();        
    }

    void Movment()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Debug.Log("Jump!");
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);

        if(hitInfo.collider != null)
        {
            if(_resetJump == false)
                return true;
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
        
    }

}
