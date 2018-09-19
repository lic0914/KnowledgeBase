using KnowleageBase.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastracture
{
    public class DocTypeService:BaseService<DocType>
    {
        private DataContext _ctx;
        public DocTypeService(DataContext ctx) : base(ctx)
        {
            this._ctx = ctx;
        }
        public async Task Update(int id,string name)
        {
           var e= base.GetById(id);
            e.Name = name;
           await _ctx.SaveChangesAsync();
        }
        
       
    }
}
