using UnityEngine;

namespace UI
{
    public interface IUIControlService
    {
        TView Create<TView, TModel>(TView prefabView, TModel model) 
            where TView : MonoBehaviour, IView;
        TView Create<TView, TModel>(TView prefabView, TModel model, Transform parent) 
            where TView : MonoBehaviour, IView;

        void Remove<TView>(TView prefabView)
            where TView : MonoBehaviour, IView;
        void RemoveAll();

        void Show<TView>(TView prefabView)
            where TView : MonoBehaviour, IView;

        void Hide<TView>(TView prefabView)
            where TView : MonoBehaviour, IView;
    }
}