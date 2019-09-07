using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {
    public static SoundSystem instance;
    public AudioSource audioSourcePoint;
    public AudioSource audioSourceAleteo;
    public AudioSource audioSourceGameOver;
    public AudioSource audioSource;
    private void Awake(){
        if (SoundSystem.instance == null) {
            SoundSystem.instance = this;
        } else if (SoundSystem.instance != this){
            Destroy(gameObject);
        }
    }
    public void PlayCoin(){
        audioSourcePoint.Play();
    }
    public void PlayAleteo(){
        audioSourceAleteo.Play();
    }
    public void PlayGameOver(){
        audioSourceGameOver.Play();
    }
    private void OnDestroy(){
        if (SoundSystem.instance == this){
            SoundSystem.instance = null;
        }
    }
}
