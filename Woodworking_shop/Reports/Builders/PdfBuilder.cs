using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;

namespace Woodworking_shop.Reports.Builders;

internal class PdfBuilder
{
    private readonly string _filePath;
    private readonly Document _document;

    public PdfBuilder(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentNullException(nameof(filePath));

        if (File.Exists(filePath))
            File.Delete(filePath);

        _filePath = filePath;
        _document = new Document();

        DefineStyles();
    }

    public PdfBuilder AddHeader(string header)
    {
        var section = _document.AddSection();
        var paragraph = section.AddParagraph(header, "Header");
        paragraph.Format.SpaceAfter = Unit.FromCentimeter(0.5);

        return this;
    }

    public PdfBuilder AddParagraph(string text)
    {
        var section = _document.LastSection ?? _document.AddSection();
        section.AddParagraph(text);
        return this;
    }

    public PdfBuilder AddPieChart(
        string title,
        List<(string Caption, double Value)> data)
    {
        if (data == null || data.Count == 0)
            return this;

        var section = _document.LastSection ?? _document.AddSection();

        var chart = section.AddChart(ChartType.Pie2D);
        chart.Width = Unit.FromCentimeter(16);
        chart.Height = Unit.FromCentimeter(12);

        var series = chart.SeriesCollection.AddSeries();
        series.Add(data.Select(x => x.Value).ToArray());
        series.HasDataLabel = true;
        series.DataLabel.Type = DataLabelType.Percent;
        series.DataLabel.Position = DataLabelPosition.OutsideEnd;

        var xSeries = chart.XValues.AddXSeries();
        xSeries.Add(data.Select(x => x.Caption).ToArray());

        chart.TopArea.AddParagraph(title);
        chart.TopArea.AddLegend();

        return this;
    }

    public void Build()
    {
        var renderer = new PdfDocumentRenderer(true)
        {
            Document = _document
        };

        renderer.RenderDocument();
        renderer.PdfDocument.Save(_filePath);
    }

    private void DefineStyles()
    {
        var style = _document.Styles["Header"];
        style.Font.Bold = true;
        style.Font.Size = 16;
        style.ParagraphFormat.Alignment = ParagraphAlignment.Center;
    }
}
