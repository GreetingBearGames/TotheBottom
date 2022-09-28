using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectPanel : MonoBehaviour
{
    private int maxPlayedLevel, maxPlayableLevel;
        

    void Update()
    {
        
    }

    public void HangiLevellerSecilebilirOlacak()
    {
        maxPlayedLevel = PlayerPrefs.GetInt("OynanilanSonLevel");
        maxPlayableLevel = ((maxPlayedLevel - 1) / 3) * 3 + 1;

        /*----------------tüm level butonları deaktive hale getirme--------------
        for(int i = 1; i <= 20; i++)
        {
            GameObject acilacakLeveller = (gameObject.transform.GetChild(2).gameObject).transform.GetChild(i).gameObject;
            acilacakLeveller.GetComponent<Button>().interactable = false;
            acilacakLeveller.GetComponent<Image>().color = new Color(0.764151f, 0.7171677f, 0.02523142f, 0.7803922f);
        }
        */
        
        //----------------oynanılabilir level butonları aktive hale getirme--------------
        for(int i = 1; i <= maxPlayableLevel; i++)
        {
            GameObject acilacakLeveller = (gameObject.transform.GetChild(2).gameObject).transform.GetChild(i).gameObject;
            acilacakLeveller.GetComponent<Button>().interactable = true;
            acilacakLeveller.GetComponent<Image>().color = new Color(0f, 0.6792453f, 0.2020919f, 0.7803922f);
        }
    }
    

    public void LevelSelectPressed(int hangiLeveleGidecek)
    {
        SceneManager.LoadScene(hangiLeveleGidecek);
    }
}
