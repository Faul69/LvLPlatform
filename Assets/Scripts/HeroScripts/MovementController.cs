using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Transform))]

public class MovementController : MonoBehaviour
{
    private const string JumpTrigger = "IsJump";
    private const string RunTrigger = "IsRunning";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Transform _transform;

    private void OnEnable()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SetTriggerTrue(RunTrigger, JumpTrigger);
            _spriteRenderer.flipX = false;
            _transform.Translate(_speed * Time.deltaTime * Vector3.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            SetTriggerTrue(RunTrigger, JumpTrigger);
            _spriteRenderer.flipX = true;
            _transform.Translate(_speed * Time.deltaTime * Vector3.left);
        }
        else
        {
            _animator.SetBool(RunTrigger, false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _animator.SetBool(RunTrigger, false);
            _animator.SetBool(JumpTrigger, true);
            _transform.Translate(0, _speed * Time.deltaTime * _jumpForse, 0);
        }
        else
        {
            _animator.SetBool(JumpTrigger, false);
        }
    }

    private void SetTriggerTrue(string toTrueTrigger, string needFalseTrigger)
    {
        if (_animator.GetBool(needFalseTrigger) == false)
        {
            _animator.SetBool(toTrueTrigger, true);
        }
    }

}
