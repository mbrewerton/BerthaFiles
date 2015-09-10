using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Exceptions
{
	public class BerthaException : Exception
	{
		public BerthaException(){}
		public BerthaException(string message) : base(message) {}
		public BerthaException(string message, Exception inner) : base(message, inner) {}
	}

	public class InvalidActionException : BerthaException
	{
		public InvalidActionException(){}
		public InvalidActionException(string message) : base(message) {}
		public InvalidActionException(string message, Exception inner) : base(message, inner) { }
	}

	public class DuplicateItemException : BerthaException
	{
		public DuplicateItemException(){}
		public DuplicateItemException(string message) : base(message) {}
		public DuplicateItemException(string message, Exception inner) : base(message, inner) {}
	}
}
