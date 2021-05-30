using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryWriter.Services
{
    public interface IIdentifiable
    {
        string Id { get; set; }
    }

    public interface IFirebaseCollection<T> where T : IIdentifiable
    {
        Task<T> Get(string id);

        Task<IList<T>> GetAll();

        Task<string> Save(T item);

        Task<bool> Update(T item);

        Task<bool> Delete(T item);
    }
}