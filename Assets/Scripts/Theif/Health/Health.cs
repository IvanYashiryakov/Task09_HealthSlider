using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private float _maxValue = 100;

    private UnityEvent _valueChanged = new UnityEvent();

    public float Value
    {
        get
        {
            return _value;
        }
    }

    public float MaxValue
    {
        get
        {
            return _maxValue;
        }
    }

    public event UnityAction ValueChanged
    {
        add => _valueChanged.AddListener(value);
        remove => _valueChanged.RemoveListener(value);
    }

    public void Heal(int healValue)
    {
        _value += healValue;

        if (_value > _maxValue)
            _value = _maxValue;

        _valueChanged.Invoke();
    }

    public void TakeDamage(int damageValue)
    {
        _value -= damageValue;

        if (_value < 0)
            _value = 0;

        _valueChanged.Invoke();
    }
}
