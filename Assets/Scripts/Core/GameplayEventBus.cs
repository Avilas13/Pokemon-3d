using System;
using System.Collections.Generic;

namespace Pokemon3D.Core
{
    // Central event hub to keep systems decoupled and multiplayer-ready.
    public sealed class GameplayEventBus
    {
        private readonly Dictionary<Type, Delegate> _handlers = new();

        public void Subscribe<T>(Action<T> handler)
        {
            if (_handlers.TryGetValue(typeof(T), out var existing))
            {
                _handlers[typeof(T)] = Delegate.Combine(existing, handler);
                return;
            }

            _handlers[typeof(T)] = handler;
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            if (!_handlers.TryGetValue(typeof(T), out var existing))
            {
                return;
            }

            var reduced = Delegate.Remove(existing, handler);
            if (reduced == null)
            {
                _handlers.Remove(typeof(T));
                return;
            }

            _handlers[typeof(T)] = reduced;
        }

        public void Publish<T>(T evt)
        {
            if (_handlers.TryGetValue(typeof(T), out var existing) && existing is Action<T> callback)
            {
                callback.Invoke(evt);
            }
        }
    }
}
