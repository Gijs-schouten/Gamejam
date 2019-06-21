using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanelActions : MonoBehaviour {

    [SerializeField]
    private SceneSwitcher _sceneSwitcher;

    public void Retry(){
        _sceneSwitcher.SwitchScenes(1);
    }

    public void Menu() {
        _sceneSwitcher.SwitchScenes(0);
    }

    public void StartGame() {
        _sceneSwitcher.SwitchScenes(1);
    }

    public void Win() {
        _sceneSwitcher.SwitchScenes(2);
    }

    public void Lose() {
        _sceneSwitcher.SwitchScenes(3);
    }

    public void ExitGame() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
