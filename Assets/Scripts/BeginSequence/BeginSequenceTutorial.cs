using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class BeginSequenceTutorial : MonoBehaviour {

	[SerializeField]
	private GameObject _highlight;
	[SerializeField]
	private BeginSequenceGenerator _generator;
	[SerializeField]
	private GameObject[] _enemySlots;
	[SerializeField]
	private float _time = 1;

	private void Start() {
		//HighlightAll();
	}


	public IEnumerator HighlightAll() {
		print(_generator._beginSequenceInts.Count + "abc");
		for (int i = 0; i < _generator._beginSequenceInts.Count; i++) {
			switch (_generator._beginSequenceInts[i]) {
				case -1:
					yield return new WaitForSeconds(_time);
					break;

				case 0:
					HighlightEnemy(_enemySlots[0].transform);
					print(0);
					yield return new WaitForSeconds(_time);
					break;

				case 1:
					print(1);
					HighlightEnemy(_enemySlots[1].transform);
					yield return new WaitForSeconds(_time);
					break;

				case 2:
					print(2);
					HighlightEnemy(_enemySlots[2].transform);
					yield return new WaitForSeconds(_time);
					break;

				case 3:
					print(3);
					HighlightEnemy(_enemySlots[3].transform);
					yield return new WaitForSeconds(_time);
					break;
			}
		}
	}

	private void HighlightEnemy(Transform transform) {
		print("clone");
		GameObject clone = Instantiate(_highlight, transform, false);
		clone.transform.position = transform.position;
		UILifeTime lifetime = UILifeTime.CreateComponent(clone, _time);
		


		//clone.transform.localScale += new Vector3(100, 100);
		//Thread.Sleep(5000);
		//Destroy(clone);
	}
}
