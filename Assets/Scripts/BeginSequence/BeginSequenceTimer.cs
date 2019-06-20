using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginSequenceTimer : MonoBehaviour
{
    [SerializeField] private int _PlanningTime = 20;

    private Text _text;
    private GameObject _CanvasObject;
    private int _loop;
    private GridSystem _grid;

    // Start is called before the first frame update
    void Start()
    {
        _loop = _PlanningTime;
        _CanvasObject = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        _text = _CanvasObject.GetComponent<Text>();
        _grid = GameObject.Find("Grid").GetComponent<GridSystem>();
        
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown() {
        while(_loop >= 0) {
            _text.text = _loop.ToString();
            yield return new WaitForSeconds(1);
            _loop--;
        }
        foreach (GameObject _enemy in _grid.GetAllEnemyInNodesAsGameObject()) {
            if(_enemy) _enemy.GetComponent<Enemy>()._canMove = true;
        }
        _CanvasObject.SetActive(false);
    }
}
