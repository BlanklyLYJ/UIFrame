using UnityEngine.UI;

namespace UI
{
    public class LoginPanelController : UIBaseView
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
            UIFrame.Instance.Open(UIKey.LobbyPanel);
        }
    }
}