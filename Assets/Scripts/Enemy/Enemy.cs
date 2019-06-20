using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private bool _isDead = false;

    [SerializeField]
    private AudioClip[] _audioNotes;
    [SerializeField]
    private AudioSource _audioNote;

    [SerializeField]
    private Transform _destinationPoint;

    [SerializeField]
    private float _enemySpeed;

    [SerializeField]
    private int _enemyIndexNumber;

    private void Start() {
        SetAudioSource(_audioNotes, _audioNote, _enemyIndexNumber);
    }

    private void Update() {
        MovementToDestinationPoint(_destinationPoint);
    }

    private void SetAudioSource(AudioClip[] audioNotes, AudioSource audioNote, int indexNumber) {
        audioNote.clip = audioNotes[indexNumber];
    }

    private void MovementToDestinationPoint(Transform destinationPoint) {
        transform.position = Vector3.MoveTowards(this.transform.position, destinationPoint.transform.position, _enemySpeed * Time.deltaTime);

        if (this.transform.position == destinationPoint.transform.position) {
            OnReachingDestinationPoint(_isDead);
        }
    }

    private void OnReachingDestinationPoint(bool isDead) {
        if (!isDead) {
            StartCoroutine(OnDeathSequence(_audioNote));
        }
    }

    IEnumerator OnDeathSequence(AudioSource audioNote) {
        audioNote.Play();
        yield return new WaitForSeconds(audioNote.clip.length);
        gameObject.SetActive(false);
    }
}
