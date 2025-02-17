﻿using System;
using Microsoft.Azure.Functions.Worker;

namespace Functions.Tests
{
    // Copied from: https://github.com/Azure/azure-functions-dotnet-worker/blob/main/test/DotNetWorkerTests/TestFunctionInvocation.cs
    public class TestFunctionInvocation : FunctionInvocation
    {
        public TestFunctionInvocation()
        {
        }

        public override string Id { get; } = Guid.NewGuid().ToString();
        public override string FunctionId { get; } = Guid.NewGuid().ToString();
        public override TraceContext TraceContext { get; } = new TestTraceContext(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
    }

    internal class TestTraceContext : TraceContext
    {
        public TestTraceContext(string traceParent, string traceState)
        {
            TraceParent = traceParent;
            TraceState = traceState;
        }

        public override string TraceParent { get; }
        public override string TraceState { get; }
    }
}
