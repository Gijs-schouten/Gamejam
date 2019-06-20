using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginSequenceGenerator : MonoBehaviour
{
    private int[] _beginSequenceInts;
    public int _beginSequenceLength;
    public int _NumberOfEnemyTypes;

    // Start is called before the first frame update
    void Start()
    {
        _beginSequenceInts = generateRandomInts(_beginSequenceLength);
        foreach (int i in _beginSequenceInts){
            print(i);
        }
    }

    private int[] generateRandomInts(int length) {
        int[] _intArr = new int[length];
        for(int i =0; i < length; i++) {
            _intArr[i] = (int)Random.Range(0f, _NumberOfEnemyTypes);
        }
        return _intArr;
    }
}
 