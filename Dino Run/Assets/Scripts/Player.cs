using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    bool isDead;

    [Header("�ɷ�ġ")]
    [SerializeField] float jumpPower;

    [Header("�ִϸ��̼�")]
    [Space(15f)]
    [SerializeField] Animator anim;

    [Header("�Ŵ���")][Space(15f)]
    [SerializeField] GameManager gameManager;
    [SerializeField] SoundManager soundManager;
    [SerializeField] BackgroundScroller bScroller;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJump")) Jump();
    }

    void Jump()
    {
        if (isDead) return;
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        anim.SetBool("isJump", true);
        soundManager.JumpSound();
    }

    //�÷��̾� ������� bool�� ��ȯ. by����_22.02.05
    public bool IsDead() => isDead; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        //compareTag�� ���� ������ string���� ���ϸ� �������� ���� ���ɿ� ������ ��ġ�� �����̴�.
        if (collision.gameObject.CompareTag("Ground") && anim.GetBool("isJump"))
        {
            anim.SetBool("isJump", false);
            if(!isDead) soundManager.LandSound();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //��ֹ��� ����� �� Die���·� ���� �� �÷��̾� �ൿ ����. by����_22.02.05
        if (collision.CompareTag("Objection") && !isDead)
        {
            isDead = true;
            bScroller.TimeStop();
            rigid.gravityScale = 0;
            soundManager.DieSound();
            anim.SetTrigger("doDie");
            gameManager.SetHighScore();
            rigid.velocity = Vector2.zero;
            gameManager.ShowGameOver(true);
        }
    }
}
