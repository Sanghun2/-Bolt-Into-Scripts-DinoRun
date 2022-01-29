using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip landClip;
    [SerializeField] AudioClip dieClip;
    [SerializeField] AudioClip buttonClip;

    [SerializeField] AudioSource playerChanel;

    public void JumpSound()
    {
        playerChanel.clip = jumpClip;
        playerChanel.Play();
    }

    public void LandSound()
    {
        playerChanel.clip = landClip;
        playerChanel.Play();
    }
}
