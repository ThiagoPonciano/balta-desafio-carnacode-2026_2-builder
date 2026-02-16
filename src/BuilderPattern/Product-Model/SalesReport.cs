namespace BuilderPattern.Product_Model
{
    public class SalesReport
    {
        public string Title { get; private set; }
        public string Format { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IncludeHeader { get; private set; }
        public bool IncludeFooter { get; private set; }
        public string HeaderText { get; private set; }
        public string FooterText { get; private set; }
        public bool IncludeCharts { get; private set; }
        public string ChartType { get; private set; }
        public bool IncludeSummary { get; private set; }
        public IReadOnlyList<string> Columns => _columns;
        public IReadOnlyList<string> Filters => _filters;
        public string SortBy { get; private set; }
        public string GroupBy { get; private set; }
        public bool IncludeTotals { get; private set; }
        public string Orientation { get; private set; }
        public string PageSize { get; private set; }
        public bool IncludePageNumbers { get; private set; }
        public string CompanyLogo { get; private set; }
        public string WaterMark { get; private set; }
        private readonly List<string> _columns = new();
        private readonly List<string> _filters = new();

        internal SalesReport() { }

        internal void SetBasicInfo(string title, string format)
        {
            Title = title;
            Format = format;
        }

        internal void SetPeriod(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        internal void EnableHeader(string headerText)
        {
            IncludeHeader = true;
            HeaderText = headerText;
        }

        internal void DisableHeader()
        {
            IncludeHeader = false;
            HeaderText = null;
        }

        internal void EnableFooter(string footerText)
        {
            IncludeFooter = true;
            FooterText = footerText;
        }

        internal void DisableFooter()
        {
            IncludeFooter = false;
            FooterText = null;
        }

        internal void EnableCharts(string chartType)
        {
            IncludeCharts = true;
            ChartType = chartType;
        }

        internal void DisableCharts()
        {
            IncludeCharts = false;
            ChartType = null;
        }

        internal void EnableSummary() => IncludeSummary = true;
        internal void DisableSummary() => IncludeSummary = false;

        internal void AddColumn(string column)
        {
            if (!string.IsNullOrWhiteSpace(column))
                _columns.Add(column);
        }

        internal void AddColumns(IEnumerable<string> columns)
        {
            if (columns == null) return;
            foreach (var column in columns)
                AddColumn(column);
        }

        internal void AddFilter(string filter)
        {
            if (!string.IsNullOrWhiteSpace(filter))
                _filters.Add(filter);
        }

        internal void AddFilters(IEnumerable<string> filters)
        {
            if (filters == null) return;
            foreach (var filter in filters)
                AddFilter(filter);
        }

        internal void SetSortBy(string sortBy) => SortBy = sortBy;
        internal void SetGroupBy(string groupBy) => GroupBy = groupBy;
        internal void EnableTotals() => IncludeTotals = true;
        internal void DisableTotals() => IncludeTotals = false;

        internal void SetLayout(string orientation, string pageSize)
        {
            Orientation = orientation;
            PageSize = pageSize;
        }

        internal void EnablePageNumbers() => IncludePageNumbers = true;
        internal void DisablePageNumbers() => IncludePageNumbers = false;

        internal void SetCompanyLogo(string companyLogo) => CompanyLogo = companyLogo;
        internal void SetWaterMark(string waterMark) => WaterMark = waterMark;

        public void Generate()
        {
            Console.WriteLine($"\n=== Gerando Relatório: {Title} ===");
            Console.WriteLine($"Formato: {Format}");
            Console.WriteLine($"Período: {StartDate:dd/MM/yyyy} a {EndDate:dd/MM/yyyy}");

            if (IncludeHeader)
                Console.WriteLine($"Cabeçalho: {HeaderText}");

            if (IncludeCharts)
                Console.WriteLine($"Gráfico: {ChartType}");

            Console.WriteLine($"Colunas: {string.Join(", ", Columns)}");

            if (Filters.Any())
                Console.WriteLine($"Filtros: {string.Join(", ", Filters)}");

            if (!string.IsNullOrWhiteSpace(GroupBy))
                Console.WriteLine($"Agrupado por: {GroupBy}");

            if (IncludeFooter)
                Console.WriteLine($"Rodapé: {FooterText}");

            Console.WriteLine("Relatório gerado com sucesso!");
        }
    }
}
