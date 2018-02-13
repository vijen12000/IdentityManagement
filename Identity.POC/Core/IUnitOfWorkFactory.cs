﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.POC.Core
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}