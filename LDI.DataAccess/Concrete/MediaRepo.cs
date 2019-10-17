using LDI.Core;
using LDI.DataAccess.Abstract;
using LDI.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LDI.DataAccess.Concrete
{
    public class MediaRepo : BaseRepo<Media>, IMediaRepo
    {
        public MediaRepo(Context context):base(context)
        {

        }

    }
}
