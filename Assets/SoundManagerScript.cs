using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip PlayerDeathSound, PlayerJump;
    public static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {

        PlayerDeathSound = Resources.Load<AudioClip>("PlayerDeath");
        PlayerJump = Resources.Load<AudioClip>("PlayerJump");

        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip) {

        switch (clip)
        {
            case "death":
                audioSrc.PlayOneShot(PlayerDeathSound);            
                break;

            case "jump":
                audioSrc.PlayOneShot(PlayerJump);
                break;
        }

    }
}
