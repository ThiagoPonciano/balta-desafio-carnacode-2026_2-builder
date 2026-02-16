using BuilderPattern.IBuilder;
using BuilderPattern.Product_Model;

namespace BuilderPattern.ConcreteBuilder
{
    public class SalesReportBuilder : ISalesReportBuilder
    {
        private SalesReport report;

        private bool basicInfoWasSet;
        private bool periodWasSet;

        public SalesReportBuilder()
        {
            Reset();
        }

        public ISalesReportBuilder Reset()
        {
            report = new SalesReport();
            basicInfoWasSet = false;
            periodWasSet = false;
            return this;
        }

        public ISalesReportBuilder SetBasicInfo(string title, string format)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title é obrigatório.");

            if (string.IsNullOrWhiteSpace(format))
                throw new ArgumentException("Format é obrigatório.");

            report.SetBasicInfo(title, format);
            basicInfoWasSet = true;
            return this;
        }

        public ISalesReportBuilder SetPeriod(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new ArgumentException("StartDate não pode ser maior que EndDate.");

            report.SetPeriod(startDate, endDate);
            periodWasSet = true;
            return this;
        }

        public ISalesReportBuilder WithHeader(string headerText)
        {
            if (string.IsNullOrWhiteSpace(headerText))
                throw new ArgumentException("HeaderText é obrigatório quando IncludeHeader = true.");

            report.EnableHeader(headerText);
            return this;
        }

        public ISalesReportBuilder WithFooter(string footerText)
        {
            if (string.IsNullOrWhiteSpace(footerText))
                throw new ArgumentException("FooterText é obrigatório quando IncludeFooter = true.");

            report.EnableFooter(footerText);
            return this;
        }

        public ISalesReportBuilder WithCharts(string chartType)
        {
            if (string.IsNullOrWhiteSpace(chartType))
                throw new ArgumentException("ChartType é obrigatório quando IncludeCharts = true.");

            report.EnableCharts(chartType);
            return this;
        }

        public ISalesReportBuilder WithSummary()
        {
            report.EnableSummary();
            return this;
        }

        public ISalesReportBuilder AddColumn(string column)
        {
            report.AddColumn(column);
            return this;
        }

        public ISalesReportBuilder AddColumns(IEnumerable<string> columns)
        {
            report.AddColumns(columns);
            return this;
        }

        public ISalesReportBuilder AddFilter(string filter)
        {
            report.AddFilter(filter);
            return this;
        }

        public ISalesReportBuilder AddFilters(IEnumerable<string> filters)
        {
            report.AddFilters(filters);
            return this;
        }

        public ISalesReportBuilder SortBy(string sortBy)
        {
            report.SetSortBy(sortBy);
            return this;
        }

        public ISalesReportBuilder GroupBy(string groupBy)
        {
            report.SetGroupBy(groupBy);
            return this;
        }

        public ISalesReportBuilder WithTotals()
        {
            report.EnableTotals();
            return this;
        }

        public ISalesReportBuilder WithoutTotals()
        {
            report.DisableTotals();
            return this;
        }

        public ISalesReportBuilder SetLayout(string orientation, string pageSize)
        {
            report.SetLayout(orientation, pageSize);
            return this;
        }

        public ISalesReportBuilder WithPageNumbers()
        {
            report.EnablePageNumbers();
            return this;
        }

        public ISalesReportBuilder WithoutPageNumbers()
        {
            report.DisablePageNumbers();
            return this;
        }

        public ISalesReportBuilder WithCompanyLogo(string companyLogo)
        {
            report.SetCompanyLogo(companyLogo);
            return this;
        }

        public ISalesReportBuilder WithWaterMark(string waterMark)
        {
            report.SetWaterMark(waterMark);
            return this;
        }

        public SalesReport Build()
        {
            //EXTRA - Usando o Builder para validar o estado do objeto antes de construí-lo, garantindo que as regras de negócio sejam respeitadas.
            if (!basicInfoWasSet)
                throw new InvalidOperationException("SetBasicInfo(title, format) é obrigatório antes do Build().");

            if (!periodWasSet)
                throw new InvalidOperationException("SetPeriod(startDate, endDate) é obrigatório antes do Build().");

            if (report.IncludeHeader && string.IsNullOrWhiteSpace(report.HeaderText))
                throw new InvalidOperationException("IncludeHeader = true exige HeaderText.");

            if (report.IncludeFooter && string.IsNullOrWhiteSpace(report.FooterText))
                throw new InvalidOperationException("IncludeFooter = true exige FooterText.");

            if (report.IncludeCharts && string.IsNullOrWhiteSpace(report.ChartType))
                throw new InvalidOperationException("IncludeCharts = true exige ChartType.");

            var builtReport = report;

            Reset();

            return builtReport;
        }
    }
}
