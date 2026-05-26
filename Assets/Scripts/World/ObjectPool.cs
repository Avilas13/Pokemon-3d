using System;
using System.Collections.Generic;

namespace Pokemon3D.World
{
    public sealed class ObjectPool<T> where T : class
    {
        private readonly Stack<T> _pool = new();
        private readonly Func<T> _factory;

        public ObjectPool(Func<T> factory, int prewarmCount)
        {
            _factory = factory;
            for (var i = 0; i < prewarmCount; i++)
            {
                _pool.Push(_factory());
            }
        }

        public T Rent() => _pool.Count > 0 ? _pool.Pop() : _factory();

        public void Return(T value) => _pool.Push(value);
    }
}
