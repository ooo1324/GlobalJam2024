using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeavtive : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        particle.Play();
        StartCoroutine(ParticleAction());
    }

    private void OnDisable()
    {
        particle.Stop();
        StopCoroutine(ParticleAction());
    }

    IEnumerator ParticleAction()
    {
        while (true)
        {
            if (!particle.isPlaying)
                gameObject.SetActive(false);
            yield return new WaitForFixedUpdate();
        }
    }
}
