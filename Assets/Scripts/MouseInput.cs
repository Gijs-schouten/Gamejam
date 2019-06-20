using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public bool _canbuild = false;
    private GameObject _spawnedObject;

    public Vector3 MousePosition() 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        else 
        {
            //print("Mouse Out Of Area");
            return Vector3.zero;
        }
    }
    void Update()
    {
        if(_canbuild)
        {
            _spawnedObject.transform.position = MousePosition();
            RaycastHit hit;
            if (Physics.Raycast(MousePosition(), new Vector3(0,0,1), out hit, Mathf.Infinity))
            {
                if (Input.GetMouseButtonDown(0)) 
                {
                    if (hit.collider.gameObject.GetComponent<Node>().CanPlaceEnemyHere()) 
                    {
                        hit.collider.gameObject.GetComponent<Node>().addEnemy(_spawnedObject);
                        TurnOffPlaceMode();
                    }                    
                }
            }
            if (Input.GetMouseButtonDown(1)) 
            {
                Destroy(_spawnedObject);
                TurnOffPlaceMode();
            }
        }
    }
    public void TurnOnPlaceMode(GameObject enemy) 
    {
        SpawnEnemy(enemy);
        _canbuild = true;
    }
    private void SpawnEnemy(GameObject enemy) 
    {
        _spawnedObject = Instantiate(enemy, MousePosition(), Quaternion.identity);
    }
    private void TurnOffPlaceMode() 
    {
        _spawnedObject = null;
        _canbuild = false;

    }

    public void DestroyBuildable() {
        Destroy(_spawnedObject);
        TurnOffPlaceMode();
    }
}
