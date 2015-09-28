using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using API.Repositories;
using AutoMapper;

namespace API.Services.Search
{
	public interface ISearchService<T, T2> where T : class where T2 : class 
	{
		List<T2> Search(Expression<Func<T, bool>> filter, bool paginate = false);
		List<T2> GetAll();
	}

	public class SearchService<T, T2> : ISearchService<T, T2> where T : class  where T2 : class
	{
		private readonly IRepository<T> _repository;

		public SearchService(IRepository<T> repository)
		{
			_repository = repository;
		}

		public virtual List<T2> Search(Expression<Func<T, bool>> filter, bool paginate = false)
		{
			var entities = _repository.GetAllWhere(filter).ToList();
			return Mapper.Map<List<T>, List<T2>>(entities);
		}			

		public virtual List<T2> GetAll()
		{
			return Mapper.Map<List<T>, List<T2>>(_repository.GetAll().ToList());
		}

		public virtual List<T> Paginate(List<T> entities)
		{
			throw new NotImplementedException("Paginate Method Not Yet Implemented.");
		}
	}
}
