using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _child;
    private readonly WaitForSecondsRealtime _wait = new(5);

    private void FixedUpdate()
    {
        if (_child.activeSelf == false)
        {
            StartCoroutine(routine: SetActiveTrue());
        }
    }

    private IEnumerator SetActiveTrue()
    {
        yield return _wait;
        _child.SetActive(true);
    }
}
