using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip[] _clips;
    public AudioClip _blankNoise;
    public AudioSource _source;

    void Awake() {
        _source = gameObject.GetComponent<AudioSource>();
    }

    public void PlayAudioClip(int _enemyID) {
        if (_enemyID == -1) {
            _source.clip = _blankNoise;
        } else {
            _source.clip = _clips[_enemyID];
        }
        _source.Play();
    }
}
