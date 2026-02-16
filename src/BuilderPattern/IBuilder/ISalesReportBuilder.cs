using BuilderPattern.Product_Model;

namespace BuilderPattern.IBuilder
{
    public interface ISalesReportBuilder
    {
        ISalesReportBuilder Reset();
        ISalesReportBuilder SetBasicInfo(string title, string format);
        ISalesReportBuilder SetPeriod(DateTime startDate, DateTime endDate);
        ISalesReportBuilder WithHeader(string headerText);
        ISalesReportBuilder WithFooter(string footerText);
        ISalesReportBuilder WithCharts(string chartType);
        ISalesReportBuilder WithSummary();
        ISalesReportBuilder AddColumn(string column);
        ISalesReportBuilder AddColumns(IEnumerable<string> columns);
        ISalesReportBuilder AddFilter(string filter);
        ISalesReportBuilder AddFilters(IEnumerable<string> filters);
        ISalesReportBuilder SortBy(string sortBy);
        ISalesReportBuilder GroupBy(string groupBy);
        ISalesReportBuilder WithTotals();
        ISalesReportBuilder WithoutTotals();
        ISalesReportBuilder SetLayout(string orientation, string pageSize);
        ISalesReportBuilder WithPageNumbers();
        ISalesReportBuilder WithoutPageNumbers();
        ISalesReportBuilder WithCompanyLogo(string companyLogo);
        ISalesReportBuilder WithWaterMark(string waterMark);

        SalesReport Build();
    }
}
