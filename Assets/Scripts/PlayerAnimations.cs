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
        // Ugly
        _animator.speed = Character.movement.magnitude <= 0.10 ? 0 : 1;
        
        switch (Character.movement.y)
        {
            case > 0 when Character.movement.x == 0:
                _animator.SetBool("WalkUp", true);
                _animator.SetBool("WalkDown", false);
                _animator.SetBool("WalkRight", false);
                _animator.SetBool("WalkLeft", false);
                break;
            case < 0 when Character.movement.x == 0:
                _animator.SetBool("WalkDown", true);
                _animator.SetBool("WalkUp", false);
                _animator.SetBool("WalkRight", false);
                _animator.SetBool("WalkLeft", false);
                break;
        }

        switch (Character.movement.x)
        {
            case > 0 when Character.movement.y == 0:
                _animator.SetBool("WalkRight", true);
                _animator.SetBool("WalkLeft", false);
                _animator.SetBool("WalkUp", false);
                _animator.SetBool("WalkDown", false);
                break;
            case < 0 when Character.movement.y == 0:
                _animator.SetBool("WalkLeft", true);
                _animator.SetBool("WalkRight", false);
                _animator.SetBool("WalkUp", false);
                _animator.SetBool("WalkDown", false);
                break;
        }
    }
}
