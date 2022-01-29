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
        //compareTag를 쓰는 이유는 string으로 비교하면 가비지가 생겨 성능에 영향을 미치기 때문이다.
        if (collision.gameObject.CompareTag("Ground") && anim.GetBool("isJump"))
        {
            anim.SetBool("isJump", false);
            soundManager.LandSound();
        }
    }
}
