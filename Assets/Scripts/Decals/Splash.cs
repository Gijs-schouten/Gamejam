using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public enum SplashLocation
    {
        Ground,
        Background,
    }

    public Color _backgroundSplashAlpha;
    public float _minimumSize;
    public float _maximumSize;

    public Sprite[] _splashSprites;

    private SplashLocation _splashLocation;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(SplashLocation splashLocation)
    {
        this._splashLocation = splashLocation;

        SetSprite();
        SetSize();
        SetRotation();
        SetLocationProperties();
    }

    private void SetSprite()
    {
        int randomIndex = Random.Range(0, _splashSprites.Length);
        _spriteRenderer.sprite = _splashSprites[randomIndex];
    }

    private void SetSize()
    {
        float randomSize = Random.Range(_minimumSize, _maximumSize);
        transform.localScale *= randomSize;
    }

    private void SetRotation()
    {
        float randomRotation = Random.Range(-360.0f, 360.0f);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, randomRotation);
    }

    private void SetLocationProperties()
    {
        switch(_splashLocation)
        {
            case SplashLocation.Background:
                _spriteRenderer.color = _backgroundSplashAlpha;
                _spriteRenderer.sortingOrder = 0;
                break;

            case SplashLocation.Ground:
                _spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                _spriteRenderer.sortingOrder = 3;
                break;
        }
    }
}
