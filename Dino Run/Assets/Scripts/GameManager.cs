using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("텍스트 UI")]
    [Tooltip("화면에 표시되는 점수 텍스트 UI")][SerializeField] Text scoreText;
    [SerializeField] Animator textAnim;

    bool isChecking;
    int checkPoint;
    float score;

    void Awake()
    {
        //프레임 조절을 통해 cpu의 연산 부하량 줄이기.
        //프레임30으로 했다가 약간 끊기는 느낌이라 45로 조정.by상훈_22.02.04
        Application.targetFrameRate = 45;
    }

    void Update()
    {
        //점수 표시 로직. by상훈_22.02.04
        score += Time.deltaTime;
        scoreText.text = $"{((int)score):0000}";

        if ((int)score % 10 == 0 && (int)score > 0 && !isChecking)
        {
            textAnim.SetTrigger("doCheck");
            isChecking = true;
            checkPoint += 10;
        }

        if ((int)score % 10 == 1)
        {
            isChecking = false;
        }
    }
}
