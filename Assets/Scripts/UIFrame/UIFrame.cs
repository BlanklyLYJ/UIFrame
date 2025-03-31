using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;


public enum UILayerTypeEnum
{
    UIFunction = 0,
    UIGuide = 1,
    UITips = 2,
    UISystem = 3, //系统层
    UIPool = 10, //回收层，所有无用的界面会来到这层
}

// 打开全屏UI时，处理的逻辑
public enum UIOpenActionTypeEnum
{
    None = 0, // 啥都不做
    HidePreviousPanel = 1, //隐藏前面的界面 
    CloseAll = 2, // 关闭该层其他所有界面
}

// ui总控 单例模式
public class UIFrame
{
    // 根节点
    private GameObject _root;

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
    private const int uiPerLayerSortOrderInterval = 1000;

    // 层级内容
    private Dictionary<UILayerTypeEnum, UIBaseLayer> uiLayers = new();

    // 层级UI名称
    private Dictionary<UIKey, List<UIBaseView>> uiNameMap = new();

    // 层级关闭栈 隔帧关闭
    private List<UIBaseView> uiCloseViewStack = new();

    // 界面更新函数
    private Dictionary<UIBaseView, Action<float>> updateFuncMap = new();

    // todo 系统解锁判断

    public void Init()
    {
        // 找到ui节点
        _root = GameObject.Find("Root");

        if (_root == null)
        {
            Debug.LogError("界面Root未找到！uiFrame停止启动");
            return;
        }

        var uiFuncLayer = new UIBaseLayer(UILayerTypeEnum.UIFunction,
            (int)UILayerTypeEnum.UIFunction * uiPerLayerSortOrderInterval, _root);
        var uiGuide = new UIBaseLayer(UILayerTypeEnum.UIGuide,
            (int)UILayerTypeEnum.UIGuide * uiPerLayerSortOrderInterval, _root);
        var uiTips = new UIBaseLayer(UILayerTypeEnum.UITips, (int)UILayerTypeEnum.UITips * uiPerLayerSortOrderInterval,
            _root);
        var uiSystem = new UIBaseLayer(UILayerTypeEnum.UISystem,
            (int)UILayerTypeEnum.UISystem * uiPerLayerSortOrderInterval, _root);
        var uiPool = new UIBaseLayer(UILayerTypeEnum.UIPool, (int)UILayerTypeEnum.UIPool * uiPerLayerSortOrderInterval,
            _root);

        uiLayers.Add(UILayerTypeEnum.UIFunction, uiFuncLayer);
        uiLayers.Add(UILayerTypeEnum.UIGuide, uiGuide);
        uiLayers.Add(UILayerTypeEnum.UITips, uiTips);
        uiLayers.Add(UILayerTypeEnum.UISystem, uiSystem);
        uiLayers.Add(UILayerTypeEnum.UIPool, uiPool);
    }

    // 打开界面
    public void Open(UIKey uiKey, IUIBaseViewParam param, UILayerTypeEnum layerType)
    {
        // todo 从配置中读取界面参数，
        if (!UITempDefine.DefineDic.TryGetValue(uiKey, out UITempData uiTempData))
        {
            Debug.LogError($"[UIFrame] 哥们，你配置呢? uiKey:{uiKey}");
            return;
        }

        if (!uiLayers.TryGetValue(layerType, out UIBaseLayer uiBaseLayer))
        {
            Debug.LogError($"[UIFrame] 层级 layerType:{layerType}并未初始化");
            return;
        }

        // 获取新界面，
        var viewData = GetOrCreateUIBaseView(uiKey, uiTempData);
        if (viewData.Item2 == null)
        {
            return;
        }
        // 创建界面实例go
        
        
        // 在这个时候，完成顶层界面的转换，但是这并不意味着界面的完全关闭和完全开启
        // 引导需要再界面初始化并且show完毕之后才能开始
        UIBaseView node = uiBaseLayer.AddView(uiKey, viewData.Item2, viewData.Item1);
        node.SetParam(param);
        
        if (viewData.Item1)
        {
            node.Init();
            node.Start();
        }
        else
        {
            uiCloseViewStack.Remove(node);
            node.Reset();
        }
        node.Show();
    }

    /// <summary>
    /// 获取或者创建一个界面
    /// </summary>
    /// <param name="uiKey">界面key</param>
    /// <param name="uiTempData">界面参数</param>
    /// <returns>是否是新增, 基础node</returns>
    private (bool, UIBaseView) GetOrCreateUIBaseView(UIKey uiKey, UITempData uiTempData)
    {
        UIBaseView uiBaseNode;
        List<UIBaseView> uiBaseViewList;
        // 如果是这个界面的，就得做一下处理
        if (!uiNameMap.TryGetValue(uiKey, out uiBaseViewList))
        {
            uiBaseViewList = new List<UIBaseView>();
            uiNameMap.Add(uiKey, uiBaseViewList);
        }

        // 里面还有界面，那就拿出来，这里面存的应该是node而不是view
        if (uiBaseViewList.Count > 0 && uiTempData.IsSingle)
        {
            uiBaseNode = uiBaseViewList[0];
            return (false, uiBaseNode);
        }
        else
        {
            // 从池子里拿一个node出来 todo暂时没有，就直接new
            uiBaseNode = _CreateUIBaseView(uiTempData);
            uiBaseViewList.Add(uiBaseNode);
        }

        return (true, uiBaseNode);
    }

    // 反射创建界面实例
    [CanBeNull]
    private UIBaseView _CreateUIBaseView(UITempData uiTempData)
    {
        string className = uiTempData.ClassName;
        Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集
        Type viewType = assembly.GetType(className); // 获取类型

        if (viewType == null || !typeof(UIBaseView).IsAssignableFrom(viewType))
        {
            Debug.LogError($"[UIFrame] 类型未继承UIBaseNode或不存在? uiKey:{uiTempData.UIKey} className:{className}");
            return null;
        }

        UIBaseView baseView = Activator.CreateInstance(viewType) as UIBaseView; // 创建实例
        if (baseView == null)
        {
            Debug.LogError($"[UIFrame] 类型无法转换为UIBaseNode? uiKey:{uiTempData.UIKey} nodeType:{viewType}");
            return null;
        }

        return baseView;
    }

    public void Close(UIKey uiKey, UILayerTypeEnum layerType)
    {
    }

    public void GetTopPanel()
    {
    }
}