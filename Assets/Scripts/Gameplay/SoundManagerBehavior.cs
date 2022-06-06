using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerBehavior : MonoBehaviour
{
    private static AudioSource _source;
    private static AudioClip _clipToPlay;
    private static bool _playClip;

    public static bool PlayClip { get => _playClip; set => _playClip = value; }
    public static AudioSource Source { get => _source; }

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (PlayClip)
        {
            _source.Play();
            PlayClip = false;
        }
    }

    static public void setSoundClip(AudioClip clip)
    {
        _clipToPlay = clip;
        _source.clip = _clipToPlay;
    }
}
