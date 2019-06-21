using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using KnowledgeBase.Domain.Entity;
using MySqlX.XDevAPI.CRUD;

namespace KnowledgeBase.Domain.IRepository
{
  
    public interface IPostRepository
    {
        int Add(Post model);
        void Delete(int id);
        IEnumerable<Post> GetList();
    }
}