﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Log4net.Adapters
{
    public static class LogManagerAdapter
    {
        public static LoggerAdapter GetLogger(Type type)
        {
            return new LoggerAdapter();
        }
    }
}
