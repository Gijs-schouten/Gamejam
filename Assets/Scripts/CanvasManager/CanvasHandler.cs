using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour {
    [SerializeField]
    private string _winText;
    [SerializeField]
    private string _loseText;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _NextScreen;
    [SerializeField]
    private GameObject _WinLoseScreen;
    [SerializeField]
    private BeginSequenceTimer _timer;

    public void ChangeText(bool winContition) {
        _text.text = (winContition) ? _winText : _loseText;
    }

    public void SetCanvasActive(bool setbool) {
        if (setbool) {
            _NextScreen.gameObject.SetActive(true);
            StartCoroutine(DeactivateTimer());
        } else {
            _WinLoseScreen.gameObject.SetActive(true);
        }
    }

    public void DeactivateCanvases() {
        _NextScreen.gameObject.SetActive(false);
        _WinLoseScreen.gameObject.SetActive(false);
    }
    private IEnumerator DeactivateTimer() {
        yield return new WaitForSeconds(2);
        DeactivateCanvases();
        yield return new WaitForSeconds(0.5f);
        _timer.ResetGame();
    }
}
