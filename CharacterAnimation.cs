using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;

    public bool IsMoving { private get; set; }

    public void Jump()
    {
        _animator.SetTrigger("Jump");
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _animator.SetBool("IsMoving", IsMoving);
    }
}
