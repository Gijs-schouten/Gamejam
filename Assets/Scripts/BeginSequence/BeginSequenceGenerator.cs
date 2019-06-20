using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginSequenceGenerator : MonoBehaviour
{
    private List<int> _beginSequenceInts;
    public int _beginSequenceLength;
    public int _NumberOfEnemyTypes;

    public Checker _checker;

    void Start()
    {
        _beginSequenceInts = generateRandomInts(_beginSequenceLength);
        _checker.FillMySequence(_beginSequenceInts);
        //play beginsequenceints audio
    }

    private List<int> generateRandomInts(int length) {
        List<int> _intArr = new List<int>(length);
        for(int i =0; i < length; i++) {
            _intArr[i] = (int)Random.Range(0f, _NumberOfEnemyTypes);
        }
        return _intArr;
    }
}
 