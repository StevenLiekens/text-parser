﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpaceLexer.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using JetBrains.Annotations;
using Txt.Core;

namespace Txt.ABNF.Core.SP
{
    public class SpaceLexer : CompositeLexer<Terminal, Space>
    {
        public SpaceLexer([NotNull] ILexer<Terminal> innerLexer)
            : base(innerLexer)
        {
        }
    }
}
