using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpPower;
    Rigidbody2D rigid;

    [SerializeField] SoundManager soundManager;
    [SerializeField] Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJump")) Jump();
    }

    void Jump()
    {
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        anim.SetBool("isJump", true);
        soundManager.JumpSound();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //compareTag�� ���� ������ string���� ���ϸ� �������� ���� ���ɿ� ������ ��ġ�� �����̴�.
        if (collision.gameObject.CompareTag("Ground") && anim.GetBool("isJump"))
        {
            anim.SetBool("isJump", false);
            soundManager.LandSound();
        }
    }
}
