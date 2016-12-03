using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCodes.Models
{
    public interface ICreateOverrayView
    {
        void OverlayViewCreate();
        void OverlayViewDestroy();
    }
}
