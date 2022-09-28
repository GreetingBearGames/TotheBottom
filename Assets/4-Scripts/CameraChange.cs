using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour
{
    private int kameraGormeHakki = 1;
    [SerializeField] CinemachineVirtualCamera arkaKamera, ustKamera;
    [SerializeField] GameObject kameraDegistirButonu;

    
    void Start()
    {

    }

    void Update()
    {

    }


    public void KameraDegistir()
    {
        if(kameraGormeHakki > 0)       //arkadan bakıyordu --> üstten bakmaya değiştirecez.
        {
            kameraGormeHakki = kameraGormeHakki - 1;            
            arkaKamera.Priority = 9;
            ustKamera.Priority = 10;
            kameraDegistirButonu.GetComponent<Button>().interactable = false;

            StartCoroutine(KameraEskiPozisyonunaDondur());
        }
    }


    IEnumerator KameraEskiPozisyonunaDondur()
    {
        yield return new WaitForSeconds(3f);
        arkaKamera.Priority = 10;
        ustKamera.Priority = 9;
        kameraDegistirButonu.GetComponent<Button>().interactable = true;

        if(kameraGormeHakki == 0)
        {
            kameraDegistirButonu.SetActive(false);
        }
    }
}
