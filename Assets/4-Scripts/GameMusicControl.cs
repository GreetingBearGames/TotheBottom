using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicControl : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
