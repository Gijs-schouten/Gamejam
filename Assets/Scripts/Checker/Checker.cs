using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    private List<int> _mySequence; //the official sequence
    private List<int> _theirSequence; //the sequence of the player

    public void FillMySequence(List<int> newSequence) {
        _mySequence = newSequence;
    }

    public void FillTheirSequence(List<int> newSequence) {
        _theirSequence = newSequence;
    }

    public bool CheckSequence() {
        bool everythingCorrect = false;
        int mySequenceLength = _mySequence.Count;
        int theirSequenceLength = _theirSequence.Count;

        if (mySequenceLength == theirSequenceLength) {
            int counter = 0;
            for (int i = 0; i < mySequenceLength; i++) {
                if(_mySequence[i] == _theirSequence[i]) {
                    counter++;
                }
            }

            if (counter == mySequenceLength) {
                everythingCorrect = true;
            }
        }

        return everythingCorrect;
    }
}
