using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BeginSequenceTutorial : MonoBehaviour {

	[SerializeField]
	private GameObject _highlight;
	[SerializeField]
	private BeginSequenceGenerator _generator;
	[SerializeField]
	private GameObject[] _enemySlots;

	private void Start() {
		HighlightAll();
	}

	private void HighlightAll() {
		print(_generator._beginSequenceInts.Count);
		for (int i = 0; i < _generator._beginSequenceInts.Count; i++) {
			switch (_generator._beginSequenceInts[i]) {
				case -1:
					break;

				case 0:
					HighlightEnemy(_enemySlots[0].transform);
					print(0);
					break;

				case 1:
					print(1);
					HighlightEnemy(_enemySlots[1].transform);
					break;

				case 2:
					print(2);
					HighlightEnemy(_enemySlots[2].transform);
					break;

				case 3:
					print(3);
					HighlightEnemy(_enemySlots[3].transform);
					break;
			}
		}
	}

	private void HighlightEnemy(Transform transform) {
		GameObject clone;
		clone = Instantiate(_highlight);
		clone.transform.position = transform.position;
		Thread.Sleep(500);
		Destroy(clone);
	}
}
