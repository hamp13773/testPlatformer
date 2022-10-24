using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterAnimation : MonoBehaviour
{
    private const string _isMoving = "IsMoving";
    private const string _isJump = "Jump";

    private Animator _animator;

    public bool IsMoving { private get; set; }

    public void Jump()
    {
        _animator.SetTrigger(_isJump);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _animator.SetBool(_isMoving, IsMoving);
    }
}
