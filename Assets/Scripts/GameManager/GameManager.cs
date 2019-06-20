using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CanvasHandler _canvasHandler;
    [SerializeField]
    private Checker _checker;
    [SerializeField]
    private GridSystem _gridSystem;
    private bool _gameGoing = false;

    /*
     * Schakel in enemy de dood om naar destroy en niet setActive
     * BeginSequenceTimer een action aanmaken en hier laten aanmelden
     */

    void Start() {
        //meld hier de functie: ChangeGameGoing aan de action
    }

    void Update() {
        EnemiesRemoved();
    }

    private void SetupCanvasActive() {
        ChangeCanvasActive();
        _canvasHandler.ChangeText(_checker.CheckSequence());
    }

    private void ChangeCanvasActive() {
        _canvasHandler.SetCanvasActive();
    }

    private void EnemiesRemoved() {
        int amount = _gridSystem.GetAllEnemyInNodes().Count;
        if (amount <= 0 && _gameGoing) {
            SetupCanvasActive();
        }
    }

    private void ChangeGameGoing() {
        _gameGoing = !_gameGoing;
    }
}
