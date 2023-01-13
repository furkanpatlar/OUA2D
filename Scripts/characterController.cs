using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 1.0f; // karakterin ba�lang�� h�z�
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3  charPos; //karakter pozisyonuna vector3 tan�mlad�k. (FixedUpdate de�ilde normal update de kullanmak i�in.) 
    private SpriteRenderer _spriteRenderer; // karakterin ters y�ne y�r�t�rken animasyonun terse d�nmesi i�in yazd�k.
    [SerializeField] private GameObject _camera; //serialfield : private olmas�na ra�men edit�rde g�r�nmesini sa�lamak i�in.


    // Start is called before the first frame update
    void Start()//sadece oyun ba�lang�c�nda devreye giren �eyler i�in start � kullan�yoruz.
    {
        _spriteRenderer= GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>(); //oyun ba�lang�c�nda componente ba�l�yoruz.
        _animator = GetComponent<Animator>(); //oyun ba�lang�c�nda componente ba�l�yoruz.
        charPos = transform.position; //Vector3'� startta i�leme ald�k.
    }

    void FixedUpdate() //Fizik hesaplamalar� FixedUpdate e koyulur.
    {
        // r2d.velocity = new Vector2(x: speed, y: 0f); //velocity :karaktere hareket vermek. vector2 : 2 boyutlu oyunda x ve y koordinatlar� demek. x h�z yatay. z�plama istemiyoruz.
       // _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1f); //LateUpdate yerine kameray� buraya koyarsak kamera tak�larak oynar.
    }

    // Update is called once per frame
    void Update()//oyun ba�lad�ktan sonraki hareketler i�in update komutunu kullan�yoruz.
    {
        /*if (Input.GetKey(KeyCode.Space)) //Input : Giri� y�ntemi / Get Key : harekete ge�irme / Key Code : tu� tan�m� ----GetKeyDown yapsayd�k sadece bas�l�yken 1 hareket al�rd�.
        {
            speed = 1f; //h�z 1 f olsun.
            //Debug.Log("Speed 1F"); // space bas�nda console da speed 1F yazacak.
        }
        else  // girdiye gerek yok. yukar�daki ko�ul sa�lanmad���nda 0 a d��ecek.
        {
            speed = 0f;
            //Debug.Log("Speed 0F"); //space bas�lmay�nca console da 0F yazacak.
        }*/ // BURAYI KALDIRIYORUZ ��NK� SPACE �LE HAREKET SA�LAMAK �STEM�YORUZ.

        charPos = new Vector3 (charPos.x +Input.GetAxis("Horizontal") *(speed * Time.deltaTime) , charPos.y ); //h�z� delta timela �arpma sebebimiz sen frame de zaman�n i�inde tutmas�. Fizikle hareket etmiyor. Sadece pozisyonu de�i�iyor. //Input.GetAxis("Horizontal") k�sm�n� sonradan ekledik.
        transform.position = charPos; //karakterime pozisyon de�i�ikli�i verebilmek i�in yazd�k. yazmazsak karakter hareket etmez.
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f); // tu�a bas�lmad���nda karakter idle pozisyonuna ge�mesi i�in.
        }
        else
        {
            _animator.SetFloat("speed", 1.0f); // ilk speed Unity de animatore verdi�imin isim. ikinci speed public floattaki speed.
        }
        if (Input.GetAxis("Horizontal") > 0.01f) //karakterin di�er y�ne ko�arken hareketini �evirmek i�in yazd�k.
        {
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        
        }
    }


    private void LateUpdate()
    {
        _camera.transform.position = new Vector3 (charPos.x, charPos.y, charPos.z  -1f); //z ye -1 verme sebebimiz. kameran�n karekterden 1 metre uzaktan durmas� i�in.
    }
}
