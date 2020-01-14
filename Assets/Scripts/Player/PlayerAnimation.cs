using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Animator swordAnimation;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        swordAnimation = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Move(float move)
    {
        //anim set float move
        anim.SetFloat("Move", Mathf.Abs(move));

    }

    public void Jump(bool jumping)
    {
        anim.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        swordAnimation.SetTrigger("SwordAnimation");
    }
}
