using UnityEngine;

namespace UI
{
    public abstract class BaseView<TModel> : MonoBehaviour, IView<TModel>, IView
    {
        public TModel CurrentModel { get; private set; }
        public bool IsShow { get; private set; }

        private void OnEnable()
        {
            if(IsShow || CurrentModel == null)
                return;
            
            OnShow(CurrentModel);
        }

        public void Show(TModel model)
        {
            IsShow = true;
            CurrentModel = model;
            OnShow(model);
            gameObject.SetActive(true);
        }

        public void Show()
        {
            IsShow = true;
            OnShow(CurrentModel);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            IsShow = false;
            OnHide();
            gameObject.SetActive(false);
        }

        public void Create(TModel model)
        {
            CurrentModel = model;
            OnCreate(CurrentModel);
            Show(model);
        }

        public void Remove()
        {
            IsShow = false;
            OnRemove();
            Destroy(gameObject);
        }

        public virtual void OnCreate(TModel model) { }

        public virtual void OnRemove() { }

        public virtual void OnShow(TModel model) { }

        public virtual void OnHide() { }
    }
}