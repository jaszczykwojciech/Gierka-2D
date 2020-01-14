using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private LayerMask _groundLayer;
    private bool resetJump = false;
    [SerializeField]
    private float speed = 5.0f;
    private bool grounded = false;
    private PlayerAnimation playerAnim;
    private SpriteRenderer playerSprite;
    private SpriteRenderer swordArcSprite;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
        if(Input.GetMouseButtonDown(0) && IsGrounded() == true)
        {
            playerAnim.Attack();
        }
    }

    void Movment()
    {
        float move = Input.GetAxisRaw("Horizontal");
        grounded = IsGrounded();
        if(move > 0)
        {
            Flip(true);
        }
        else if(move < 0)
        {
            Flip(false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Debug.Log("Jump!");
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            playerAnim.Jump(true);
        }
        rigid.velocity = new Vector2(move * speed, rigid.velocity.y);
        playerAnim.Move(move);
    }

    void Flip(bool faceRight)
    {
        if(faceRight == true)
        {
            playerSprite.flipX = false;
            swordArcSprite.flipX = false;
            swordArcSprite.flipY = false;

            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = 1.49f;
            swordArcSprite.transform.localPosition = newPos;
        }
        else if (faceRight == false)
        {
            playerSprite.flipX = true;
            swordArcSprite.flipX = true;
            swordArcSprite.flipY = true;

            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = -1.49f;
            swordArcSprite.transform.localPosition = newPos;
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);

        if(hitInfo.collider != null)
        {
            if(resetJump == false)
            {
                playerAnim.Jump(false);
                return true;
            }
                
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
        
    }

}
