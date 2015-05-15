﻿namespace SLANG
{
    using System;

    using Microsoft.Practices.ServiceLocation;

    /// <summary>Provides the base class for lexers whose lexer rule is a sequence of five elements.</summary>
    /// <typeparam name="TSequence">The type of the lexer rule.</typeparam>
    /// <typeparam name="T1">The type of the first element in the sequence.</typeparam>
    /// <typeparam name="T2">The type of the second element in the sequence.</typeparam>
    /// <typeparam name="T3">The type of the third element in the sequence.</typeparam>
    /// <typeparam name="T4">The type of the fourth element in the sequence.</typeparam>
    /// <typeparam name="T5">The type of the fifth element in the sequence.</typeparam>
    public abstract class SequenceLexer<TSequence, T1, T2, T3, T4, T5> : Lexer<TSequence>
        where TSequence : Sequence<T1, T2, T3, T4, T5>
        where T1 : Element
        where T2 : Element
        where T3 : Element
        where T4 : Element
        where T5 : Element
    {
        /// <summary>Initializes a new instance of the <see cref="SequenceLexer{TSequence,T1,T2,T3,T4,T5}"/> class for an unnamed element.</summary>
        /// <param name="serviceLocator">The object that retrieves instances of <see cref="ILexer{TElement}"/> by type and optional rule name.</param>
        protected SequenceLexer(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SequenceLexer{TSequence,T1,T2,T3,T4,T5}"/> class for a specified rule.</summary>
        /// <param name="serviceLocator">The object that retrieves instances of <see cref="ILexer{TElement}"/> by type and optional rule name.</param>
        /// <param name="ruleName">The name of the lexer rule. Rule names are case insensitive.</param>
        /// <exception cref="ArgumentException">The value of <paramref name="ruleName"/> is a <c>null</c> reference (<c>Nothing</c> in Visual Basic) -or- the value of <paramref name="ruleName"/> does not start with a letter -or- the value of <paramref name="ruleName"/> contains one or more characters that are not letters, digits or hyphens.</exception>
        protected SequenceLexer(IServiceLocator serviceLocator, string ruleName)
            : base(serviceLocator, ruleName)
        {
        }

        /// <inheritdoc />
        public override bool TryRead(ITextScanner scanner, out TSequence element)
        {
            if (scanner.EndOfInput)
            {
                element = default(TSequence);
                return false;
            }

            var context = scanner.GetContext();
            T1 element1;
            if (!this.TryRead1(scanner, out element1))
            {
                element = default(TSequence);
                return false;
            }

            T2 element2;
            if (!this.TryRead2(scanner, out element2))
            {
                scanner.PutBack(element1.Data);
                element = default(TSequence);
                return false;
            }

            T3 element3;
            if (!this.TryRead3(scanner, out element3))
            {
                scanner.PutBack(element2.Data);
                scanner.PutBack(element1.Data);
                element = default(TSequence);
                return false;
            }

            T4 element4;
            if (!this.TryRead4(scanner, out element4))
            {
                scanner.PutBack(element3.Data);
                scanner.PutBack(element2.Data);
                scanner.PutBack(element1.Data);
                element = default(TSequence);
                return false;
            }

            T5 element5;
            if (!this.TryRead5(scanner, out element5))
            {
                scanner.PutBack(element4.Data);
                scanner.PutBack(element3.Data);
                scanner.PutBack(element2.Data);
                scanner.PutBack(element1.Data);
                element = default(TSequence);
                return false;
            }

            element = this.CreateInstance(
                element1,
                element2,
                element3,
                element4,
                element5,
                context);
            return true;
        }

        /// <summary>Creates a new instance of the lexer rule with the given elements.</summary>
        /// <param name="element1">The first element in the sequence.</param>
        /// <param name="element2">The second element in the sequence.</param>
        /// <param name="element3">The third element in the sequence.</param>
        /// <param name="element4">The fourth element in the sequence.</param>
        /// <param name="element5">The fifth element in the sequence.</param>
        /// <param name="context">The object that describes the context in which the text appears.</param>
        /// <returns>An instance of the lexer rule.</returns>
        protected virtual TSequence CreateInstance(
            T1 element1,
            T2 element2,
            T3 element3,
            T4 element4,
            T5 element5,
            ITextContext context)
        {
            return (TSequence)Activator.CreateInstance(typeof(TSequence), element1, element2, element3, element4, element5, context);
        }

        /// <summary>Attempts to read the first element of the sequence. A return value indicates whether the element was available.</summary>
        /// <param name="scanner">The scanner object that provides text symbols as well as contextual information about the text source.</param>
        /// <param name="element">When this method returns, contains the next available element, or a <c>null</c> reference, depending on whether the return value indicates success.</param>
        /// <exception cref="T:System.InvalidOperationException">The given scanner object is not initialized.</exception>
        /// <exception cref="T:System.ObjectDisposedException">The given text scanner is closed.</exception>
        /// <returns><c>true</c> to indicate success; otherwise, <c>false</c>.</returns>
        protected virtual bool TryRead1(ITextScanner scanner, out T1 element)
        {
            return this.Services.GetInstance<ILexer<T1>>().TryRead(scanner, out element);
        }

        /// <summary>Attempts to read the second element of the sequence. A return value indicates whether the element was available.</summary>
        /// <param name="scanner">The scanner object that provides text symbols as well as contextual information about the text source.</param>
        /// <param name="element">When this method returns, contains the next available element, or a <c>null</c> reference, depending on whether the return value indicates success.</param>
        /// <exception cref="T:System.InvalidOperationException">The given scanner object is not initialized.</exception>
        /// <exception cref="T:System.ObjectDisposedException">The given text scanner is closed.</exception>
        /// <returns><c>true</c> to indicate success; otherwise, <c>false</c>.</returns>
        protected virtual bool TryRead2(ITextScanner scanner, out T2 element)
        {
            return this.Services.GetInstance<ILexer<T2>>().TryRead(scanner, out element);
        }

        /// <summary>Attempts to read the third element of the sequence. A return value indicates whether the element was available.</summary>
        /// <param name="scanner">The scanner object that provides text symbols as well as contextual information about the text source.</param>
        /// <param name="element">When this method returns, contains the next available element, or a <c>null</c> reference, depending on whether the return value indicates success.</param>
        /// <exception cref="T:System.InvalidOperationException">The given scanner object is not initialized.</exception>
        /// <exception cref="T:System.ObjectDisposedException">The given text scanner is closed.</exception>
        /// <returns><c>true</c> to indicate success; otherwise, <c>false</c>.</returns>
        protected virtual bool TryRead3(ITextScanner scanner, out T3 element)
        {
            return this.Services.GetInstance<ILexer<T3>>().TryRead(scanner, out element);
        }

        /// <summary>Attempts to read the fourth element of the sequence. A return value indicates whether the element was available.</summary>
        /// <param name="scanner">The scanner object that provides text symbols as well as contextual information about the text source.</param>
        /// <param name="element">When this method returns, contains the next available element, or a <c>null</c> reference, depending on whether the return value indicates success.</param>
        /// <exception cref="T:System.InvalidOperationException">The given scanner object is not initialized.</exception>
        /// <exception cref="T:System.ObjectDisposedException">The given text scanner is closed.</exception>
        /// <returns><c>true</c> to indicate success; otherwise, <c>false</c>.</returns>
        protected virtual bool TryRead4(ITextScanner scanner, out T4 element)
        {
            return this.Services.GetInstance<ILexer<T4>>().TryRead(scanner, out element);
        }

        /// <summary>Attempts to read the fifth element of the sequence. A return value indicates whether the element was available.</summary>
        /// <param name="scanner">The scanner object that provides text symbols as well as contextual information about the text source.</param>
        /// <param name="element">When this method returns, contains the next available element, or a <c>null</c> reference, depending on whether the return value indicates success.</param>
        /// <exception cref="T:System.InvalidOperationException">The given scanner object is not initialized.</exception>
        /// <exception cref="T:System.ObjectDisposedException">The given text scanner is closed.</exception>
        /// <returns><c>true</c> to indicate success; otherwise, <c>false</c>.</returns>
        protected virtual bool TryRead5(ITextScanner scanner, out T5 element)
        {
            return this.Services.GetInstance<ILexer<T5>>().TryRead(scanner, out element);
        }
    }
}