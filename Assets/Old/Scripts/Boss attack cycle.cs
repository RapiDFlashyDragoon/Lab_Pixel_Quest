using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack_1 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        //Rotate 90 deg
        _animator.SetBool(Structs.AnimationParameters.Attack_1, true);

        //Wait for 4 seconds
        yield return new WaitForSeconds(4);

        //Rotate 40 deg
        _animator.SetBool(Structs.AnimationParameters.Attack_1, false);

        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
    }
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody2D.velocity.x != 0 || _rigidbody2D.velocity.y != 0)
        {
            _animator.SetBool(Structs.AnimationParameters.Attack_1, true);
        }
        else
        {
            _animator.SetBool(Structs.AnimationParameters.Attack_1, false);
        }
    }
}
