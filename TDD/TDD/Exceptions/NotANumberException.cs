using System;
using System.Collections.Generic;
using System.Text;

namespace TDD.Exceptions
{
    class NotANumberException: Exception
    {
        public NotANumberException()
        {
        }

        public NotANumberException(string message)
            : base(message)
        {
        }

        public NotANumberException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
