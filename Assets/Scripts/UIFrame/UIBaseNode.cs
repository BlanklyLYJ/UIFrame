// ui界面数据桥接层

using System.Collections.Generic;
using UnityEngine;

public class UIBaseNode
{
    // 界面的预制
    private GameObject _go;

    // 具体界面脚本
    private IUIBaseView _panelView;

    // 资源加载器，此处没有接入就先放着
    private string _loader;

    // 挂载子界面Key的栈，后进先出
    private Stack<int> _viewNameStack = new();

    // 挂载子界面ViewNode的栈，后进先出
    private Stack<UIBaseNode> _viewNodeStack = new();
    // 是否开启
    private bool isOpen = false;
    // 是否应该被销毁 启用隔帧销毁
    private bool isDispose = false;
    // 预制名称，用于加载界面预制
    private string _prefabName;
    // 所属界面层级
    private UILayerTypeEnum _layerType;
    // 如果该界面是子界面，那么他的父界面是谁
    private IUIBaseView _rootView;
    // 动效资源
    private Animation _animation;
    // 附带参数
    private IUIBaseViewParam _param; 

    // 初始化
    public void Init()
    {
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
}