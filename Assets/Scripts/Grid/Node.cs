using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour 
{
    private GameObject _currentEnemy;
    public int nodeIndex;


    public bool CanPlaceEnemyHere() 
    {//testen
        return _currentEnemy == null;
    }
    public void addEnemy(GameObject enemy) 
    {
        if (_currentEnemy == null) 
        {

            enemy.transform.position = transform.position;
            _currentEnemy = enemy;
            //add to all node list
        }
    }
    public void RemoveEnemy() 
    {
        _currentEnemy = null;
    }


    //enemy in de node plaatsen
    /*
    if (CanPlaceEnemyHere()) 
    {
        addEnemy(GameObject enemy)//Gameobject enemy
    }
    */
}
