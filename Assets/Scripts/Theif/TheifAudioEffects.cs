using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Theif))]
[RequireComponent(typeof(AudioSource))]

public class TheifAudioEffects : MonoBehaviour
{
    [SerializeField] private AudioClip _healSound;
    [SerializeField] private AudioClip _hurtSound;

    [Range(0.0f, 1f)]
    [SerializeField] private float _volume;

    private Theif _theif;
    private AudioSource _audio;

    private void OnEnable()
    {
        _theif = GetComponent<Theif>();
        _audio = GetComponent<AudioSource>();
        _theif.Hurted += OnHurted;
        _theif.Healed += OnHealed;
    }

    private void OnDisable()
    {
        _theif.Hurted -= OnHurted;
        _theif.Healed -= OnHealed;
    }

    private void OnHurted()
    {
        _audio.PlayOneShot(_hurtSound, _volume);
    }

    private void OnHealed()
    {
        _audio.PlayOneShot(_healSound, _volume);
    }
}
