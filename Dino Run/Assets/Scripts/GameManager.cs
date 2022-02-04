using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        //프레임 조절을 통해 cpu의 연산 부하량 줄이기.
        Application.targetFrameRate = 30;
    }
}
