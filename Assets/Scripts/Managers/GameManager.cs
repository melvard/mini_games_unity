using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; set; }
    public TouchManager TouchManager;
    public PlayerManager PlayerManager;

    private void Awake()
    {
        Instance = this;
    }
}
