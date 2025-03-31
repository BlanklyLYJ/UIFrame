public interface IUIBaseView
{
    // ui启动流程(括号表示可循环) Init->Reset->Start->(Show->Hide)->Dispose;
    // 初始化
    public abstract void Init();
    // 重置
    public abstract void Reset();
    // 启动
    public abstract void Start();
    // 显示
    public abstract void Show();
    // 隐藏
    public abstract void Hide();
    // 销毁
    public abstract void Dispose();

}

// 界面参数
public interface IUIBaseViewParam
{
    
}