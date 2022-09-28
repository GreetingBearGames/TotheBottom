using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int aktifLevelNumarasi;
    [SerializeField] GameObject GameMusicManagerPrefab;


    void Start()
    {
        Invoke("IlkMuzikPrefabiniOlusturma", 0.5f);
        
        aktifLevelNumarasi = SceneManager.GetActiveScene().buildIndex;
        if(PlayerPrefs.GetInt("OynanilanSonLevel") < aktifLevelNumarasi)    //eğer gelinen level güncel levelden küçükse
        {
            PlayerPrefs.SetInt("OynanilanSonLevel", aktifLevelNumarasi);
        }
    }

    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("MaxCompletedLevel"));
    }

    public void NextLevelGecici()
    {
        StartCoroutine(SahneYukleyici(aktifLevelNumarasi + 1));
    }

    IEnumerator SahneYukleyici(int newSceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(newSceneId);
        operation.allowSceneActivation = false;
        yield return new WaitForSeconds(2);
        operation.allowSceneActivation = true;
    }


    private void IlkMuzikPrefabiniOlusturma()
    {
        GameObject MevcutMusicManager = GameObject.FindGameObjectWithTag("musicmanager");
        if(MevcutMusicManager == null)
        {
            Instantiate(GameMusicManagerPrefab);
        }
    }
}
