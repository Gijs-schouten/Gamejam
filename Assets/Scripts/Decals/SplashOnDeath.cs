using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashOnDeath : MonoBehaviour
{
    public ParticleSystem _splashParticles;
    public GameObject _splashPrefab;
    public Transform _splashHolder;

    public void SplashDeath()
    {
        GameObject splash = Instantiate(_splashPrefab, this.transform.position, Quaternion.identity) as GameObject;
        splash.transform.SetParent(_splashHolder, true);
        Splash splashScript = splash.GetComponent<Splash>();

        _splashParticles.transform.position = this.transform.position;
        _splashParticles.Play();
    }
}
