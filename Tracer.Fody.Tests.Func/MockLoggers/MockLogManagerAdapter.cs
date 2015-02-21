﻿using System;
using System.Collections.Generic;

namespace Tracer.Fody.Tests.Func.MockLoggers
{
    public class MockLogManagerAdapter
    {
        private static readonly List<MockCallInfo> Calls = new List<MockCallInfo>();

        public static IMockLogAdapter GetLogger(Type type)
        {
            return new MockLogAdapter(type);
        }

        public static MockLogResult GetResult()
        {
            return new MockLogResult(Calls, true);
        }

        public static void TraceEnterCalled(string loggerName, string containingMethod, string[] paramNames, string[] paramValues)
        {
            Calls.Add(MockCallInfo.CreateEnter(loggerName, containingMethod, paramNames, paramValues));
        }

        public static void TraceLeaveCalled(string loggerName, string containingMethod, string returnValue)
        {
            Calls.Add(MockCallInfo.CreateLeave(loggerName, containingMethod, returnValue));
        }

        public static void LogCalled(string loggerName, string containingMethod, string logMethodCalled,
            string[] paramNames, string[] paramValues)
        {
            
        }
    }
}