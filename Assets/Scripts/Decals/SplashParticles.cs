using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashParticles : MonoBehaviour
{
    public ParticleSystem _splashParticles;
    public GameObject _splashPrefab;
    public Transform _splashHolder;
    private List<ParticleCollisionEvent> _collisionEvents = new List<ParticleCollisionEvent>();

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(_splashParticles, other, _collisionEvents);

        int count = _collisionEvents.Count;

        for (int i = 0; i < count; i++)
        {
            GameObject splash = Instantiate(_splashPrefab, _collisionEvents[i].intersection, Quaternion.identity) as GameObject;
            splash.transform.SetParent(_splashHolder, true);
            Splash splashScript = splash.GetComponent<Splash>();
            splashScript.Initialize(Splash.SplashLocation.Ground);
        }

    }
}
