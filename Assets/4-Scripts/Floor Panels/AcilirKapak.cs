using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcilirKapak : MonoBehaviour
{
    
    [SerializeField] GameObject gameoverText;
    [SerializeField] GameObject acilirKapak;
    [SerializeField] GameObject floorTilemap;
    [SerializeField] GameObject myPlayer;   
    [SerializeField] GameObject LevelManager;
    private bool alreadyCollidedwithPlayer = false;

    
    void Start()
    {
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }


    void OnTriggerEnter(Collider other) 
    {
        if(alreadyCollidedwithPlayer == false && other.tag == "Player")
        {
            alreadyCollidedwithPlayer = true;
            acilirKapak.GetComponent<Animator>().SetTrigger("open");
            myPlayer.GetComponent<PlayerMovement>().hareketKatsayisi = 0;
            LevelManager.GetComponent<ReturnCheckpointLevel>().CheckpointLeveleDonus();

            StartCoroutine("AzSonraDuseceksin");
        }
    }


    IEnumerator AzSonraDuseceksin()
    {
        yield return new WaitForSeconds(0.2f);
        
        floorTilemap.GetComponent<BoxCollider>().enabled = false;

        // GameObject leftHatch = acilirKapak.transform.GetChild(0).gameObject;
        // leftHatch.GetComponent<BoxCollider>().enabled = false;
        // GameObject rightHatch = acilirKapak.transform.GetChild(1).gameObject;
        // rightHatch.GetComponent<BoxCollider>().enabled = false;
        

        myPlayer.GetComponent<Animator>().SetBool("isFalling", true);

        yield return new WaitForSeconds(0.8f);
        acilirKapak.GetComponent<Animator>().SetTrigger("close");
        gameoverText.SetActive(true);
    }
}
