using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    public event UnityAction<int> Changed;

    private Coroutine _coroutine;

    private float _delay = 0.5f;
    private int _currentCount = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Switch();
        }
    }

    private void Switch()
    {
        if (_coroutine == null)
        {
            Restart();
        }
        else
        {
            Stop();
        }
    }

    private void Stop()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private void Restart()
    {
        _coroutine = StartCoroutine(Countup(_delay));
    }

    private IEnumerator Countup(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            _currentCount++;
            Changed?.Invoke(_currentCount);

            yield return wait;
        }
    }
}