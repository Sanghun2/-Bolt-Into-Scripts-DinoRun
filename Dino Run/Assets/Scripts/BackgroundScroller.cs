using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Transform[] sky;
    [SerializeField] Transform[] cloud;
    [SerializeField] Transform[] mountain;
    [SerializeField] Transform[] ground;

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
    }

    void RePosition(Transform tr)
    {
        tr.localPosition += ResetVec;
    }
}
