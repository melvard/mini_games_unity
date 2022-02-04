using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeGameManager : MonoBehaviour
{
    public AnimeTouchManager animeTouchManager;
    public AnimePlayerManager animePlayerManager;
    public ForbidenAreaManager forbidenAreaManager;

    private static AnimeGameManager _instance;
    public static AnimeGameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AnimeGameManager>();
                if (_instance == null)
                {
                    GameObject gm = new GameObject();
                    gm.name = "AnimeGameManager";
                    _instance = gm.AddComponent<AnimeGameManager>();
                    DontDestroyOnLoad(gm);
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void KillCharacter()
    {
        animeTouchManager.enabled = false;
        animePlayerManager.Kill();
    }

}
