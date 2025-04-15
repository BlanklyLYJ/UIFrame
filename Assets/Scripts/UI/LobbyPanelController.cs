using UnityEngine.UI;

namespace UI
{
    public class LobbyPanelController : UIBaseView
    {
        public Button btn;
        
        public override void OnStart()
        {
            base.OnStart();
            btn = _go.transform.Find("Button").GetComponent<Button>();
            btn.onClick.AddListener(HandleClick);
        }

        public void HandleClick()
        {
            UIFrame.Instance.Open(UIKey.SettingPanel);
        }
    }
}