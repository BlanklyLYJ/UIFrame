using System.Collections.Generic;


public enum UILayerTypeEnum
{
    UIFunction = 0,
    UIGuide,
    UITips,
    UISystem,
}

// ui总控 单例模式
public class UIFrame
{
    private static UIFrame _frame;

    public static UIFrame Instance
    {
        get
        {
            if (_frame == null)
                _frame = new UIFrame();
            return _frame;
        }
    }

    // 总层级高度
    private int uiSortingOrder = 0;

    // 每层增加的数量，给特效之类的留空间
    private const int uiPerSortOrderInterval = 20;

    // 层级内容
    private Dictionary<UILayerTypeEnum, UIBaseLayer> uiLayers = new();

    // 层级UI名称
    private Dictionary<UIBaseLayer, List<int>> uiNameMap = new();


    // 打开界面
    public void Open(int uiKey, UILayerTypeEnum layerType)
    {
        
    }
    
    // 打开界面带参
    public void Open(int uiKey, IUIBaseViewParam param, UILayerTypeEnum layerType)
    {
        
    }
    
    public void GetTopPanel()
    {
        
    }
}