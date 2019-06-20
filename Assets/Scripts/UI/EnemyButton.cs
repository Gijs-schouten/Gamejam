using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButton : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private MouseInput MouseInput;
    [SerializeField] private int _enemyIndex;

    private Enemy _enemyScript;

    public void ButtonClick() 
    {
        _enemyScript = enemy.GetComponent<Enemy>();
        _enemyScript._enemyIndexNumber = _enemyIndex;

        MouseInput.TurnOnPlaceMode(enemy);
    }
}
