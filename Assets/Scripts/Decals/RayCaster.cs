using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public ParticleSystem _splashParticles;
    public GameObject _splashPrefab;
    public Transform _splashHolder;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    private void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if(hit.collider != null)
        {
            GameObject splash = Instantiate(_splashPrefab, hit.point, Quaternion.identity) as GameObject;
            splash.transform.SetParent(_splashHolder, true);
            Splash splashScript = splash.GetComponent<Splash>();

            _splashParticles.transform.position = hit.point;
            _splashParticles.Play();

            if(hit.collider.gameObject.tag == "Background")
            {
                splashScript.Initialize(Splash.SplashLocation.Background);
            }
            else
            {
                splashScript.Initialize(Splash.SplashLocation.Ground);
            }
        }
    }
}
