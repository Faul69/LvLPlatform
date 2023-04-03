using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CoinBehaviour : MonoBehaviour
{
    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    public void Pick()
    {
        _animator.SetTrigger("Picked");
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
