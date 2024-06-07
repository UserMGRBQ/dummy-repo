using Dummy.Core.Enums;
using Dummy.Core.Interfaces.Results.Inputs;
using Dummy.Core.Interfaces.Results;
using System.ComponentModel;
using System.Text;
using System.Collections;
using System.Linq.Dynamic.Core;

namespace Dummy.Core.Results;

public class PaginatedResult : OperationResult<IList>, IPaginatedResult
{
    public int? TotalCount { get; set; }
    public int? Pages { get; set; }
    public int Count { get; set; }
    public int Page { get; set; }

    protected PaginatedResult(EnumResultType resultType) : base(resultType) { }

    protected PaginatedResult(IOperationResultBase otherResult) : base(otherResult) { }

    protected PaginatedResult(EnumResultType resultType, Exception exception) : base(resultType, exception) { }

    public new static IPaginatedResult Create(IOperationResultBase otherResult)
        => new PaginatedResult(otherResult);

    public new static IPaginatedResult Create(EnumResultType resultType)
        => new PaginatedResult(resultType);

    public static IPaginatedResult CreateSuccess<TSource, TResult>(IPagination pagination, IQueryable<TSource> source, Func<TSource, TResult> selectFunction)
    {
        var result = new PaginatedResult(EnumResultType.Ok);
        result.Paginate(pagination, source, selectFunction);

        return result;
    }

    public static IPaginatedResult CreateSuccess<TSource>(IPagination pagination, IQueryable<TSource> source)
    {
        var result = new PaginatedResult(EnumResultType.Ok);
        result.Paginate<TSource, TSource>(pagination, source, null);

        return result;
    }

    public new static IPaginatedResult CreateInvalidInput()
        => new PaginatedResult(EnumResultType.InvalidInput);

    public new static IPaginatedResult CreateServiceUnavailable()
        => new PaginatedResult(EnumResultType.ServiceUnavailable);

    public new static IPaginatedResult CreateNotFound()
        => new PaginatedResult(EnumResultType.NotFound);

    public new static IPaginatedResult CreateInternalServerError()
        => new PaginatedResult(EnumResultType.InternalServerError);

    public new static IPaginatedResult CreateInternalServerError(Exception exception)
        => new PaginatedResult(EnumResultType.InternalServerError) { Exception = exception };

    public void Paginate<TSource, TResult>(IPagination pagination, IQueryable<TSource> source, Func<TSource, TResult> selectFunction)
    {
        Page = pagination.Page == 0 ? 1 : pagination.Page;

        var orderedSource = Order(source, pagination);
        var paginatedSource = orderedSource.Skip(Page * pagination.ItemsPerPage - pagination.ItemsPerPage).Take(pagination.ItemsPerPage);

        if (pagination.CountTotal && Page == 1)
        {
            TotalCount = source.Count();

            double pages = TotalCount.Value / (double)pagination.ItemsPerPage;

            Pages = (int)(pages % 1 == 0 ? pages : pages + 1);
        }

        if (selectFunction != null)
            Data = paginatedSource.Select(selectFunction).ToList();
        else
            Data = paginatedSource.ToList();

        Count = Data.Count;
    }

    private static IQueryable<TSource> Order<TSource>(IQueryable<TSource> source, IOrderable ordenator)
    {
        if (ordenator.Ordenations is null || !ordenator.Ordenations.Any())
            return source;

        var query = new StringBuilder();

        foreach (var ordenation in ordenator.Ordenations)
        {
            query.Append(ordenation.PropertyName);
            query.Append(ordenation.Direction == ListSortDirection.Descending ? "desc" : "asc");
            query.Append(',');
        }

        query = query.Remove(query.Length - 1, 1);
        return source.OrderBy(query.ToString());
    }

    public new IPaginatedResult AddMessage(string message) { _AddMessage(message); return this; }

    public new IPaginatedResult AddMessages(IEnumerable<string> messages) { _AddMessages(messages); return this; }
}