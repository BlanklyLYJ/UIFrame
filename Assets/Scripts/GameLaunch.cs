using UnityEngine;

public class GameLaunch : MonoBehaviour
{
    private void Awake()
    {
        UIFrame.Instance.Init();
        UIFrame.Instance.Open(UIKey.LoginPanel);
    }
}