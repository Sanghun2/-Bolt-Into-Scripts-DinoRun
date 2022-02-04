using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Transform[] sky;
    [SerializeField] Transform[] cloud;
    [SerializeField] Transform[] mountain;
    [SerializeField] Transform[] ground;
    [SerializeField] Transform[] objection;

    [SerializeField] float skySpeed;
    [SerializeField] float cloudSpeed;
    [SerializeField] float mountainSpeed;
    [SerializeField] float groundSpeed;

    Vector3 moveVec;
    Vector3 ResetVec;

    void Start()
    {
        //�Ź� new�� ����ϸ� �������� ���� ���� ����� �̸� �����صΰ� �����ϴ� ������� ���.
        moveVec = Vector3.left;
        ResetVec = Vector3.right * 24;
    }

    void Update()
    {
        //�ϴ�
        foreach (var obj in sky)
        {
            obj.Translate(moveVec*skySpeed*Time.deltaTime);
            if (obj.transform.position.x < -12) RePosition(obj);
        }
        //����
        foreach (var obj in cloud)
        {
            obj.Translate(moveVec * cloudSpeed * Time.deltaTime);
            if (obj.transform.position.x < -12) RePosition(obj);
        }
        //��
        foreach (var obj in mountain)
        {
            obj.Translate(moveVec * mountainSpeed * Time.deltaTime);
            if (obj.transform.position.x < -12) RePosition(obj);
        }
        //��
        foreach (var obj in ground)
        {
            obj.Translate(moveVec * groundSpeed * Time.deltaTime);
            if (obj.transform.position.x < -12) RePosition(obj);
        }
        //��ֹ�
        foreach (var obj in objection)
        {
            obj.Translate(moveVec * groundSpeed * Time.deltaTime);
            if (obj.transform.position.x < -12) RePosition(obj, Random.Range(0,3));
        }
    }

    void RePosition(Transform tr)
    {
        tr.localPosition += ResetVec;
    }
    
    //���� ��ֹ��� ���� �������� �����ϰ� ����� ���. ���ġ �Լ� �����ε� ���. by����_20.02.03
    void RePosition(Transform tr, int rand)
    {
        tr.localPosition += ResetVec;
        switch (rand)
        {
            case 0:
            case 1:
                tr.gameObject.SetActive(true); //66.6% Ȯ���� �����
                break;
            case 2:
                tr.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
