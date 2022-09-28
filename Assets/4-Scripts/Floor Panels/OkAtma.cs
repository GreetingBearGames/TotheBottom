using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkAtma : MonoBehaviour
{
    [SerializeField] GameObject okAtan; //"Ok Atan Blok" objesi içindeki "Spear Trap_export" objesi "okAtan" dır.
    
    
    void Start()
    {
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }


    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            okAtan.GetComponent<Animator>().Play("OkAtmaAnim");
        }
    }
}
