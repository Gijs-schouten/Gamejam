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

    /*
     * Schakel in enemy de dood om naar destroy en niet setActive
     * BeginSequenceTimer een action aanmaken en hier laten aanmelden
     */

    void Start() {
        //meld hier de functie: ChangeGameGoing aan de action
        _timer.Going += ChangeGameGoing;
    }

    void Update() {
        EnemiesRemoved();
    }

    public void SetupCanvasActive() {
        ChangeCanvasActive();
        _canvasHandler.ChangeText(_checker.CheckSequence());
    }

    public void ChangeCanvasActive() {
        _canvasHandler.SetCanvasActive(true);
    }

    public void ChangeCanvasDeactive() {
        _canvasHandler.SetCanvasActive(false);
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
            SetupCanvasActive();
            ChangeGameGoing();
        }
    }

    private void ChangeGameGoing() {
        _gameGoing = !_gameGoing;
    }
}
