using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class LevelNumber : MonoBehaviour
{
    private int aktifLevelNumarasi;
    
    
    void Start()
    {
        aktifLevelNumarasi = SceneManager.GetActiveScene().buildIndex;
        //this.GetComponent<Text>().text = "Level: " + aktifLevelNumarasi;
        this.GetComponent<TextMeshProUGUI>().text = "Level: " + aktifLevelNumarasi;
    }

    
    void Update()
    {
        
    }
}
