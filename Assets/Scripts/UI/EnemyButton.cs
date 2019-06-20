using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButton : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private MouseInput MouseInput;
    public void ButtonClick() 
    {
        MouseInput.TurnOnPlaceMode(enemy);
    }
}
