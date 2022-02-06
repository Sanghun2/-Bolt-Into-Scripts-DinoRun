using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("����")]
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip landClip;
    [SerializeField] AudioClip dieClip;
    [SerializeField] AudioClip buttonClip;

    [Header("���� ä��")][Space(15f)]
    [SerializeField] AudioSource playerChanel;

    //������ �� ���� ����. by����_22.02.05
    public void JumpSound()
    {
        playerChanel.clip = jumpClip;
        playerChanel.Play();
    }
    //���� ����� �� ���� ����. by����_22.02.05
    public void LandSound()
    {
        playerChanel.clip = landClip;
        playerChanel.Play();
    }
    //�׾��� �� ���� ����. by����_22.02.05
    public void DieSound()
    {
        playerChanel.clip = dieClip;
        playerChanel.Play();
    }
    //��ư�� Ŭ������ �� ���� ����. by����_22.02.05
    public void ClickSound()
    {
        playerChanel.clip = buttonClip;
        playerChanel.Play();
    }
}
