using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private bool _isDead = false;
    public bool _canMove = false;

    private Transform _destinationPoint;

    [SerializeField] private float _enemySpeed;

    public int _enemyIndexNumber;

    private AudioManager _audioManager;

    private void Start() {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _destinationPoint = GameObject.Find("DeathPoint").transform;
    }

    private void Update() {
        if(_canMove) {
            MovementToDestinationPoint(_destinationPoint);
        }

    }

    private void MovementToDestinationPoint(Transform destinationPoint) {
        transform.position = Vector3.MoveTowards(this.transform.position, destinationPoint.transform.position, _enemySpeed * Time.deltaTime);

        if (this.transform.position == destinationPoint.transform.position) {
            OnReachingDestinationPoint(_isDead);
        }
    }

    private void OnReachingDestinationPoint(bool isDead) {
        if (!isDead) {
            StartCoroutine(OnDeathSequence());
        }
    }

    IEnumerator OnDeathSequence() {
        _audioManager.PlayAudioClip(_enemyIndexNumber);
        yield return new WaitForSeconds(_audioManager._source.clip.length);
        gameObject.SetActive(false);
    }
}
