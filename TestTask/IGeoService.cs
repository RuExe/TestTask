﻿using System;
using System.Collections.Generic;

namespace TestTask
{
    interface IGeoService
    {
        public List<IGeoServiceResponce> GetByAdress(string adress);
    }
}
