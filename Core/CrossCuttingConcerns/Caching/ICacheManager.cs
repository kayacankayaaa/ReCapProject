using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration); //key gelecek data, object gelebilecek her şey, duration kalma süresi
        bool IsAdd(string key); //cache de var mı?
        void Remove(string key); //cache den uçurma
        void RemoveByPattern(string pattern); //içinde XX olanları uçur
    }
}
