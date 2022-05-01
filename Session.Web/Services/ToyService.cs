using Session.Data.Models;
using Session.Data.Repositories;
using Session.Web.Models;
using System;
using System.Linq;

namespace Session.Web.Services
{
    public interface IToyService
    {
        public PagedResult<Toy> GetPagedResult(int currentPage);
        public Toy FindByPrimaryKey(string id);
    }
    public class ToyService: IToyService
    {
        private IToyRepository _toyRepository;
        public ToyService(IToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }

        public PagedResult<Toy> GetPagedResult(int currentPage)
        {
            return GetPaged<Toy>(_toyRepository.Context.Toys, currentPage, 3);
        }
        public PagedResult<T> GetPaged<T>(IQueryable<T> query,
                                         int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = page == 0 ? 0 : (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
        public Toy FindByPrimaryKey(string id)
        {
            return _toyRepository.FindByPrimaryKey(id);
        }
    }
}
