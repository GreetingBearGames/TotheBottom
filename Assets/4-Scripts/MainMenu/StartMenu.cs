using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject LevelSelectPanel, LevelButtons;
    private bool isLevelSelectPanelOpen;
    
    
    void Start()
    {
        // PlayerPrefs.SetInt("OynanilanSonLevel",0);
    }

    void Update()
    {
        
        //------------------------Level Select Panel dışında bir yere basarsa panel kapansın----------------------
        if(isLevelSelectPanelOpen && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (!RectTransformUtility.RectangleContainsScreenPoint(LevelSelectPanel.GetComponent<RectTransform>(), touch.position)) 
            {
                LevelSelectPanel.SetActive(false);
                isLevelSelectPanelOpen = false;
            }
        }
    }


    public void StartButtonPressed()
    {
        LevelSelectPanel.GetComponent<LevelSelectPanel>().HangiLevellerSecilebilirOlacak();
        LevelSelectPanel.SetActive(true);
        isLevelSelectPanelOpen = true;
    }


    public void RightArrowPressed()
    {
        for(int i = 1; i <= 10; i++)
        {
            GameObject First10Levels = LevelButtons.transform.GetChild(i).gameObject;
            First10Levels.SetActive(false);
        }
        for(int i = 11; i <= 20; i++)
        {
            GameObject Second10Levels = LevelButtons.transform.GetChild(i).gameObject;
            Second10Levels.SetActive(true);
        }
    }

    public void LeftArrowPressed()
    {
        for(int i = 1; i <= 10; i++)
        {
            GameObject First10Levels = LevelButtons.transform.GetChild(i).gameObject;
            First10Levels.SetActive(true);
        }
        for(int i = 11; i <= 20; i++)
        {
            GameObject Second10Levels = LevelButtons.transform.GetChild(i).gameObject;
            Second10Levels.SetActive(false);
        }
    }
}
