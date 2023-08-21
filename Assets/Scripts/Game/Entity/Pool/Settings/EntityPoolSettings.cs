using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entity.Settings
{
    [CreateAssetMenu(fileName = "EntityPoolSettings", menuName = "Settings/EntityPool", order = 0)]
    public class EntityPoolSettings: ScriptableObject, IEntityPoolProvider
    {
        [SerializeField] private List<CategoryModel> _objectModels;

        public IEnumerable<Model> GetAll()
        {
            List<Model> result = new();
            foreach (var category in _objectModels)
            {
                foreach (var model in category.Models)
                    result.Add(model);
            }
            
            return result;
        }

        [Serializable]
        public class Model
        {
            public BaseEntity prefab;
            public int InitCount;
        }
        
        [Serializable]
        public class CategoryModel
        {
            public string Name;
            public List<Model> Models;
        }
    }
}