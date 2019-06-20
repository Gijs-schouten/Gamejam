using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButton : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private MouseInput MouseInput;
    [SerializeField] private int _enemyIndex;

    private AudioManager _audioManager;
    [SerializeField] private MouseInput _mouseInput;
    private Enemy _enemyScript;

    private void Start() {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void ButtonClick() 
    {
        //it's funny because it's true
        if (_mouseInput._canbuild != false) {
            MouseInput.DestroyBuildable();
        }
        if (_mouseInput._canbuild == false) {
            _enemyScript = enemy.GetComponent<Enemy>();
            _enemyScript._enemyIndexNumber = _enemyIndex;
            _audioManager.PlayAudioClip(_enemyIndex);
            MouseInput.TurnOnPlaceMode(enemy);
        }

    }
}
