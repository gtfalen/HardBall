using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIControlService: IUIControlService
    {
        private List<IView> _views = new List<IView>();

        public TView Create<TView, TModel>(TView prefabView, TModel model) 
            where TView : MonoBehaviour, IView 
        {
            if (prefabView is null)
                throw new ArgumentNullException(nameof(prefabView));
            
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var view = GameObject.Instantiate(prefabView);
            (view as BaseView<TModel>)?.Create(model);
            
            _views.Add(view);
            return view;
        }

        public TView Create<TView, TModel>(TView prefabView, TModel model, Transform parent) 
            where TView : MonoBehaviour, IView
        {
            if (prefabView is null)
                throw new ArgumentNullException(nameof(prefabView));
            
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            
            if (parent is null)
                throw new ArgumentNullException(nameof(parent));

            var view = GameObject.Instantiate(prefabView, parent);
            (view as BaseView<TModel>)?.Create(model);
            
            _views.Add(view);
            return view;
        }

        public void Show<TView>(TView prefabView)
            where TView : MonoBehaviour, IView => prefabView.Show();

        public void Hide<TView>(TView prefabView)
            where TView : MonoBehaviour, IView => prefabView.Hide();

        public void Remove<TView>(TView prefabView)
            where TView : MonoBehaviour, IView => prefabView.Remove();

        public void RemoveAll()
        {
            foreach (var view in _views)
                view.Remove();
            _views.Clear();
        }
    }
}