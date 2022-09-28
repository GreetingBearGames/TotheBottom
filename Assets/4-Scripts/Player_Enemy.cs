using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Enemy : MonoBehaviour
{
    //TAG'ı enemy olan nesneler Player'ı öldürür!.
    [SerializeField] GameObject gameoverText;
    private bool alreadyHittoEnemy = false;
    [SerializeField] GameObject LevelManager;
    
        

    void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(alreadyHittoEnemy == false && hit.collider.tag == "enemy")
        {
            alreadyHittoEnemy = true;
            this.GetComponent<PlayerMovement>().hareketKatsayisi = 0;
            LevelManager.GetComponent<ReturnCheckpointLevel>().CheckpointLeveleDonus();

            StartCoroutine("AzSonraOleceksin");
        } 
    }


    IEnumerator AzSonraOleceksin()
    {
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<Animator>().Play("Dying(Falling)");

        yield return new WaitForSeconds(0.8f);
        gameoverText.SetActive(true);
    }
}
