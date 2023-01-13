using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Unity sahne ge�i�leri i�in gerekli olan script

public class Engel : MonoBehaviour
{
    private Scene _scene; //sahneye eri�im

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); //aktif scene a�ma
        //Debug.Log(_scene.name); //scene ad�n� ekrana yazd�rma
    }

    private void OnTriggerEnter2D(Collider2D other) //2D engellerin triggerlanmas� i�in yaz�lan blok
    {
        if (other.gameObject.CompareTag("Player")) //Tag'i Player olan obje engele �arpt���nda �al��acak if blo�u
        {
            score.lives--;//can eksiltme sat�r�m�z. score adl� script dosyas�ndan geliyor.
            SceneManager.LoadScene(_scene.name); //sahne ba�tan ba�las�n.
        }
    }
}
