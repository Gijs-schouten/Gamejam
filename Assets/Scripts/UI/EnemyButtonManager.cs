using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttons;
    [SerializeField] private GridSystem _GridSystem;
    public void UpdateButtons() 
    {
        int amoutOfNodes = _GridSystem.GetGridLengt();
        switch (amoutOfNodes) {
            case 5:
                AddNewButton(8);
                break;
            case 4:
                AddNewButton(7);
                break;
            case 3:
                AddNewButton(6);
                break;
            case 2:
                AddNewButton(5);
                break;
            case 1:
                AddNewButton(4);
                break;
            default:
                break;
        }

    }
    private void AddNewButton(int i) 
    {
        _buttons[i].SetActive(true);
    }
}
