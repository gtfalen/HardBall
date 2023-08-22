using System.Collections.Generic;

namespace Game.Entity.Settings
{
    public interface IEntitySettingsPoolProvider
    {
        IEnumerable<EntityPoolSettings.Model> GetAll();
    }
}