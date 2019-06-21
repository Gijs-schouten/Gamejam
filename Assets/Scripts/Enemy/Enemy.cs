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

	private Animator _player;

    [SerializeField]
    private DestinationPoint _destinationPointScript;

    private SpriteManager _spriteManager;

    public SplashOnDeath _splashOnDeath;

    private void Start() {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _destinationPoint = GameObject.Find("DeathPoint").transform;
        _destinationPointScript = _destinationPoint.GetComponent<DestinationPoint>();
        _spriteManager = GameObject.Find("SpriteManager").GetComponent<SpriteManager>();
		_player = GameObject.Find("Player").GetComponent<Animator>();
		_spriteManager.InitSprite(gameObject);

        _splashOnDeath = GameObject.Find("OnDeath").GetComponent<SplashOnDeath>();
    }

    private void Update() {
        if (_canMove) {
            MovementToDestinationPoint(_destinationPoint);
        }

    }

    private void MovementToDestinationPoint(Transform destinationPoint) {
        if (!_destinationPointScript._enemyIsOnPoint) {
            transform.position = Vector3.MoveTowards(this.transform.position, destinationPoint.transform.position, _enemySpeed * Time.deltaTime);
        }

        if (this.transform.position == destinationPoint.transform.position) {
            _destinationPointScript._enemyIsOnPoint = true;
            OnReachingDestinationPoint(_isDead);
        }
		if (this.transform.position.x >= destinationPoint.transform.position.x -4) {
			_player.SetBool("shoot", true);
		}
	}

    private void OnReachingDestinationPoint(bool isDead) {
        if (!isDead) {
			
			StartCoroutine(OnDeathSequence());
        }
    }

    IEnumerator OnDeathSequence() {
        _audioManager.PlayAudioClip(_enemyIndexNumber);
        _splashOnDeath.SplashDeath();
        yield return new WaitForSeconds(_audioManager._source.clip.length);
        _destinationPointScript._enemyIsOnPoint = false;
        Destroy(this.gameObject);
    }

	public void Aniamtoekasmnkenko() {
		_player.SetBool("shoot", false);
	}
}
