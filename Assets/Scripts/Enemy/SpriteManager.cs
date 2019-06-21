using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private GameObject _SpriteObject;
    private SpriteRenderer _SpriteRenderer;
    public Sprite[] _Sprites;


    public void InitSprite(GameObject _enemy) {
        _SpriteObject = _enemy.gameObject;
        _SpriteRenderer = _SpriteObject.GetComponent<SpriteRenderer>();
        _SpriteRenderer.sprite = _Sprites[_enemy.GetComponent<Enemy>()._enemyIndexNumber];
    }


    private GameObject[] FindAllEnemies() {
        return GameObject.FindGameObjectsWithTag("Enemy");
    }
}
