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
        //매번 new를 사용하면 가비지가 생길 것을 고려해 미리 저장해두고 참조하는 방식으로 사용.
        moveVec = Vector3.left;
        ResetVec = Vector3.right * 24;
    }

    void Update()
    {
        //하늘
        foreach (var obj in sky)
        {
            obj.Translate(moveVec*skySpeed*Time.deltaTime);
            if (obj.transform.position.x < -12) RePosition(obj);
        }
        //구름
        foreach (var obj in cloud)
        {
            obj.Translate(moveVec * cloudSpeed * Time.deltaTime);
            if (obj.transform.position.x < -12) RePosition(obj);
        }
        //산
        foreach (var obj in mountain)
        {
            obj.Translate(moveVec * mountainSpeed * Time.deltaTime);
            if (obj.transform.position.x < -12) RePosition(obj);
        }
        //땅
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
