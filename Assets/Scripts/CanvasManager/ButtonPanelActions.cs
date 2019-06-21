using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanelActions : MonoBehaviour {

    [SerializeField]
    private SceneSwitcher _sceneSwitcher;

    public void Retry(){
        Debug.Log("Retry");
        _sceneSwitcher.SwitchScenes(1);
    }

    public void Menu() {
        Debug.Log("Menu");
        _sceneSwitcher.SwitchScenes(0);
    }

    public void StartGame() {
        _sceneSwitcher.SwitchScenes(1);
    }

    public void ExitGame() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
