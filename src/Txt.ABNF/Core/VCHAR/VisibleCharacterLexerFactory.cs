﻿using System;
using System.Diagnostics;
using Jetbrains.Annotations;
using Txt.Core;

namespace Txt.ABNF.Core.VCHAR
{
    /// <summary>Creates instances of the <see cref="VisibleCharacterLexer" /> class.</summary>
    public class VisibleCharacterLexerFactory : ILexerFactory<VisibleCharacter>
    {
        [DebuggerBrowsable(SwitchOnBuild.DebuggerBrowsableState)]
        private readonly IValueRangeLexerFactory valueRangeLexer;

        /// <summary>
        /// </summary>
        /// <param name="valueRangeLexer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public VisibleCharacterLexerFactory([NotNull] IValueRangeLexerFactory valueRangeLexer)
        {
            if (valueRangeLexer == null)
            {
                throw new ArgumentNullException(nameof(valueRangeLexer));
            }
            this.valueRangeLexer = valueRangeLexer;
        }

        /// <inheritdoc />
        public ILexer<VisibleCharacter> Create()
        {
            var innerLexer = valueRangeLexer.Create('\x21', '\x7E');
            return new VisibleCharacterLexer(innerLexer);
        }
    }
}
