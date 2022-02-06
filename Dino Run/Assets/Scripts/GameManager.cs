using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("점수 UI")]
    [Tooltip("화면에 표시되는 현재 점수 텍스트 UI")] [SerializeField] Text scoreText;
    [Tooltip("화면에 표시되는 최고 점수 텍스트 UI")] [SerializeField] Text highScoreText;
    [SerializeField] Animator textAnim;

    [Header("게임오버")]
    [Space(15f)]
    [SerializeField] GameObject gameoverGroup;

    [Header("플레이어")]
    [Space(15f)]
    [SerializeField] Player player;

    [Header("매니저")]
    [Space(15f)]
    [SerializeField] BackgroundScroller bScroller;

    bool isChecking;
    int highScore;
    int checkPoint;
    int weight => 3; //점수 획득 가중치
    float maxSpeed => 2.5f;
    float score;
    float gameSpeed;
    YieldInstruction waitFor1Sec;

    void Awake()
    {
        //프레임 조절을 통해 cpu의 연산 부하량 줄이기.
        //프레임30으로 했다가 약간 끊기는 느낌이라 45로 조정.by상훈_22.02.04
        Application.targetFrameRate = 45;

        //가비지 생성을 줄이기 위해 미리 객체를 생성해 두고 참조. by상훈_22.02.05
        waitFor1Sec = new WaitForSeconds(1f);
    }

    void Start()
    {
        //저장된 최고점수가 있으면 불러오고 아니면 0으로 초기화.
        highScore = PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0;
        highScoreText.text = $"{highScore:0000}";
    }

    void Update()
    {
        if (!player.IsDead())
        {
            //점수 표시 로직. by상훈_22.02.04
            score += Time.deltaTime*weight;
            //점수가 최대치를 넘을 때 예외처리. by상훈_22.02.05
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
            //score에 따라 게임속도 변화(레벨 디자인)
            bScroller.ChangeGameSpeed(Level(score));
        }
    }

    //게임 재시작 기능. by상훈_22.02.05
    //대기시간과 버튼에 사용될 함수이름의 직관성을 위해 씬로드 부분을 호출하는 방식으로 분리해서 작성.
    public void Restart()
    {
        StartCoroutine(LoadScene());
    }

    //씬 리로드 기능. by상훈_22.02.05
    IEnumerator LoadScene()
    {
        yield return waitFor1Sec;
        SceneManager.LoadScene(0);
    }

    //게임오버 창 ON/OFF기능. by상훈_22.02.05
    public void ShowGameOver(bool isOpen)
    {        
        gameoverGroup.SetActive(isOpen);
    }

    //최고점수 갱신 기능. by상훈_22.02.05
    public void SetHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            PlayerPrefs.Save(); //캐시에 있는 playerPref값을 레지스트리에 저장
        }
    }

    //현재 점수에 따른 게임속도값 반환. by상훈_22.02.05
    public float Level(float score)
    {
        gameSpeed = gameSpeed > maxSpeed ? maxSpeed : 1 + score / 120;
        return gameSpeed;
    }
}
