using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    [SerializeField]
    private string _winText;
    [SerializeField]
    private string _loseText;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private Canvas _Endscreen;

    public void ChangeText(bool winContition) {
        _text.text = (winContition) ? _winText : _loseText;
    }

    public void SetCanvasActive() {
        _Endscreen.enabled = !_Endscreen.enabled;
    }
}
