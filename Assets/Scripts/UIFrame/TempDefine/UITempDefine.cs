using System.Collections.Generic;


public enum UIKey
{
    Panel1 = 1,
    Panel2 = 2,
    Panel3 = 3,
    Panel4 = 4,
    Panel5 = 5,
    Panel6 = 6,
}

public struct UITempData
{
    public UIKey UIKey;
    // 类名
    public string PrefabName;
    // 类名
    public string ClassName;
    // 是否是只能出现一个界面
    public bool IsSingle;
    public UILayerTypeEnum UILayerType;
    public UIOpenActionTypeEnum UIOpenActionTypeEnum;
}

// 临时的，正常应该走配表
public static class UITempDefine
{
    public static Dictionary<UIKey, UITempData> DefineDic = new()
    {
        {
            UIKey.Panel1, new UITempData
            {
                UIKey = UIKey.Panel1,
                PrefabName = "UIPanel",
                ClassName = "UIPanel",
                IsSingle = false,
                UILayerType = UILayerTypeEnum.UIFunction,
                UIOpenActionTypeEnum = UIOpenActionTypeEnum.HidePreviousPanel,
            }
        },
        {
            UIKey.Panel2, new UITempData
            {
                UIKey = UIKey.Panel2,
                PrefabName = "UIPanel",
                ClassName = "UIPanel",
                IsSingle = false,
                UILayerType = UILayerTypeEnum.UIFunction,
                UIOpenActionTypeEnum = UIOpenActionTypeEnum.HidePreviousPanel,
            }
        },
        {
            UIKey.Panel3, new UITempData
            {
                UIKey = UIKey.Panel3,
                PrefabName = "UIPanel",
                ClassName = "UIPanel",
                IsSingle = false,
                UILayerType = UILayerTypeEnum.UIFunction,
                UIOpenActionTypeEnum = UIOpenActionTypeEnum.HidePreviousPanel,
            }
        },
        {
            UIKey.Panel4, new UITempData
            {
                UIKey = UIKey.Panel4,
                PrefabName = "UIPanel",
                ClassName = "UIPanel",
                IsSingle = false,
                UILayerType = UILayerTypeEnum.UIFunction,
                UIOpenActionTypeEnum = UIOpenActionTypeEnum.HidePreviousPanel,
            }
        },
        {
            UIKey.Panel5, new UITempData
            {
                UIKey = UIKey.Panel5,
                PrefabName = "UIPanel",
                ClassName = "UIPanel",
                IsSingle = false,
                UILayerType = UILayerTypeEnum.UIFunction,
                UIOpenActionTypeEnum = UIOpenActionTypeEnum.HidePreviousPanel,
            }
        },
        {
            UIKey.Panel6, new UITempData
            {
                UIKey = UIKey.Panel6,
                PrefabName = "UIPanel",
                ClassName = "UIPanel",
                IsSingle = false,
                UILayerType = UILayerTypeEnum.UIFunction,
                UIOpenActionTypeEnum = UIOpenActionTypeEnum.HidePreviousPanel,
            }
        },
    };
}