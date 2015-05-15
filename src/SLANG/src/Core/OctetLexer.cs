﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OctetLexer.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SLANG.Core
{
    using Microsoft.Practices.ServiceLocation;

    public class OctetLexer : AlternativeLexer<Octet>
    {
        /// <summary>Initializes a new instance of the <see cref="OctetLexer"/> class.</summary>
        public OctetLexer(IServiceLocator serviceLocator)
            : base(serviceLocator, "OCTET", '\0', '\xFF')
        {
        }
    }
}
