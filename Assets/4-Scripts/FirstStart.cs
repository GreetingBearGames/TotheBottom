using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStart : MonoBehaviour
{
    void Awake() 
    {
        //DEFAULT SETTINGS --- RUNS ONLY ONCE

        if(PlayerPrefs.GetString("OyunDahaOnceAcildimi") != "EVET")
        {            
            //TÜM KAYITLARI SİL---------------------
            PlayerPrefs.DeleteKey("OynanilanSonLevel");

            //YENİ ATAMALAR---------------------
            PlayerPrefs.SetInt("OynanilanSonLevel", 0);
            PlayerPrefs.SetString("OyunDahaOnceAcildimi", "EVET");
        }
    }
}
