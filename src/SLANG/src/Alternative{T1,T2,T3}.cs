﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Alternative{T1,T2,T3}.cs" company="Steven Liekens">
//   The MIT License (MIT)
// </copyright>
// <summary>
//   Represents a choice of three alternative elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SLANG
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    /// <summary>Represents a choice of three alternative elements.</summary>
    /// <typeparam name="T1">The type of the first alternative element.</typeparam>
    /// <typeparam name="T2">The type of the second alternative element.</typeparam>
    /// <typeparam name="T3">The type of the third alternative element.</typeparam>
    public class Alternative<T1, T2, T3> : Element
        where T1 : Element
        where T2 : Element
        where T3 : Element
    {
        /// <summary>The matched alternative element.</summary>
        private readonly Element element;

        /// <summary>The ordinal position of the matched alternative.</summary>
        private readonly int ordinal;

        /// <summary>Initializes a new instance of the <see cref="Alternative{T1,T2,T3}"/> class with a specified alternative.</summary>
        /// <param name="element">The alternative element.</param>
        /// <param name="alternative">A number that indicates which alternative was matched.</param>
        /// <param name="context">The object that describes the context in which the text appears.</param>
        public Alternative(Element element, int alternative, ITextContext context)
            : base(element.Data, context)
        {
            Contract.Requires(element != null);
            Contract.Requires(context != null);
            switch (alternative)
            {
                case 1:
                    if (false == element is T1)
                    {
                        throw new ArgumentException("Precondition: element is T1", "element");
                    }

                    break;
                case 2:
                    if (false == element is T2)
                    {
                        throw new ArgumentException("Precondition: element is T2", "element");
                    }

                    break;
                case 3:
                    if (false == element is T3)
                    {
                        throw new ArgumentException("Precondition: element is T3", "element");
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException("alternative");
            }

            this.element = element;
            this.ordinal = alternative;
        }

        /// <summary>Gets the matched alternative element.</summary>
        public Element Element
        {
            get
            {
                return this.element;
            }
        }

        /// <summary>Gets the ordinal position of the matched alternative.</summary>
        public int Ordinal
        {
            get
            {
                return this.ordinal;
            }
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.element != null);
        }
    }
}