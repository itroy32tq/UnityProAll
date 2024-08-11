using System;

namespace SaveLoad
{
    public interface IStorageService
    {
        void Save(string key, object data);
        void Load<T>(string key, Action<T> action);
    }
}
