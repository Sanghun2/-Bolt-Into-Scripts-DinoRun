using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    bool isDead;

    [Header("능력치")]
    [SerializeField] float jumpPower;

    [Header("애니메이션")]
    [Space(15f)]
    [SerializeField] Animator anim;

    [Header("매니저")][Space(15f)]
    [SerializeField] GameManager gameManager;
    [SerializeField] SoundManager soundManager;
    [SerializeField] BackgroundScroller bScroller;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //터치로 점프 기능 구현. by상훈_22.02.08
        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && !anim.GetBool("isJump"))
            Jump();
    }

    void Jump()
    {
        if (isDead) return;
        soundManager.JumpSound();
        anim.SetBool("isJump", true);
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    //플레이어 사망상태 bool값 반환. by상훈_22.02.05
    public bool IsDead() => isDead; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        //compareTag를 쓰는 이유는 string으로 비교하면 가비지가 생겨 성능에 영향을 미치기 때문이다.
        if (collision.gameObject.CompareTag("Ground") && anim.GetBool("isJump"))
        {
            anim.SetBool("isJump", false);
            if(!isDead) soundManager.LandSound();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //장애물에 닿았을 때 Die상태로 변경 및 플레이어 행동 정지. by상훈_22.02.05
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
