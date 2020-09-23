﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;

    public AudioClip fireSfx;
    private new AudioSource audio;

    public MeshRenderer muzzleFlash;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  //0: Left button  , 1: Right Button , 2: Middle
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        audio.PlayOneShot(fireSfx);

        StartCoroutine(ShowMuzzleFlash());
    }

    //코루틴 함수 (Coroutine Funtion)
    IEnumerator ShowMuzzleFlash()
    {
        //MuzzleFlash 회전
        float rot = Random.Range(0.0f, 360.0f);
        muzzleFlash.transform.localRotation = Quaternion.Euler(0, 0, rot);

        //MuzzleFlash Scale 변경
        float scale = Random.Range(1.0f, 3.0f);
        muzzleFlash.transform.localScale = Vector3.one * scale;

        //MuzzleFlash Texture Offset 변경
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f ; //(0, 0) (1, 0) (1, 1) (0, 1) / 2
        muzzleFlash.material.SetTextureOffset("_MainTex", offset);
        //muzzleFlash.material.mainTextureOffset = offset;

        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(0.2f);
        muzzleFlash.enabled = false;
    }

    /*
    Random.Range 함수

    int 파라메터   : Random.Range(0, 10)        => 0 ~ 9
    float 파라메터 : Random.Range(0.0f, 10.0f)  => 0.0f ~ 10.0f
    */


}