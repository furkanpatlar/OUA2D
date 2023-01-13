using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;//ekrana skore yazd�rmak i�in.
    //public int score = 0; //ba�lang��ta skoru 0 olarak tan�mlad�k. SCORE ADLI SCR�PTTEN �EK�CEZ
    private AudioSource _audio;

    private void Awake()
    {
        _audio= GetComponent<AudioSource>(); //sesi cachleme
        _text.text = score.totalScore.ToString();//yeni sahne ba�lad���nda kalan skordan devam etme. 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elmas"))//CompareTag'i elmas olan gameobjecte etki eden kod sat�r�
        {
            _audio.Play();
            Destroy(other.gameObject);//etki edilen gameobjectin silinmesi
            score.totalScore++;//skoru artt�rma SCORE ADLI SCR�PTTEN �EK�YORUZ.
            _text.text=score.totalScore.ToString();//ifadeyi stringe �evirmemiz laz�m.
        }
    }
}
