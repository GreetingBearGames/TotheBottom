using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnCheckpointLevel : MonoBehaviour
{
    private int nowPlayingLevel, maxPlayableLevel;
    [SerializeField] GameObject GameMusicManagerPrefab;
    
    void Start()
    {
        nowPlayingLevel = SceneManager.GetActiveScene().buildIndex;
        maxPlayableLevel = ((nowPlayingLevel - 1) / 3) * 3 + 1;
    }


    void Update()
    {
        
    }


    public void CheckpointLeveleDonus()
    {
        StartCoroutine(SahneYukleyici(maxPlayableLevel));
    }


    IEnumerator SahneYukleyici(int newSceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(newSceneId);
        operation.allowSceneActivation = false;
        yield return new WaitForSeconds(2.3f);
        operation.allowSceneActivation = true;
        MuzikSilmeTekrarBaslatma();
    }

    private void MuzikSilmeTekrarBaslatma()
    {
        GameObject MevcutMusicManager = GameObject.FindGameObjectWithTag("musicmanager");
        Destroy(MevcutMusicManager);
    }
}
