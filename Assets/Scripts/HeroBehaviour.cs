using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class HeroBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;

    private Transform _transform;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public void EndTakeDamage()
    {
        _animator.SetBool("IsDamage", false);
    }

    private void Update()
    {
        Move();
    }

    private void OnEnable()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CoinBehaviour>(out CoinBehaviour coin))
        {
            coin.Pick();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<TilemapCollider2D>(out TilemapCollider2D tilemapCollider))
        {
            _animator.SetBool("IsGround", true);
        }

        if (collision.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy))
        {
            _animator.SetBool("IsDamage", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<TilemapCollider2D>(out TilemapCollider2D tilemapCollider))
        {
            _animator.SetBool("IsGround", false);
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (_animator.GetBool("IsJump") == false)
            {
                _animator.SetBool("IsRunning", true);
            }

            _spriteRenderer.flipX = false;
            _transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_animator.GetBool("IsJump") == false)
            {
                _animator.SetBool("IsRunning", true);
            }

            _spriteRenderer.flipX = true;
            _transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsJump", true);
            _transform.Translate(0, _speed * Time.deltaTime * _jumpForse, 0);
        }
        else
        {
            _animator.SetBool("IsJump", false);
        }
    }
}
