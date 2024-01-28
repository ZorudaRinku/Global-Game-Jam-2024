using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (Character.movement.y)
        {
            case > 0:
                _animator.SetBool("WalkUp", true);
                break;
            case < 0:
                _animator.SetBool("WalkDown", true);
                break;
            default:
                _animator.SetBool("WalkUp", false);
                _animator.SetBool("WalkDown", false);
                break;
        }
        switch (Character.movement.x)
        {
            case > 0:
                _animator.SetBool("WalkRight", true);
                break;
            case < 0:
                _animator.SetBool("WalkLeft", true);
                break;
            default:
                _animator.SetBool("WalkRight", false);
                _animator.SetBool("WalkLeft", false);
                break;
        }

        //if (Character.isAttacking)
        //{
            
        //}
    }
}
