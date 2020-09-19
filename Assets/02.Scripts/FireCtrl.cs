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
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(0.2f);
        muzzleFlash.enabled = false;
    }

}
