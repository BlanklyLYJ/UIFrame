// ui层级管理

using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UIBaseLayer
{
    // 根节点
    private GameObject parentRoot;
    // 自身的go
    private GameObject layerRoot;
    // 层级类型
    private UILayerTypeEnum layerType;
    // 当前层级的基础层数
    private int sortBaseNumber = 0;
    // 当前最高层数值
    private int currentTopSortNumber = 0;
    // 每层增加的数量，给特效之类的留空间
    private int uiPerUISortOrderInterval = 20;
    // 当前层级的界面key，按sortNumber顺序排列
    private List<UIKey> _uiKeyList = new List<UIKey>();
    // 当前层级所有界面Node，按sortNumber顺序排列
    private List<UIBaseView> _uiViewList = new List<UIBaseView>();
    // 当前显示最高层级key
    private UIKey _curRootKey;
    // 当前显示最高层级viewNode
    private UIBaseView _curRootView;
    // 界面画布
    private Canvas _canvas;

    public UIBaseLayer(UILayerTypeEnum _layerType, int _sortBaseNumber, GameObject _parentRoot)
    {
        layerType = _layerType;
        sortBaseNumber = _sortBaseNumber;
        currentTopSortNumber = sortBaseNumber;
        parentRoot = _parentRoot;
        layerRoot = new GameObject(layerType.ToString());
        layerRoot.transform.SetParent(_parentRoot.transform);
        layerRoot.transform.localPosition = Vector3.zero;
        // 层级设置为UI
        layerRoot.layer = LayerMask.NameToLayer("UI");
        // 添加画布
        Canvas canvas = layerRoot.AddComponent<Canvas>();
        // 添加射线检测基础
        layerRoot.AddComponent<GraphicRaycaster>();
        // 继承渲染排序
        canvas.overrideSorting = true;
        // 渲染层级名称设置为"UI"
        canvas.sortingLayerName = "UI";
        // 设置基础层级
        canvas.sortingOrder = sortBaseNumber;
    }

    public UIBaseView AddView(UIKey uiKey, UIBaseView uiBaseView, bool isNew)
    {
        // 如果不是新的，而且队列里有，那就给他拿出来
        if (!isNew && _uiViewList.Contains(uiBaseView))
        {
            // 如果这个界面已经在这个层级里了，那就给他调到最高层
            var index = _uiViewList.IndexOf(uiBaseView);
            _uiKeyList.RemoveAt(index);
            _uiViewList.RemoveAt(index);
        }

        _uiKeyList.Add(uiKey);
        _uiViewList.Add(uiBaseView);
        
        _curRootKey = uiKey;
        _curRootView = uiBaseView;
        
        // todo 宣布自己是第一个界面 HandleViewToTop 处理为顶层的时候，再去处理下面的旧界面
        
        // 宣布旧界面该怎么做
        if (uiBaseView.OpenActionType == UIOpenActionTypeEnum.HidePreviousPanel)
        {
            // 前一个界面要执行隐藏逻辑
            if (_curRootView != null)
            {
                // todo 这里应该处理一下hide逻辑
                _curRootView.OnHide();
            }
        }
        else if (uiBaseView.OpenActionType == UIOpenActionTypeEnum.CloseAll)
        {
            _uiKeyList.Clear();
            foreach (UIBaseView baseNode in _uiViewList)
            {
                baseNode.Close();
            }
            _uiViewList.Clear();
        }

        if (isNew)
        {
            uiBaseView.SetLayerData(layerRoot, layerType);
            uiBaseView.SetSortingOrder(GetNextTopSortingNumber());
        }
        else
        {
            AdjustSortOrder();
        }

        return uiBaseView;
    }

    private int GetNextTopSortingNumber()
    {
        currentTopSortNumber += uiPerUISortOrderInterval;
        return currentTopSortNumber;
    }

    private void AdjustSortOrder()
    {
        int count = 0;
        currentTopSortNumber = sortBaseNumber;
        foreach (UIBaseView baseView in _uiViewList)
        {
            baseView.SetSortingOrder(GetNextTopSortingNumber());
            baseView._go.transform.SetSiblingIndex(count++);
        }
    }

    // 初始化
    public virtual void OnInit(int baseNumber)
    {
        
    }

    // 销毁
    public virtual void OnDispose()
    {
        _uiKeyList.Clear();
        foreach (UIBaseView baseView in _uiViewList)
        {
            baseView.OnDispose();
        }
        _uiViewList.Clear();
    }
}