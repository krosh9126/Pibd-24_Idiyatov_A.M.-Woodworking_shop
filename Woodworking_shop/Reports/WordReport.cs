using Microsoft.Extensions.Logging;
using Woodworking_shop.Reports.Builders;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Reports;

internal class WordReport
{
    private readonly IProductRepository _productRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly ILogger<WordReport> _logger;

    public WordReport(
        IProductRepository productRepository,
        IMaterialRepository materialRepository,
        ILogger<WordReport> logger)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _materialRepository = materialRepository ?? throw new ArgumentNullException(nameof(materialRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public bool CreateDoc(
        string filePath,
        bool includeProducts,
        bool includeMaterials)
    {
        try
        {
            if (!includeProducts && !includeMaterials)
            {
                _logger.LogWarning("Не выбраны справочники для Word-отчета.");
                return false;
            }

            _logger.LogInformation(
                "Формирование Word-отчета. Изделия: {Products}, Материалы: {Materials}",
                includeProducts,
                includeMaterials);

            var builder = new WordBuilder(filePath)
                .AddHeader("Справочники столярной мастерской");

            if (includeProducts)
            {
                builder
                    .AddParagraph("Изделия")
                    .AddTable(
                        [2200, 1800, 1800, 1600, 1800],
                        GetProducts());
            }

            if (includeMaterials)
            {
                builder
                    .AddParagraph("Материалы")
                    .AddTable(
                        [2200, 1800, 1800, 1600, 1600, 1600],
                        GetMaterials());
            }

            builder.Build();

            _logger.LogInformation("Word-отчет успешно сформирован: {FilePath}", filePath);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при формировании Word-отчета");
            return false;
        }
    }

    private List<string[]> GetProducts()
    {
        return
        [
            ["ID", "Название", "Категория", "Цена", "Остаток"],
            .. _productRepository.ReadProducts()
                .Select(x => new[]
                {
                    x.Id.ToString(),
                    x.Name,
                    x.Category.ToString(),
                    x.Price.ToString("0.00"),
                    x.StorageQty.ToString()
                })
        ];
    }

    private List<string[]> GetMaterials()
    {
        return
        [
            ["ID", "Название", "Тип", "Ед.", "Цена", "Остаток"],
            .. _materialRepository.ReadMaterials()
                .Select(x => new[]
                {
                    x.Id.ToString(),
                    x.Name,
                    x.Type.ToString(),
                    x.Unit,
                    x.UnitPrice.ToString("0.00"),
                    x.StorageQty.ToString("0.##")
                })
        ];
    }
}
