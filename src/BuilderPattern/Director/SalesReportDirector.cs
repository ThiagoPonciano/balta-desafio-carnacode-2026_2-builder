using BuilderPattern.IBuilder;
using BuilderPattern.Product_Model;

namespace BuilderPattern.Director
{
    public class SalesReportDirector
    {
        private readonly ISalesReportBuilder builder;

        public SalesReportDirector(ISalesReportBuilder builder)
        {
            this.builder = builder;
        }

        public SalesReport CreateMonthlyPdfReport()
        {
            return builder.Reset()
                .SetBasicInfo("Vendas Mensais", "PDF")
                .SetPeriod(new DateTime(2024, 1, 1), new DateTime(2024, 1, 31))
                .WithHeader("Relatório de Vendas")
                .WithFooter("Confidencial")
                .WithCharts("Bar")
                .WithSummary()
                .AddColumns(new List<string> { "Produto", "Quantidade", "Valor" })
                .AddFilter("Status=Ativo")
                .SortBy("Valor")
                .GroupBy("Categoria")
                .WithTotals()
                .SetLayout("Portrait", "A4")
                .WithPageNumbers()
                .WithCompanyLogo("logo.png")
                .WithWaterMark("Confidencial")
                .Build();
        }

        public SalesReport CreateQuarterlyExcelReport()
        {
            return builder.Reset()
                .SetBasicInfo("Relatório Trimestral", "Excel")
                .SetPeriod(new DateTime(2024, 1, 1), new DateTime(2024, 3, 31))
                .WithHeader("Trimestral - BI")
                .AddColumns(new List<string> { "Vendedor", "Região", "Total" })
                .WithCharts("Line")
                .GroupBy("Região")
                .WithTotals()
                .Build();
        }

        public SalesReport CreateAnnualPdfReport()
        {
            return builder.Reset()
                .SetBasicInfo("Vendas Anuais", "PDF")
                .SetPeriod(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31))
                .WithHeader("Relatório de Vendas")
                .WithFooter("Confidencial")
                .AddColumns(new List<string> { "Produto", "Quantidade", "Valor" })
                .WithCharts("Pie")
                .WithTotals()
                .SetLayout("Landscape", "A4")
                .Build();
        }
    }
}
