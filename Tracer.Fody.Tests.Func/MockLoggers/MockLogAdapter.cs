﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Fody.Tests.Func.MockLoggers
{
    public class MockLogAdapter : IMockLogAdapter
    {
        private readonly Type _type;

        public MockLogAdapter(Type type)
        {
            _type = type;
        }

        public void TraceEnter(string methodInfo)
        {
            MockLogManagerAdapter.TraceEnterCalled(_type.FullName, methodInfo, null, null);
        }

        public void TraceEnter(string methodInfo, string[] paramNames, object[] paramValues)
        {
            var stringValues = paramValues.Select(val => val != null ? val.ToString() : null).ToArray();
            MockLogManagerAdapter.TraceEnterCalled(_type.FullName, methodInfo, paramNames, stringValues);
        }

        public void TraceLeave(string methodInfo, long numberOfTicks)
        {
            MockLogManagerAdapter.TraceLeaveCalled(_type.FullName, methodInfo, null);
        }

        public void TraceLeave(string methodInfo, long numberOfTicks, object returnValue)
        {
            var returnValueString = returnValue != null ? returnValue.ToString() : null;
            MockLogManagerAdapter.TraceLeaveCalled(_type.FullName, methodInfo, returnValueString);
        }

        public void MockLogOuter(string methodInfo, string message)
        {
            MockLogManagerAdapter.LogCalled(_type.FullName, methodInfo, "MockLogOuter", new []{"message"}, new []{ message});
        }
    }
}