using Microsoft.Extensions.Logging;
using Woodworking_shop.Reports.Builders;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Reports;

internal class ExcelReport
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IConsumptionRateRepository _consumptionRateRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly ILogger<ExcelReport> _logger;

    public ExcelReport(
        IProductRepository productRepository,
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IConsumptionRateRepository consumptionRateRepository,
        IMaterialRepository materialRepository,
        ILogger<ExcelReport> logger)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
        _consumptionRateRepository = consumptionRateRepository ?? throw new ArgumentNullException(nameof(consumptionRateRepository));
        _materialRepository = materialRepository ?? throw new ArgumentNullException(nameof(materialRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public bool CreateTable(
        string filePath,
        int productId,
        DateTime startDate,
        DateTime endDate)
    {
        try
        {
            if (endDate < startDate)
                throw new ArgumentException("Дата окончания должна быть не раньше даты начала.");

            var product = _productRepository.ReadProductById(productId);

            if (product == null)
                throw new InvalidOperationException("Изделие не найдено.");

            _logger.LogInformation(
                "Формирование Excel-отчета. Изделие: {ProductId}, период: {StartDate} - {EndDate}",
                productId,
                startDate,
                endDate);

            new ExcelBuilder(filePath)
                .AddHeader($"Сводка по изделию: {product.Name}", 0, 5)
                .AddParagraph(
                    $"Период: {startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}",
                    0)
                .AddTable(
                    [28, 16, 18, 18, 22],
                    GetData(productId, startDate, endDate))
                .Build();

            _logger.LogInformation("Excel-отчет успешно сформирован: {FilePath}", filePath);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при формировании Excel-отчета");
            return false;
        }
    }

    private List<string[]> GetData(
        int productId,
        DateTime startDate,
        DateTime endDate)
    {
        var orders = _orderRepository
            .ReadOrders(startDate)
            .Where(x => x.DateStart.Date <= endDate.Date)
            .ToList();

        var orderedQuantity = orders
            .SelectMany(order =>
                _orderItemRepository.ReadOrderItems(order.Id)
                    .Where(item => item.ProductId == productId)
                    .Select(item => new
                    {
                        OrderId = order.Id,
                        Quantity = item.Quantity
                    }))
            .Sum(x => x.Quantity);

        var materials = _materialRepository
            .ReadMaterials()
            .ToDictionary(x => x.Id);

        var rates = _consumptionRateRepository
            .ReadConsumptionRates(productId);

        var rows = rates
            .Where(x => materials.ContainsKey(x.MaterialId))
            .Select(x =>
            {
                var material = materials[x.MaterialId];
                var required = x.QtyPerProduct * orderedQuantity;

                return new[]
                {
                    material.Name,
                    material.Unit,
                    x.QtyPerProduct.ToString("0.##"),
                    orderedQuantity.ToString(),
                    required.ToString("0.##")
                };
            })
            .ToList();

        if (rows.Count == 0)
        {
            rows.Add([
                "Нет данных",
                "",
                "0",
                orderedQuantity.ToString(),
                "0"
            ]);
        }

        var totalRequired = rates
            .Sum(x => x.QtyPerProduct * orderedQuantity);

        rows.Add([
            "Итого",
            "",
            "",
            orderedQuantity.ToString(),
            totalRequired.ToString("0.##")
        ]);

        return
        [
            ["Материал", "Ед.", "Норма на изделие", "Заказано изделий", "Требуется материала"],
            .. rows
        ];
    }
}
