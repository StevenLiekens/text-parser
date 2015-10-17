﻿namespace TextFx.ABNF.Core
{
    using System;

    /// <summary>Creates instances of the <see cref="HorizontalTabLexer" /> class.</summary>
    public class HorizontalTabLexerFactory : ILexerFactory<HorizontalTab>
    {
        private readonly ITerminalLexerFactory terminalLexerFactory;

        public HorizontalTabLexerFactory(ITerminalLexerFactory terminalLexerFactory)
        {
            if (terminalLexerFactory == null)
            {
                throw new ArgumentNullException(nameof(terminalLexerFactory));
            }

            this.terminalLexerFactory = terminalLexerFactory;
        }

        /// <inheritdoc />
        public ILexer<HorizontalTab> Create()
        {
            var horizontalTabTerminalLexer = this.terminalLexerFactory.Create("\x09", StringComparer.Ordinal);
            return new HorizontalTabLexer(horizontalTabTerminalLexer);
        }
    }
}