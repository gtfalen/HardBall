namespace UI
{
    public interface IView<TModel>
    {
        void OnCreate(TModel model);
        void OnRemove();

        void OnShow(TModel model);
        void OnHide();
        
        void Show(TModel model);
        void Hide();

        void Create(TModel model);
    }
    
    public interface IView
    {
        void Show();
        void Hide();
        void Remove();
    }
}