using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("�ؽ�Ʈ UI")]
    [Tooltip("ȭ�鿡 ǥ�õǴ� ���� �ؽ�Ʈ UI")][SerializeField] Text scoreText;
    [SerializeField] Animator textAnim;

    bool isChecking;
    int checkPoint;
    float score;

    void Awake()
    {
        //������ ������ ���� cpu�� ���� ���Ϸ� ���̱�.
        //������30���� �ߴٰ� �ణ ����� �����̶� 45�� ����.by����_22.02.04
        Application.targetFrameRate = 45;
    }

    void Update()
    {
        //���� ǥ�� ����. by����_22.02.04
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
