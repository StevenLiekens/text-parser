﻿namespace TextFx.ABNF.Core
{
    using Xunit;

    public class CarriageReturnLexerTests
    {
        [Theory]
        [InlineData("\x0D")]
        public void ReadSuccess(string input)
        {
            var factory = new CarriageReturnLexerFactory(new TerminalLexerFactory());
            var carriageReturnLexer = factory.Create();
            using (var scanner = new TextScanner(new StringTextSource(input)))
            {
                var result = carriageReturnLexer.Read(scanner, null);
                Assert.NotNull(result);
                Assert.True(result.Success);
                Assert.NotNull(result.Element);
                Assert.Equal(input, result.Element.Text);
            }
        }
    }
}
