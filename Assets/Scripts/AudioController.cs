using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip _delete;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(string key)
    {
        switch (key)
        {
            case "delete":
                _audioSource.clip = _delete;
                break;
        }
        _audioSource.Play();
    }
}
