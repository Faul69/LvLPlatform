using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Active : MonoBehaviour
{
    private const string PickTrigger = "Picked";

    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    public void Pick()
    {
        _animator.SetTrigger(PickTrigger);
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
