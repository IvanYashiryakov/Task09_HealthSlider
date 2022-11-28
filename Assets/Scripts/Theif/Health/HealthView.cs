using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _changeSpeed = 2;

    private Health _health;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _health = GetComponent<Health>();
        _health.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnValueChanged;
    }

    private void Start()
    {
        SetSliderValue();
    }

    private void OnValueChanged()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeSliderValue());
    }

    private void SetSliderValue()
    {
        _slider.value = _health.Value / _health.MaxValue;
        Debug.Log(_health.Value / _health.MaxValue);
    }

    private IEnumerator ChangeSliderValue()
    {
        float target = _health.Value / _health.MaxValue;

        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _changeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
