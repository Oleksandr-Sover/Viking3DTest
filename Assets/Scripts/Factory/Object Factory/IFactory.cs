using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IFactory<T> where T : Object
    {
        List<T> ActiveObjects { get; }
        (T, bool newObject) Create(T original);
        void Destroy(T objectToDestroy);
    }
}