﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runLeft;
    public AnimationClip runRight;
    public AnimationClip[] die;
}

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    public float turnSpeed = 100.0f;

    public PlayerAnim playerAnim;

    private Animation animation;

    void Start()
    {
        animation = GetComponent<Animation>();

        animation.Play(playerAnim.idle.name);
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ 1.0f
        float v = Input.GetAxis("Vertical");   // -1.0f ~ 0.0f ~ 1.0f 
        float r = Input.GetAxis("Mouse X");    //마우스 좌우 이동 변위값

        //이동로직
        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
        //회전로직
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * r);

        // transform.Translate( Vector3.forward * moveSpeed * Time.deltaTime * v ); //(방향 * 속도 * 변위)
        // transform.Translate( Vector3.right * moveSpeed * Time.deltaTime * h );   //

        /* 정규화 벡터(Normalized Vector), 단위 벡터(Unit Vector)
            Vector3.forward  = new Vector3(0, 0, 1)
            Vector3.up       = new Vector3(0, 1, 0)
            Vector3.right    = new Vector3(1, 0, 0)

            Vector3.zero     = new Vector3(0, 0, 0)
            Vector3.one      = new Vector3(1, 1, 1)
        */
    }

    void PlayAnim(float h, float v)
    {
        if (v >= 0.1f) //전진
        {
            animation.CrossFade(playerAnim.runForward.name, 0.3f);
        }
        else if (v <= -0.1f) //후진
        {
            animation.CrossFade(playerAnim.runBackward.name, 0.3f);
        }
    }
}
