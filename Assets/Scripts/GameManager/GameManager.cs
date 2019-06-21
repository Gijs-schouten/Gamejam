using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private CanvasHandler _canvasHandler;
    [SerializeField]
    private Checker _checker;
    [SerializeField]
    private GridSystem _gridSystem;
    [SerializeField]
    private BeginSequenceTimer _timer;
    private bool _gameGoing = false;
    [SerializeField]
    private int maxLevel;
    [SerializeField]
    private SceneSwitcher _SceneSwitcher;
	

    void Start() {
        _timer.Going += ChangeGameGoing;
    }

    void Update() {
        EnemiesRemoved();
    }

    public void SetupCanvasActive() {
        if (_gridSystem.GetGridLengt() == maxLevel) {
            _SceneSwitcher.SwitchScenes(2);
            //_canvasHandler.SetCanvasActive(false);
            //_canvasHandler.ChangeText(true);
        } else {
            if (_checker.CheckSequence() == false) {
                _SceneSwitcher.SwitchScenes(3);
            }
            ChangeCanvasActive();
            _canvasHandler.ChangeText(false);
        }
    }

    public void ChangeCanvasActive() {
        _canvasHandler.SetCanvasActive(_checker.CheckSequence());
    }

    public void ChangeCanvasDeactive() {
        _canvasHandler.DeactivateCanvases();
    }

    private void EnemiesRemoved() {
        List<GameObject> enemyList = _gridSystem.GetAllEnemyInNodesAsGameObject();
        int amount = 0;
        for (int i = 0; i < enemyList.Count; i++) {
            if (enemyList[i] != null) {
                amount++;
            }
        }
        if (amount <= 0 && _gameGoing) {
			ChangeGameGoing();
            SetupCanvasActive();

        }
    }

    private void ChangeGameGoing() {
        _gameGoing = !_gameGoing;
    }

    public bool GetGameGoing() {
        return _gameGoing;
    }

}
