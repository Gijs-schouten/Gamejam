﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    private GameObject _currentEnemy;

    public GameObject _getCurrentEnemy() {
        return _currentEnemy;
    }
    public bool CanPlaceEnemyHere() //testen
    {
        return _currentEnemy == null;
    }
    public void addEnemy(GameObject enemy) {
        if (_currentEnemy == null) {
            enemy.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            _currentEnemy = enemy;
        }
    }
    public void RemoveEnemy() {
        Destroy(_currentEnemy);
        _currentEnemy = null;
    }
}
