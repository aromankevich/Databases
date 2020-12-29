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
        public void Find();
        public void Update();
        public void Generate();
    }
}
