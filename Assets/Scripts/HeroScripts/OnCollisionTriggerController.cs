using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Animator))]

public class OnCollisionTriggerController : MonoBehaviour
{
    private const string GroundTrigger = "IsGround";
    private const string DamageTrigger = "IsDamage";

    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ActiveController>(out ActiveController coin))
        {
            coin.Pick();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<TilemapCollider2D>(out TilemapCollider2D tilemapCollider))
        {
            _animator.SetBool(GroundTrigger, true);
        }

        if (collision.gameObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy))
        {
            _animator.SetBool(DamageTrigger, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<TilemapCollider2D>(out TilemapCollider2D tilemapCollider))
        {
            _animator.SetBool(GroundTrigger, false);
        }
    }

    public void EndTakeDamage()
    {
        _animator.SetBool(DamageTrigger, false);
    }
}
