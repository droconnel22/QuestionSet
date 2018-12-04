namespace AP_QuestionSet_CSharp.Core.QuestionSeven
{
    // add, update, delete 
    public interface ICollection<TKey,TValue>
    {
        void Add(TKey key, TValue value);

        void Update(TKey key, TValue value);

        void Delete(TKey key);

        int Count();

        TValue GetValue(TKey key);

    }
}
