using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxSpeed = 2;
    public int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;




    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

    }

    private void Start()
    {
        Init();
        health = maxHealth;
        speed = maxSpeed;
    }

    public virtual void Update()
    {
       
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        
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

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("hitten enemy");
        health -= damage;
        if (health < 1)
        {
            //Destroy(gameObject);
            Debug.Log("enemy destroyed");
            Destroy(gameObject);

        }
    }

}
