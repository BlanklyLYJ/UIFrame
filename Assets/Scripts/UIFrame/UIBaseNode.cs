// ui界面数据桥接层

using System.Collections.Generic;
using UnityEngine;

public class UIBaseNode
{
    // 界面Id
    private UIKey _uiKey;
    // 界面的预制
    private GameObject _go;
    // 预制名称，用于加载界面预制
    private string _prefabName;
    // 所属界面层级
    private UILayerTypeEnum _layerType;
    // 如果该界面是子界面，那么他的父界面是谁
    private IUIBaseView _rootView;
    // 具体界面脚本
    private IUIBaseView _panelView;
    // 资源加载器，此处没有接入就先放着
    private string _loader;
    // 挂载子界面Key的栈，后进先出
    private Stack<int> _viewNameStack = new();
    // 挂载子界面ViewNode的栈，后进先出
    private Stack<UIBaseNode> _viewNodeStack = new();
    // todo 整理成生命周期enum
    // 是否开启
    private bool _isOpen = false;
    // 是否开启
    private bool _isClose = false;
    // 是否已经被销毁 启用隔帧销毁
    private bool _isDispose = false;

    // 附带参数
    public IUIBaseViewParam ParamData; 
    // 打开界面之后处理的类型
    public UIOpenActionTypeEnum OpenActionType;
    
    public UIBaseNode()
    {
        // todo 初始化
    }

    public void SetNodeParent(GameObject parent)
    {
        
    }
    
    public void SetPanelView(IUIBaseView panelView)
    {
        _panelView = panelView;
    }

    public void SetParam(IUIBaseViewParam param)
    {
        ParamData = param;
    }

    public IUIBaseView GetPanelView()
    {
        return _panelView;
    }

    // 初始化
    public void Init(UITempData uiTempData, IUIBaseViewParam param)
    {
        ParamData = param;
        
        _prefabName = uiTempData.PrefabName;
        
    }

    // 重置
    public void Reset()
    {
    }

    // 启动
    public void Start()
    {
    }

    // 显示
    public void Show()
    {
    }

    // 隐藏
    public void Hide()
    {
    }

    // 销毁
    public void Dispose()
    {
    }
    // 关闭
    public void Close()
    {
        
    }
}