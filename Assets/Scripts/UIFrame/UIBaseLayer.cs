// ui层级管理

using System.Collections.Generic;

public class UIBaseLayer
{
    // 当前层级的基础层数
    private int sortBaseNumber = 0;

    // 当前最高层数值
    private int currentTopSortNumber = 0;

    // 当前层级的界面key，按sortNumber顺序排列
    private List<int> _viewList = new List<int>();

    // 当前显示最高层级key
    private int _curRootKey;

    // 当前显示最高层级viewNode
    private UIBaseNode _curRootViewNode;


    // 初始化
    public virtual void OnInit()
    {
        
    }

    // 销毁
    public virtual void OnDispose()
    {
        
    }
}