using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    //[SerializeField] private int SceneIndex; //manuel unity üzerinden yönlendirme yapýlarak giriþ için.(Alternatif Yöntem.)
    private Scene _scene; //scene tanýmladým.

    private void Awake()
    {
       _scene = SceneManager.GetActiveScene();//aktif sahneyi cacheliyoruz.
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            SceneManager.LoadScene(_scene.buildIndex+1);//mevcut sahneden bir sonraki sahneye geçiþ. 
            //SceneManager.LoadScene(SceneIndex); //editör üzerinde mevcut sahneden hangi sahneye geçeceðini yazýyoruz.(Alternatif Yöntem.)
        }
    }

    public void StartLevel() //baþlangýçtaki buton için yazýlmýþ blok. EDÝTÖRDE GÖZÜKMESÝ ÝÇÝN PUBLÝC VERDÝK. BUTONA FONKSÝYON BAÐLIYORUZ.
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }
}
