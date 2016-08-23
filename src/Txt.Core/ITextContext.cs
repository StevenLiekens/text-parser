﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITextContext.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Txt.Core
{
    /// <summary>Provides the interface for types that provide contextual information about their source data.</summary>
    public interface ITextContext
    {
        /// <summary>Gets the current position, relative to the beginning of the data source.</summary>
        int Offset { get; }

        int Line { get; }

        int Column { get; }
    }
}
