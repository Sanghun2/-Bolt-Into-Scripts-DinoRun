using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("사운드")]
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip landClip;
    [SerializeField] AudioClip dieClip;
    [SerializeField] AudioClip buttonClip;

    [Header("사운드 채널")][Space(15f)]
    [SerializeField] AudioSource playerChanel;

    //점프할 때 나는 사운드. by상훈_22.02.05
    public void JumpSound()
    {
        playerChanel.clip = jumpClip;
        playerChanel.Play();
    }
    //땅에 닿았을 때 나는 사운드. by상훈_22.02.05
    public void LandSound()
    {
        playerChanel.clip = landClip;
        playerChanel.Play();
    }
    //죽었을 때 나는 사운드. by상훈_22.02.05
    public void DieSound()
    {
        playerChanel.clip = dieClip;
        playerChanel.Play();
    }
    //버튼을 클릭했을 때 나는 사운드. by상훈_22.02.05
    public void ClickSound()
    {
        playerChanel.clip = buttonClip;
        playerChanel.Play();
    }
}
