using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using System;

public class Box : MonoBehaviour
{
    public int boxNumber;
    public ParticleSystem ParticleEffect;
    public Animation AnimatedText;
    public ParticleSystem TeleportParticleEffect1;
    public ParticleSystem TeleportParticleEffect2;
    AudioSource audioParticle;


    private void Start()
    {

        audioParticle = gameObject.GetComponent<AudioSource>();
    }
    public void activeParticleEffect() {
        if(ParticleEffect != null && !ParticleEffect.isPlaying)
        {
            ParticleEffect.Play();
            audioParticle.Play();
        }
           
    }
    public void activeAnimation()
    {
        if (AnimatedText != null && !AnimatedText.isPlaying)
            AnimatedText.Play();
    }

    public void activeTeleportation()
    {
        StartCoroutine(startAnimations());
    }
    IEnumerator startAnimations()
    {
        yield return new WaitForSeconds(1);
        audioParticle.Play();
        if (TeleportParticleEffect1 != null && !TeleportParticleEffect1.isPlaying)
            TeleportParticleEffect1.Play();
        if (TeleportParticleEffect2 != null && !TeleportParticleEffect2.isPlaying)
            TeleportParticleEffect2.Play();
    }
}
