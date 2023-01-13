using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))//CompareTag'i Player olan game object
        {
            Destroy(gameObject); //çarptýðý gameobjecti yokedecek(destroy)
        }
    }
}
