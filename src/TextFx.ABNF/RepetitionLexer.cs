﻿namespace TextFx.ABNF
{
    using System;
    using System.Collections.Generic;

    /// <summary>Provides the base class for lexers whose lexer rule is a repetition of elements.</summary>
    public class RepetitionLexer : Lexer<Repetition>
    {
        private readonly int lowerBound;

        private readonly ILexer repeatingElementLexer;

        private readonly int upperBound;

        /// <summary>Initializes a new instance of the <see cref="RepetitionLexer" /> class with a specified lower and upper bound, both inclusive.</summary>
        /// <param name="repeatingElementLexer">The lexer for the repeating element.</param>
        /// <param name="lowerBound">A number that indicates the minimum number of occurrences (inclusive).</param>
        /// <param name="upperBound">A number that indicates the maximum number of occurrences (inclusive).</param>
        public RepetitionLexer(ILexer repeatingElementLexer, int lowerBound, int upperBound)
        {
            if (repeatingElementLexer == null)
            {
                throw new ArgumentNullException(nameof(repeatingElementLexer));
            }

            if (lowerBound < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound), "Precondition: lowerBound >= 0");
            }

            if (upperBound <= lowerBound)
            {
                throw new ArgumentOutOfRangeException(nameof(upperBound), "Precondition: upperBound > lowerBound");
            }

            this.repeatingElementLexer = repeatingElementLexer;
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
        }

        public override ReadResult<Repetition> Read(ITextScanner scanner, Element previousElementOrNull)
        {
            if (scanner == null)
            {
                throw new ArgumentNullException(nameof(scanner));
            }

            var context = scanner.GetContext();
            IList<Element> elements = new List<Element>(this.lowerBound);
            ReadResult<Element> lastResult = null;

            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < this.upperBound; i++)
            {
                lastResult = this.repeatingElementLexer.ReadElement(scanner, lastResult?.Element);
                if (!lastResult.Success)
                {
                    break;
                }

                elements.Add(lastResult.Element);
            }

            if (elements.Count >= this.lowerBound)
            {
                return ReadResult<Repetition>.FromResult(new Repetition(elements, context));
            }

            if (elements.Count != 0)
            {
                for (var i = elements.Count - 1; i >= 0; i--)
                {
                    scanner.Unread(elements[i].Text);
                }
            }

            return ReadResult<Repetition>.FromError(new SyntaxError
            {
                Message = "A syntax error was found.",
                InnerError = lastResult?.Error,
                Context = context
            });
        }
    }
}