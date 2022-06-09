using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;
using Microsoft.EntityFrameworkCore;

namespace BiciSendas.DA
{
    public class FaqDA : BaseRepository<Faq>
    {
        private readonly BicisendasContext context;

        public FaqDA(BicisendasContext context) : base(context)
        {
            this.context = context;
        }
    }
}
