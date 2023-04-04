using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _child;

    private void FixedUpdate()
    {
        if (_child.activeSelf == false)
        {
            StartCoroutine(routine: SetActiveTrue());
        }
    }

    private IEnumerator SetActiveTrue()
    {
        yield return new WaitForSecondsRealtime(5);
        _child.SetActive(true);
    }
}
