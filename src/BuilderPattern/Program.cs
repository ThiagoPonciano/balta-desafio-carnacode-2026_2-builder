using BuilderPattern.ConcreteBuilder;
using BuilderPattern.Director;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Relatórios (Builder) ===");

        var builder = new SalesReportBuilder();

        var report1 = builder.Reset()
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

        report1.Generate();

        var report2 = builder.Reset()
            .SetBasicInfo("Relatório Trimestral", "Excel")
            .SetPeriod(new DateTime(2024, 1, 1), new DateTime(2024, 3, 31))
            .WithHeader("Trimestral - BI")
            .AddColumn("Vendedor")
            .AddColumn("Região")
            .AddColumn("Total")
            .WithCharts("Line")
            .GroupBy("Região")
            .WithTotals()
            .Build();

        report2.Generate();

        var director = new SalesReportDirector(builder);

        var report3 = director.CreateAnnualPdfReport();
        report3.Generate();
    }
}