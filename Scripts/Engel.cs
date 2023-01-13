using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Unity sahne geçiþleri için gerekli olan script

public class Engel : MonoBehaviour
{
    private Scene _scene; //sahneye eriþim

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); //aktif scene açma
        //Debug.Log(_scene.name); //scene adýný ekrana yazdýrma
    }

    private void OnTriggerEnter2D(Collider2D other) //2D engellerin triggerlanmasý için yazýlan blok
    {
        if (other.gameObject.CompareTag("Player")) //Tag'i Player olan obje engele çarptýðýnda çalýþacak if bloðu
        {
            score.lives--;//can eksiltme satýrýmýz. score adlý script dosyasýndan geliyor.
            SceneManager.LoadScene(_scene.name); //sahne baþtan baþlasýn.
        }
    }
}
