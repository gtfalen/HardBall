using MainMenu.View;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "UIPrefabs", menuName = "Settings/UIPrefabs", order = 0)]
    public class UIPrefabs: ScriptableObject, IUIPrefabs
    {
        [SerializeField] private HudView hudView;

        public HudView HudView => hudView;
    }
}