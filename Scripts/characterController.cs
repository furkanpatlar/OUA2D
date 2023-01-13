using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 1.0f; // karakterin baþlangýç hýzý
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3  charPos; //karakter pozisyonuna vector3 tanýmladýk. (FixedUpdate deðilde normal update de kullanmak için.) 
    private SpriteRenderer _spriteRenderer; // karakterin ters yöne yürütürken animasyonun terse dönmesi için yazdýk.
    [SerializeField] private GameObject _camera; //serialfield : private olmasýna raðmen editörde görünmesini saðlamak için.


    // Start is called before the first frame update
    void Start()//sadece oyun baþlangýcýnda devreye giren þeyler için start ý kullanýyoruz.
    {
        _spriteRenderer= GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>(); //oyun baþlangýcýnda componente baðlýyoruz.
        _animator = GetComponent<Animator>(); //oyun baþlangýcýnda componente baðlýyoruz.
        charPos = transform.position; //Vector3'ü startta iþleme aldýk.
    }

    void FixedUpdate() //Fizik hesaplamalarý FixedUpdate e koyulur.
    {
        // r2d.velocity = new Vector2(x: speed, y: 0f); //velocity :karaktere hareket vermek. vector2 : 2 boyutlu oyunda x ve y koordinatlarý demek. x hýz yatay. zýplama istemiyoruz.
       // _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1f); //LateUpdate yerine kamerayý buraya koyarsak kamera takýlarak oynar.
    }

    // Update is called once per frame
    void Update()//oyun baþladýktan sonraki hareketler için update komutunu kullanýyoruz.
    {
        /*if (Input.GetKey(KeyCode.Space)) //Input : Giriþ yöntemi / Get Key : harekete geçirme / Key Code : tuþ tanýmý ----GetKeyDown yapsaydýk sadece basýlýyken 1 hareket alýrdý.
        {
            speed = 1f; //hýz 1 f olsun.
            //Debug.Log("Speed 1F"); // space basýnda console da speed 1F yazacak.
        }
        else  // girdiye gerek yok. yukarýdaki koþul saðlanmadýðýnda 0 a düþecek.
        {
            speed = 0f;
            //Debug.Log("Speed 0F"); //space basýlmayýnca console da 0F yazacak.
        }*/ // BURAYI KALDIRIYORUZ ÇÜNKÜ SPACE ÝLE HAREKET SAÐLAMAK ÝSTEMÝYORUZ.

        charPos = new Vector3 (charPos.x +Input.GetAxis("Horizontal") *(speed * Time.deltaTime) , charPos.y ); //hýzý delta timela çarpma sebebimiz sen frame de zamanýn içinde tutmasý. Fizikle hareket etmiyor. Sadece pozisyonu deðiþiyor. //Input.GetAxis("Horizontal") kýsmýný sonradan ekledik.
        transform.position = charPos; //karakterime pozisyon deðiþikliði verebilmek için yazdýk. yazmazsak karakter hareket etmez.
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f); // tuþa basýlmadýðýnda karakter idle pozisyonuna geçmesi için.
        }
        else
        {
            _animator.SetFloat("speed", 1.0f); // ilk speed Unity de animatore verdiðimin isim. ikinci speed public floattaki speed.
        }
        if (Input.GetAxis("Horizontal") > 0.01f) //karakterin diðer yöne koþarken hareketini çevirmek için yazdýk.
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
        _camera.transform.position = new Vector3 (charPos.x, charPos.y, charPos.z  -1f); //z ye -1 verme sebebimiz. kameranýn karekterden 1 metre uzaktan durmasý için.
    }
}
