using System.Collections.Generic;

namespace Game.Entity.Settings
{
    public interface IEntityPoolProvider
    {
        IEnumerable<EntityPoolSettings.Model> GetAll();
    }
}