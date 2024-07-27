using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _counter.Changed += DisplayCount;
    }

    private void OnDisable()
    {
        _counter.Changed -= DisplayCount;
    }

    private void DisplayCount(int count) =>
        _text.text = count.ToString();
    
}
