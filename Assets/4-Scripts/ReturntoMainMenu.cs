using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturntoMainMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void MainMenuyeDon()
    {
        GameObject MevcutMusicManager = GameObject.FindGameObjectWithTag("musicmanager");
        Destroy(MevcutMusicManager);
        
        SceneManager.LoadScene(0);
    }
}
