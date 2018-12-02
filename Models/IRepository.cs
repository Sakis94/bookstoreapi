using System;
using System.Collections.Generic;

namespace Models
{
    public interface IRepository : IDisposable
    {
        void Add<T>(T item) where T : class, new();
        void Update<T>(T item) where T : class, new();
        void Delete<T>(T item) where T : class, new();
    }
}