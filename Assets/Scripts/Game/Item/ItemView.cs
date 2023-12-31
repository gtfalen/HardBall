using DG.Tweening;
using Game.Entity;
using UnityEngine;

namespace Game.Item
{
    public class ItemView : BaseEntity
    {
        [Header("The time it takes for an item to attach to a slot")]
        [SerializeField] [Range(0.1f, 99.0f)] private float _stickingTime = 0.1f;

        [Header("Item ico")] 
        public Sprite ItemIco;
        
        public void SetParent(Transform transformParent)
        {
            transform.SetParent(transformParent);
            
            transform
                .DOLocalMove(Vector3.zero, _stickingTime)
                .SetEase(Ease.Flash)
                .SetLink(gameObject);

            transform
                .DOLocalRotate(Vector3.zero, _stickingTime)
                .SetEase(Ease.Flash)
                .SetLink(gameObject);
        }
    }
}