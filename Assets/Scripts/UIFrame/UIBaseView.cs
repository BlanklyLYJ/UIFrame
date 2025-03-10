// ui界面基础

using UnityEngine;



public class UIBaseView : MonoBehaviour, IUIBaseView
{
    // 界面key
    private int _key;
    // 所属的桥接节点
    private UIBaseNode _node;
    
    
    public void OnInit()
    {
    }

    public void OnReset()
    {
    }

    public void OnStart()
    {
    }

    public void OnShow()
    {
    }

    public void OnHide()
    {
    }

    public void OnDispose()
    {
    }
}