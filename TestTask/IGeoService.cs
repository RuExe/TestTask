using System;
using System.Collections.Generic;

namespace TestTask
{
    interface IGeoService
    {
        public List<IGeoServiceResponse> GetByAddress(string address);
    }
}
