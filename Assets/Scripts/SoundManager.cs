using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource Movesound, Coinsound, GameOverSound;
    public static SoundManager Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {

            Destroy(this.gameObject);
        }
    }
    public void PlayMoveSound()
    {
        Movesound.Play();
    }
    public void PlayCoinSound()
    {
        Coinsound.Play();
    }
  
    public void PlayGameOverSound()
    {
        GameOverSound.Play();
    }
}
