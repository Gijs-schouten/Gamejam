using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] _clips;
    private AudioSource _source;

    void Awake() {
        _source = gameObject.GetComponent<AudioSource>();
    }

    void PlayAudioClip(int _enemyID) {
        _source.clip = _clips[_enemyID];
        _source.Play();
    }
}
