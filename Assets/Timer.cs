using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private bool _isButtonPressed = false;

    private void Start()
    {
        _text.text = "";

        StartCoroutine(Countup());
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _isButtonPressed = _isButtonPressed == false;
        }
    }

    private IEnumerator Countup()
    {
        float delay = 0.5f;
        int count = 0;

        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return new WaitUntil(() => _isButtonPressed);

            DisplayCountup(count);
            count++;
            yield return wait;
        }
    }

    private void DisplayCountup(int count)
    {
        _text.text = count.ToString("");
    }
}