using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;//ekrana skore yazdýrmak için.
    //public int score = 0; //baþlangýçta skoru 0 olarak tanýmladýk. SCORE ADLI SCRÝPTTEN ÇEKÝCEZ
    private AudioSource _audio;

    private void Awake()
    {
        _audio= GetComponent<AudioSource>(); //sesi cachleme
        _text.text = score.totalScore.ToString();//yeni sahne baþladýðýnda kalan skordan devam etme. 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elmas"))//CompareTag'i elmas olan gameobjecte etki eden kod satýrý
        {
            _audio.Play();
            Destroy(other.gameObject);//etki edilen gameobjectin silinmesi
            score.totalScore++;//skoru arttýrma SCORE ADLI SCRÝPTTEN ÇEKÝYORUZ.
            _text.text=score.totalScore.ToString();//ifadeyi stringe çevirmemiz lazým.
        }
    }
}
