using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("���� UI")]
    [Tooltip("ȭ�鿡 ǥ�õǴ� ���� ���� �ؽ�Ʈ UI")] [SerializeField] Text scoreText;
    [Tooltip("ȭ�鿡 ǥ�õǴ� �ְ� ���� �ؽ�Ʈ UI")] [SerializeField] Text highScoreText;
    [SerializeField] Animator textAnim;

    [Header("���ӿ���")]
    [Space(15f)]
    [SerializeField] GameObject gameoverGroup;

    [Header("�÷��̾�")]
    [Space(15f)]
    [SerializeField] Player player;

    [Header("�Ŵ���")]
    [Space(15f)]
    [SerializeField] BackgroundScroller bScroller;

    bool isChecking;
    int highScore;
    int checkPoint;
    int weight => 3; //���� ȹ�� ����ġ
    float maxSpeed => 2.5f;
    float score;
    float gameSpeed;
    YieldInstruction waitFor1Sec;

    void Awake()
    {
        //������ ������ ���� cpu�� ���� ���Ϸ� ���̱�.
        //������30���� �ߴٰ� �ణ ����� �����̶� 45�� ����.by����_22.02.04
        Application.targetFrameRate = 45;

        //������ ������ ���̱� ���� �̸� ��ü�� ������ �ΰ� ����. by����_22.02.05
        waitFor1Sec = new WaitForSeconds(1f);
    }

    void Start()
    {
        //����� �ְ������� ������ �ҷ����� �ƴϸ� 0���� �ʱ�ȭ.
        highScore = PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0;
        highScoreText.text = $"{highScore:0000}";
    }

    void Update()
    {
        if (!player.IsDead())
        {
            //���� ǥ�� ����. by����_22.02.04
            score += Time.deltaTime*weight;
            //������ �ִ�ġ�� ���� �� ����ó��. by����_22.02.05
            if (score < 10000) scoreText.text = $"{((int)score):0000}";
            else scoreText.text = "9999";

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
            //score�� ���� ���Ӽӵ� ��ȭ(���� ������)
            bScroller.ChangeGameSpeed(Level(score));
        }
    }

    //���� ����� ���. by����_22.02.05
    //���ð��� ��ư�� ���� �Լ��̸��� �������� ���� ���ε� �κ��� ȣ���ϴ� ������� �и��ؼ� �ۼ�.
    public void Restart()
    {
        StartCoroutine(LoadScene());
    }

    //�� ���ε� ���. by����_22.02.05
    IEnumerator LoadScene()
    {
        yield return waitFor1Sec;
        SceneManager.LoadScene(0);
    }

    //���ӿ��� â ON/OFF���. by����_22.02.05
    public void ShowGameOver(bool isOpen)
    {        
        gameoverGroup.SetActive(isOpen);
    }

    //�ְ����� ���� ���. by����_22.02.05
    public void SetHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            PlayerPrefs.Save(); //ĳ�ÿ� �ִ� playerPref���� ������Ʈ���� ����
        }
    }

    //���� ������ ���� ���Ӽӵ��� ��ȯ. by����_22.02.05
    public float Level(float score)
    {
        gameSpeed = gameSpeed > maxSpeed ? maxSpeed : 1 + score / 120;
        return gameSpeed;
    }
}
