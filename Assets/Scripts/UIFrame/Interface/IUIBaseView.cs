public interface IUIBaseView
{
    // ui启动流程(括号表示可循环) OnInit->OnReset->OnStart->(OnShow->OnHide)->OnDispose;
    // 初始化
    public abstract void OnInit();
    // 重置
    public abstract void OnReset();
    // 启动
    public abstract void OnStart();
    // 显示
    public abstract void OnShow();
    // 隐藏
    public abstract void OnHide();
    // 销毁
    public abstract void OnDispose();

}

public interface IUIBaseViewParam
{
    
}