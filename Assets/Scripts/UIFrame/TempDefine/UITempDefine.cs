using System.Collections.Generic;


public enum UIKey
{
    LobbyPanel = 1,
    LoginPanel = 2,
    SettingPanel = 3,
    Panel4 = 4,
    Panel5 = 5,
    Panel6 = 6,
}

public struct UITempData
{
    public UIKey UIKey;
    // 预制名称
    public string PrefabName;
    // 预制路径(临时)
    public string PrefabPath;
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
            UIKey.LobbyPanel, new UITempData
            {
                UIKey = UIKey.LobbyPanel,
                PrefabName = "LobbyPanel",
                PrefabPath = "UIPrefab/LobbyPanel",
                ClassName = "LobbyPanelController",
                IsSingle = true,
                UILayerType = UILayerTypeEnum.UIFunction,
                UIOpenActionTypeEnum = UIOpenActionTypeEnum.HidePreviousPanel,
            }
        },
        {
            UIKey.LoginPanel, new UITempData
            {
                UIKey = UIKey.LoginPanel,
                PrefabName = "LoginPanel",
                PrefabPath = "UIPrefab/LoginPanel",
                ClassName = "LoginPanelController",
                IsSingle = true,
                UILayerType = UILayerTypeEnum.UIFunction,
                UIOpenActionTypeEnum = UIOpenActionTypeEnum.HidePreviousPanel,
            }
        },
        {
            UIKey.SettingPanel, new UITempData
            {
                UIKey = UIKey.SettingPanel,
                PrefabName = "SettingPanel",
                PrefabPath = "UIPrefab/SettingPanel",
                ClassName = "SettingPanelController",
                IsSingle = true,
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
                IsSingle = true,
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
                IsSingle = true,
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
                IsSingle = true,
                UILayerType = UILayerTypeEnum.UIFunction,
                UIOpenActionTypeEnum = UIOpenActionTypeEnum.HidePreviousPanel,
            }
        },
    };
}