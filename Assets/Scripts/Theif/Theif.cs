using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]

public class Theif : MonoBehaviour
{
    private UnityEvent _died = new UnityEvent();
    private UnityEvent _hurted = new UnityEvent();
    private UnityEvent _healed = new UnityEvent();
    private Health _health;

    public bool IsDead => _health.Value <= 0;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    public event UnityAction Hurted
    {
        add => _hurted.AddListener(value);
        remove => _hurted.RemoveListener(value);
    }

    public event UnityAction Died
    {
        add => _died.AddListener(value);
        remove => _died.RemoveListener(value);
    }

    public event UnityAction Healed
    {
        add => _healed.AddListener(value);
        remove => _healed.RemoveListener(value);
    }

    public void TakeDamage(int damageValue)
    {
        _health.TakeDamage(damageValue);
        _hurted.Invoke();

        if (IsDead)
        {
            _died.Invoke();
        }
    }

    public void Heal(int healValue)
    {
        _health.Heal(healValue);
        _healed.Invoke();
    }
}
