using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginSequenceGenerator : MonoBehaviour {
    public List<int> _beginSequenceInts;
    public int _beginSequenceLength;
    public int _NumberOfEnemyTypes;

    public bool _audioDone = false;

    public AudioManager _audioManager;
    public Checker _checker;

	[SerializeField]
	private BeginSequenceTutorial _tutorial;

    private void Start() {
        _beginSequenceInts = generateRandomInts(_beginSequenceLength);
        StartSequence();
    }

    private void StartSequence() {
        _checker.FillMySequence(_beginSequenceInts);
		StartCoroutine(_tutorial.HighlightAll());
		StartCoroutine(PlayClips());	
    }

    private List<int> generateRandomInts(int length) {
        List<int> _intArr = new List<int>();
        for (int i = 0; i < length; i++) {
            int temp = (int)Mathf.Floor(Random.Range(-1f, (float)_NumberOfEnemyTypes));
            _intArr.Add(temp);
        }
        return _intArr;
    }

    private List<int> extendIntList(List<int> _originalSequence) {
        _originalSequence.Add((int)Mathf.Floor(Random.Range(-1f, (float)_NumberOfEnemyTypes)));
        return _originalSequence;
    }

    private IEnumerator PlayClips() {
        foreach (int _clip in _beginSequenceInts) {
            _audioManager.PlayAudioClip(_clip);
            yield return new WaitForSeconds(_audioManager._source.clip.length );
        }
        _audioDone = true;
    }

    public void ExtendSequence() {
        _beginSequenceInts = extendIntList(_beginSequenceInts);
        StartSequence();
    }
}
