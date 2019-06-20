using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour {
    [SerializeField] private int _gridLengt;
    [SerializeField] private float _gridgap;
    [SerializeField] private GameObject _node;
    delegate void MyDelegate();
    MyDelegate RemoveEnemysFromNodes;


    void Start() {
        for (int i = 0; i < _gridLengt; i++) {
            GameObject _spawnedObject = Instantiate(_node, transform.position + new Vector3(i + (i * _gridgap), 0, 0), Quaternion.identity);
            RemoveEnemysFromNodes += _spawnedObject.GetComponent<Node>().RemoveEnemy;
        }
    }
    public void RemoveAllEnemyFromNode()
    {
        RemoveEnemysFromNodes();
    }
    public void GetAllEnemyInNodes() //nog maken
    {

    }
}
