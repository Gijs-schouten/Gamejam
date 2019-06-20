using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginSequenceGenerator : MonoBehaviour {
    private List<int> _beginSequenceInts;
    public int _beginSequenceLength;
    public int _NumberOfEnemyTypes;

    public AudioManager _audioManager;
    public Checker _checker;

    void Start() {
        _beginSequenceInts = generateRandomInts(_beginSequenceLength);
        _checker.FillMySequence(_beginSequenceInts);
        //play beginsequenceints audio
        StartCoroutine(PlayClips());
    }

    private List<int> generateRandomInts(int length) {
        List<int> _intArr = new List<int>();
        for (int i = 0; i < length; i++) {
            int temp = (int)Random.Range(0f, (float)_NumberOfEnemyTypes);
            _intArr.Add(temp);
        }
        return _intArr;
    }

    private IEnumerator PlayClips() {
        foreach (int _clip in _beginSequenceInts) {
            _audioManager.PlayAudioClip(_clip);
            yield return new WaitForSeconds(_audioManager._source.clip.length);
        }
    }
}
