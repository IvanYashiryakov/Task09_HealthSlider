using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Theif))]
[RequireComponent(typeof(Animator))]

public class TheifAnimation : MonoBehaviour
{
    private const string HurtTrigger = "Hurt";
    private const string DeadTrigger = "Dead";

    private Theif _theif;
    private Animator _animator;

    private void OnEnable()
    {
        _theif.Hurted += OnHurted;
        _theif.Died += OnDied;
        _theif.Healed += OnHealed;
    }

    private void OnDisable()
    {
        _theif.Hurted -= OnHurted;
        _theif.Died -= OnDied;
        _theif.Healed -= OnHealed;
    }

    private void Awake()
    {
        _theif = GetComponent<Theif>();
        _animator = GetComponent<Animator>();
    }

    private void OnHurted()
    {
        _animator.SetTrigger(HurtTrigger);
    }

    private void OnDied()
    {
        _animator.SetTrigger(DeadTrigger);
    }

    private void OnHealed()
    {
        _animator.ResetTrigger(DeadTrigger);
        _animator.ResetTrigger(HurtTrigger);
    }
}
