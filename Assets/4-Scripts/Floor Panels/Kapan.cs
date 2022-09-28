using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kapan : MonoBehaviour
{
    [SerializeField] GameObject gameoverText;
    [SerializeField] GameObject kapan;
    [SerializeField] GameObject myPlayer;  
    [SerializeField] GameObject LevelManager;
    private bool alreadyCollidedwithPlayer = false;
 
   
    void Start()
    {
        transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
    }


    void OnTriggerEnter(Collider other) 
    {
        if(alreadyCollidedwithPlayer == false && other.tag == "Player")
        {
            alreadyCollidedwithPlayer = true;
            kapan.GetComponent<Animator>().Play("Close");
            myPlayer.GetComponent<PlayerMovement>().hareketKatsayisi = 0;
            LevelManager.GetComponent<ReturnCheckpointLevel>().CheckpointLeveleDonus();
            
            StartCoroutine("AzSonraOleceksin");
        }
    }


    IEnumerator AzSonraOleceksin()
    {
        yield return new WaitForSeconds(0.2f);
        myPlayer.GetComponent<Animator>().Play("Dying(Falling)");

        yield return new WaitForSeconds(0.8f);
        gameoverText.SetActive(true);
    }
}
