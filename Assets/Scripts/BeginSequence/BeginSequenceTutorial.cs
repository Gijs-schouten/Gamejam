using System.Collections;
using UnityEngine;

public class BeginSequenceTutorial : MonoBehaviour {

	[SerializeField] private int _tutorialLevels;
	[SerializeField] private float _time = 1;
	[SerializeField] private GameObject[] _enemySlots;
	[SerializeField] private GameObject _highlight;
	[SerializeField] private BeginSequenceGenerator _generator;
	[SerializeField] private GridSystem _system;
	
	public IEnumerator HighlightAll() {
		if(_system.GetGridLengt() >= _tutorialLevels) {
			yield break;
		}

		for (int i = 0; i < _generator._beginSequenceInts.Count; i++) {
			switch (_generator._beginSequenceInts[i]) {
				case -1:
					yield return new WaitForSeconds(_time);
					break;

				case 0:
					HighlightEnemy(_enemySlots[0].transform);
					yield return new WaitForSeconds(_time);
					break;

				case 1:
					HighlightEnemy(_enemySlots[1].transform);
					yield return new WaitForSeconds(_time);
					break;

				case 2:
					HighlightEnemy(_enemySlots[2].transform);
					yield return new WaitForSeconds(_time);
					break;

				case 3:
					HighlightEnemy(_enemySlots[3].transform);
					yield return new WaitForSeconds(_time);
					break;
			}
		}
	}

	private void HighlightEnemy(Transform transform) {
		GameObject clone = Instantiate(_highlight, transform, false);
		clone.transform.position = transform.position;
		UILifeTime lifetime = UILifeTime.CreateComponent(clone, _time);
	}
}
