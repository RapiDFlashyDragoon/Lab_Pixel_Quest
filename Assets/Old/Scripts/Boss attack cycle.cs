using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack_1 : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    public BoxCollider2D collider;

    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // collider = GetComponent<BoxCollider2D>();
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        collider.enabled = false;
        //Rotate 90 deg
        _animator.SetBool(Structs.AnimationParameters.Attack_1, true);

        //Wait for 4 seconds
        yield return new WaitForSeconds(4);

        //Rotate 40 deg
        _animator.SetBool(Structs.AnimationParameters.Attack_1, false);

        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
        collider.enabled = true;

        isChasing = true; 

    }

    void Update()
    {
        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 1;
                }
            }
            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 0;
                }
            }
        }



    }
}

