using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        //������ ������ ���� cpu�� ���� ���Ϸ� ���̱�.
        Application.targetFrameRate = 30;
    }
}
