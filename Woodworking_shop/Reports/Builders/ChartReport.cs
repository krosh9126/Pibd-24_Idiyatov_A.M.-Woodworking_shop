using Microsoft.Extensions.Logging;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Reports.Builders;

internal class ChartReport
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ChartReport> _logger;

    public ChartReport(
        IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IProductRepository productRepository,
        ILogger<ChartReport> logger)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public bool CreateChart(string filePath, DateTime date)
    {
        try
        {
            _logger.LogInformation(
                "Формирование PDF-отчета за дату {Date}",
                date.Date);

            new PdfBuilder(filePath)
                .AddHeader("Распределение заказанных изделий")
                .AddParagraph($"Дата: {date:dd.MM.yyyy}")
                .AddPieChart("Количество заказанных изделий", GetData(date))
                .Build();

            _logger.LogInformation("PDF-отчет успешно сформирован: {FilePath}", filePath);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при формировании PDF-отчета");
            return false;
        }
    }

    private List<(string Caption, double Value)> GetData(DateTime date)
    {
        var products = _productRepository
            .ReadProducts()
            .ToDictionary(x => x.Id, x => x.Name);

        return _orderRepository
            .ReadOrders(date)
            .Where(x => x.DateStart.Date == date.Date)
            .SelectMany(order => _orderItemRepository.ReadOrderItems(order.Id))
            .Where(item => products.ContainsKey(item.ProductId))
            .GroupBy(item => item.ProductId)
            .Select(group => (
                products[group.Key],
                (double)group.Sum(x => x.Quantity)))
            .OrderByDescending(x => x.Item2)
            .ToList();
    }
}
