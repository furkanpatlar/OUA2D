using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesControl : MonoBehaviour
{
    private void Awake()
    {
        switch (score.lives) //can eksiltiðinde kapatýlmasý gereken gameobjectlerden dolayý switch yazýyoruz.
        {
            case 3:
                break;
            case 2:
                gameObject.transform.GetChild(2).gameObject.SetActive(false); //1 tanesini kapatýp 2 tanesi kalacak.
                break;
            case 1:
                gameObject.transform.GetChild(2).gameObject.SetActive(false); //2 tanesi kalacak.
                gameObject.transform.GetChild(1).gameObject.SetActive(false); //1 tanesi kalacak.
                break;
            case 0:
                SceneManager.LoadScene(4);
                break;
            default:
                break;
        }
    }
}
