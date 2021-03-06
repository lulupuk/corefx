// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Globalization;
using Xunit;

namespace System.Tests
{
    public partial class ByteTests
    {
        [Theory]
        [MemberData(nameof(Parse_Valid_TestData))]
        public static void Parse_Span_Valid(string value, NumberStyles style, IFormatProvider provider, byte expected)
        {
            Assert.Equal(expected, byte.Parse(value.AsReadOnlySpan(), style, provider));

            Assert.True(byte.TryParse(value.AsReadOnlySpan(), style, provider, out byte result));
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(Parse_Invalid_TestData))]
        public static void Parse_Span_Invalid(string value, NumberStyles style, IFormatProvider provider, Type exceptionType)
        {
            if (value != null)
            {
                Assert.Throws(exceptionType, () => byte.Parse(value.AsReadOnlySpan(), style, provider));

                Assert.False(byte.TryParse(value.AsReadOnlySpan(), style, provider, out byte result));
                Assert.Equal(0, result);
            }
        }
    }
}
