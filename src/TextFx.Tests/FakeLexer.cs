﻿namespace TextFx.Tests
{
    using System;

    public class FakeLexer<T> : ILexer<T>
        where T : Element
    {
        public delegate bool FakeTryRead(ITextScanner scanner, out T element);

        public delegate bool FakeTryReadElement(ITextScanner scanner, out Element element);

        public Func<ITextScanner, T> OnRead { get; set; }

        public Func<ITextScanner, Element> OnReadElement { get; set; }

        public FakeTryRead OnTryRead { get; set; }

        public FakeTryReadElement OnTryReadElement { get; set; }

        public ReadResult<T> Read(ITextScanner scanner, Element previousElementOrNull)
        {
            throw new NotImplementedException();
        }

        ReadResult<Element> ILexer.ReadElement(ITextScanner scanner, Element previousElementOrNull)
        {
            throw new NotImplementedException();
        }
    }
}