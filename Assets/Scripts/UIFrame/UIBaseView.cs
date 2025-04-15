// ui界面基础

using System.Collections.Generic;
using UnityEngine;

public class UIBaseView : IUIBaseView
{
    // 界面Id
    public  UIKey _uiKey;

    // 界面的预制
    public GameObject _go;
    
    // 预制名称，用于加载界面预制
    public  string _prefabName;

    // 所属界面层级
    public  UILayerTypeEnum _layerType;
    
    // 画布
    public  Canvas _canvas;

    // 动效资源
    public  Animation _animation;

    // 如果该界面是子界面，那么他的父界面是谁
    public  IUIBaseView _rootView;

    // 资源加载器，此处没有接入就先放着
    public  string _loader;

    // 挂载子界面Key的栈，后进先出
    public  Stack<int> _viewNameStack = new();

    // 挂载子界面baseView的栈，后进先出
    public  Stack<UIBaseView> _viewStack = new();

    // todo 整理成生命周期enum
    // 是否开启
    public  bool _isOpen = false;

    // 是否开启
    public  bool _isClose = false;

    // 是否已经被销毁 启用隔帧销毁
    public  bool _isDispose = false;

    // 附带参数
    public IUIBaseViewParam ParamData;

    // 打开界面之后处理的类型
    public UIOpenActionTypeEnum OpenActionType;

    #region 生命周期函数
    public void Init()
    {
        OnInit();
    }

    public void Reset()
    {
        OnReset();
    }

    public void Start()
    {
        OnStart();
    }

    public void Show()
    {
        OnShow();
    }

    public void Hide()
    {
        OnHide();
    }

    public void Dispose()
    {
        OnDispose();
    }
    #endregion
    
    public virtual void OnInit()
    {
    }

    public virtual void OnReset()
    {
    }

    public virtual void OnStart()
    {
    }

    public virtual void OnShow()
    {
    }

    public virtual void OnHide()
    {
    }

    public virtual void OnDispose()
    {
    }

    public void Close()
    {
    }

    public void SetParam(IUIBaseViewParam param)
    {
        ParamData = param;
    }
    
    public void SetGameObject(GameObject gameObject)
    {
        _go = gameObject;
        _canvas = _go.GetComponent<Canvas>();
        if (_canvas == null)
            _canvas = _go.AddComponent<Canvas>();
        _canvas.sortingLayerName = "UI";
    }
    public void SetLayerData(GameObject parent, UILayerTypeEnum layerType)
    {
        _layerType = layerType;
        _go.transform.SetParent(parent.transform, false);
    }

    public void SetSortingOrder(int sortOrder)
    {
        _canvas.overrideSorting = true;
        _canvas.sortingOrder = sortOrder;
    }
}