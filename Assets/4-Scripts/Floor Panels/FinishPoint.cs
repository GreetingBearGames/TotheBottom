using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] GameObject finishText;
    [SerializeField] GameObject finishHatch;
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
            finishHatch.GetComponent<Animator>().Play("Open Hatch");
            myPlayer.GetComponent<PlayerMovement>().hareketKatsayisi = 0;
            LevelManager.GetComponent<NextLevel>().NextLevelGecici();

            StartCoroutine("AzSonraDuseceksin");
        }
    }


    IEnumerator AzSonraDuseceksin()
    {
        yield return new WaitForSeconds(0.2f);
        
        floorTilemap.GetComponent<BoxCollider>().enabled = false;

        //GameObject onlyhatch = finishHatch.transform.GetChild(1).gameObject;
        //onlyhatch.GetComponent<BoxCollider>().enabled = false;

        myPlayer.GetComponent<Animator>().SetBool("isFalling", true);

        yield return new WaitForSeconds(0.8f);
        finishText.SetActive(true);
    }

}
