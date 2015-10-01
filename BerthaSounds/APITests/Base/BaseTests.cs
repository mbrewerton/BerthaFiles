using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Repositories;
using Moq;

namespace APITests.Base
{
	public class BaseTests
	{
		protected Mock<IUnitOfWork> _uow;

		public BaseTests()
		{
			_uow = new Mock<IUnitOfWork>();
		}
	}
}
