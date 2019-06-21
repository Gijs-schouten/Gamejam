using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginSequenceTimer : MonoBehaviour {
    [SerializeField] private int _PlanningTime = 20;

    private Text _text;
    private GameObject _CanvasObject;
    private int _loop;
    private BeginSequenceGenerator _generator;
    private GridSystem _grid;
    private Checker _checker;
    private EnemyButtonManager _EnemyButtonManager;
    public Action Going;
    public bool Playing = false;
	private Animator _player;

	// Start is called before the first frame update
	void Start() {
        _loop = _PlanningTime;
		_player = GameObject.Find("Player").GetComponent<Animator>();
		_generator = gameObject.GetComponent<BeginSequenceGenerator>();
        _CanvasObject = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        _EnemyButtonManager = GameObject.Find("ui enemy").GetComponent<EnemyButtonManager>();
        _text = _CanvasObject.GetComponent<Text>();
        _grid = GameObject.Find("Grid").GetComponent<GridSystem>();
        _checker = GetComponent<Checker>();


        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown() {
        while (_loop >= 0) {
            _text.text = _loop.ToString();
            yield return new WaitForSeconds(1);
            _loop--;
        }
        foreach (GameObject _enemy in _grid.GetAllEnemyInNodesAsGameObject()) {
            if (_enemy) _enemy.GetComponent<Enemy>()._canMove = true;
        }
        _CanvasObject.SetActive(false);
        Playing = true;
		yield return new WaitForSeconds(5);
		Aniamtoekasmnkenko();
		Going();
    }

    public void ResetGame() {
        _CanvasObject.SetActive(true);
        _EnemyButtonManager.UpdateButtons();
        if(_generator._NumberOfEnemyTypes < 8) {
            _generator._NumberOfEnemyTypes++;
        }
        _generator.ExtendSequence();
        _grid.ExtendNodes();
        Playing = false;
        RestartLevel();
    }

    private void RestartLevel() {
        StopCoroutine(CountDown());
        _loop = _PlanningTime;
        StartCoroutine(CountDown());
    }

	private void Aniamtoekasmnkenko() {
		_player.SetBool("shoot", false);
	}
}
