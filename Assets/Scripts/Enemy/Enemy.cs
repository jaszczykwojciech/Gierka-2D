using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected bool isDead = false;

    protected bool isHit = false;

    protected Player player;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        //&& anim.GetBool("InCombat") == false
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") &&anim.GetBool("InCombat") == false )
        {
            return;
        }

        if(isDead == false)
            Movment();
    }


    public virtual void Movment()
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            //StartCoroutine(WaypointCheck(pointB, false));
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");

        }
        else if (transform.position == pointB.position)
        {
            //StartCoroutine(WaypointCheck(pointA, false));
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");

        }
        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        //
        //if (transform.name == "Skeleton_Enemy")
        //{
        //    Debug.Log("Distance:" + distance + "for " + transform.name);
        //}
        if(distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }

        
        //Debug.Log("Distance: " + distance);

        Vector3 direction = player.transform.localPosition - transform.localPosition;
        //Debug.Log("Side: " + direction.x);

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }


    }

}
