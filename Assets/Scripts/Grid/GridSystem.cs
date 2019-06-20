using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour {
    [SerializeField] private int _gridLengt;
    [SerializeField] private float _gridgap;
    [SerializeField] private GameObject _node;
    private Node[] Nodes;

    delegate void MyDelegate();
    MyDelegate RemoveEnemysFromNodes;
   
    void Start() {
        Nodes = new Node[_gridLengt];
        for (int i = 0; i < _gridLengt; i++) {
            GameObject _spawnedObject = Instantiate(_node, transform.position + new Vector3(i + (i * _gridgap), 0, 0), Quaternion.identity);
            Nodes[i] = _spawnedObject.GetComponent<Node>();
            RemoveEnemysFromNodes += Nodes[i].RemoveEnemy;
        }
    }
    public void RemoveAllEnemyFromNode()
    {
        RemoveEnemysFromNodes();
    }
    public GameObject[] GetAllEnemyInNodes() //nog testen
    {
        GameObject[] returnArray = new GameObject[_gridLengt];
        for (int i = 0; i < _gridLengt; i++) {
            returnArray[i] = Nodes[i].GetComponent<Node>()._getCurrentEnemy();
        }
        return returnArray;
    }
}
