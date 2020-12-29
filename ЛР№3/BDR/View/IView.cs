using System;
using System.Collections.Generic;
using System.Text;

namespace BDR.View
{
    public interface IView
    {
        public void Read();
        public void Create();
        public void Delete();
        public void Update();
    }
}
