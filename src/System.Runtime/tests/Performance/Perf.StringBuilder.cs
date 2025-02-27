﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Text;
using Xunit;
using Microsoft.Xunit.Performance;

namespace System.Runtime.Tests
{
    public class Perf_StringBuilder
    {
        [Benchmark]
        public void ctor()
        {
            StringBuilder builder;
            foreach (var iteration in Benchmark.Iterations)
                using (iteration.StartMeasurement())
                {
                    builder = new StringBuilder(); builder = new StringBuilder(); builder = new StringBuilder();
                    builder = new StringBuilder(); builder = new StringBuilder(); builder = new StringBuilder();
                    builder = new StringBuilder(); builder = new StringBuilder(); builder = new StringBuilder();
                }
        }

        [Benchmark]
        [InlineData(0)]
        [InlineData(200)]
        public void Append(int length)
        {
            foreach (var iteration in Benchmark.Iterations)
            {
                // Setup - Create a string of the specified length
                string builtString = PerfUtils.CreateString(length);
                StringBuilder empty = new StringBuilder();

                // Actual perf testing
                using (iteration.StartMeasurement())
                    empty.Append(builtString); // Appends a string of length "length" to an empty StringBuilder object
            }
        }
    }
}
