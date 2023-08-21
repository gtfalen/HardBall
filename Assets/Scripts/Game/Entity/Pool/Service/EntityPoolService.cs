using System;
using System.Collections.Generic;
using Game.Entity.Repository;
using Game.Entity.Settings;
using UnityEngine;
using Zenject;

namespace Game.Entity.Pool.Service
{
    public class EntityPoolService: IEntityPoolService, IInitializable
    {
        private readonly IEntityPoolProvider _entityPoolProvider;
        private readonly IEntityPoolRepository _entityPoolRepository;
        private readonly IEntityRepository _entityRepository;

        private readonly Transform _entityParent = new GameObject() { name = "EntitiesPool" }.transform;

        public EntityPoolService
        (
            IEntityPoolProvider entityPoolProvider,
            IEntityPoolRepository entityPoolRepository,
            IEntityRepository entityRepository
        )
        {
            _entityPoolProvider = entityPoolProvider;
            _entityPoolRepository = entityPoolRepository;
            _entityRepository = entityRepository;
        }

        public void Initialize() => InitPool(_entityPoolProvider.GetAll());

        public bool TryRegister(BaseEntity entity)
        {
            if (!_entityPoolRepository.HasOriginalPrefab(entity.GetType()))
            {
                if (!_entityPoolRepository.TryCreateEntityType(entity.GetType(), entity))
                    return false;
            }
            
            _entityRepository.TryAdd(entity);
            return true;
        }

        private void InitPool(IEnumerable<EntityPoolSettings.Model> models)
        {
            foreach (var model in models)
            {
                _entityPoolRepository.TryCreateEntityType(model.prefab.GetType(), model.prefab);
                for (var i = 0; i < model.InitCount; i++)
                    TryDeSpawn(CreateEntity(model.prefab));
            }
        }

        public bool TrySpawn(Type type, Vector3 position, Quaternion rotation, out BaseEntity baseEntity)
        {
            baseEntity = default;
            
            if (!_entityPoolRepository.TryGetFreeEntity(type, out var getEntityView))
            {
                if (!_entityPoolRepository.TryGetOriginalPrefab(type, out var originalPrefab))
                {
                    Debug.LogError("Original prefab not found");
                    return false;
                }
                
                baseEntity = CreateEntity(originalPrefab);
            }
            else
            {
                baseEntity = getEntityView;
            }

            baseEntity.transform.position = position;
            baseEntity.transform.rotation = rotation;
            baseEntity.gameObject.SetActive(true);
            _entityRepository.TryAdd(baseEntity);

            return true;
        }

        public bool TryDeSpawn(BaseEntity baseEntity)
        {
            if (!_entityPoolRepository.TryAddEntity(baseEntity.GetType(), baseEntity))
                return false;

            _entityRepository.TryRemove(baseEntity);
            baseEntity.gameObject.SetActive(false);
            return true;
        }

        private BaseEntity CreateEntity(BaseEntity baseEntity) => GameObject.Instantiate(baseEntity, _entityParent);
    }
}