using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource SFX;

    [SerializeField] AudioClip shootingSound;
    [SerializeField] AudioClip enermyExplosionSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    public void PlayShootingSound()
    {
        SFX.clip = shootingSound;
        SFX.PlayOneShot(shootingSound);
    }

    public void PlayEnermyExplosionSound()
    {
        SFX.clip = enermyExplosionSound;
        SFX.PlayOneShot(enermyExplosionSound);
    }

}
