namespace AP_QuestionSet_CSharp.Core.QuestionSeven
{

    using System;
    using System.Collections.Generic;
    using System.Threading;


    public class ConcurrentDictionary<TKey, TValue> : ICollection<TKey, TValue>    
        where TKey : class, IEquatable<TKey>
        where TValue : class
    {

        private IDictionary<TKey, TValue> _collection;
        private readonly Object _lock;        

        public ConcurrentDictionary()
        {
            _lock = new object();            
            _collection = new Dictionary<TKey, TValue>();
        }

        private void handler(TKey key, TValue value, Action<TKey, TValue> onAction)
        {
            try
            {
                Monitor.Enter(_lock);
                onAction.Invoke(key, value);                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured {ex.Message}");
            }
            finally
            {
                // the lock is released even if an exception is thrown within the body
                Monitor.Exit(_lock);
            }
        }

        public void Add(TKey key, TValue value) =>
            handler(key, value, (k, v) =>
            {
                if (!_collection.ContainsKey(key))
                    _collection.Add(k, v);
            });

        public void Delete(TKey key) =>
             handler(key, default(TValue), (k, v) =>
             {
                 if (_collection.ContainsKey(key))
                     _collection.Remove(key);
             });
       

        public void Update(TKey key, TValue value) =>
             handler(key, value, (k, v) =>
             {
                 if (_collection.ContainsKey(k))
                     _collection[key] = value;
             });
        
        
        public int Count()
        {
            // locking to be safe, most likely a performance hit.
            lock (_lock)
            {
                return _collection.Count;
            }            
        }

        public TValue GetValue(TKey key)
        {
            lock (_lock)
            {
                return _collection.ContainsKey(key) ? _collection[key] : default(TValue);
            }
        }
    }
}
