using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Woodworking_shop.Reports.Builders;

internal class WordBuilder
{
    private readonly string _filePath;
    private readonly Document _document;
    private readonly Body _body;

    public WordBuilder(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentNullException(nameof(filePath));

        if (File.Exists(filePath))
            File.Delete(filePath);

        _filePath = filePath;
        _document = new Document();
        _body = _document.AppendChild(new Body());
    }

    public WordBuilder AddHeader(string header)
    {
        var paragraph = _body.AppendChild(new Paragraph());
        var run = paragraph.AppendChild(new Run(new RunProperties(new Bold())));
        run.AppendChild(new Text(header));
        return this;
    }

    public WordBuilder AddParagraph(string text)
    {
        var paragraph = _body.AppendChild(new Paragraph());
        var run = paragraph.AppendChild(new Run());
        run.AppendChild(new Text(text));
        return this;
    }


    public WordBuilder AddTable(int[] widths, List<string[]> data)
    {
        if (widths == null || widths.Length == 0)
            throw new ArgumentNullException(nameof(widths));

        if (data == null || data.Count == 0)
            throw new ArgumentNullException(nameof(data));

        if (data.Any(x => x == null || x.Length != widths.Length))
            throw new InvalidOperationException(
                "Количество ширин колонок не соответствует данным.");

        if (widths.Any(x => x <= 0))
            throw new ArgumentException("Ширина колонок должна быть положительной.");

        var table = new Table();

        table.AppendChild(new TableProperties(
            new TableBorders(
                new TopBorder { Val = BorderValues.Single, Size = 12 },
                new BottomBorder { Val = BorderValues.Single, Size = 12 },
                new LeftBorder { Val = BorderValues.Single, Size = 12 },
                new RightBorder { Val = BorderValues.Single, Size = 12 },
                new InsideHorizontalBorder { Val = BorderValues.Single, Size = 12 },
                new InsideVerticalBorder { Val = BorderValues.Single, Size = 12 }
            )
        ));

        foreach (var row in data)
        {
            var tableRow = new TableRow();

            for (int j = 0; j < widths.Length; j++)
            {
                var run = new Run(new Text(row[j] ?? ""));

                if (ReferenceEquals(row, data.First()))
                    run.RunProperties = new RunProperties(new Bold());

                var cell = new TableCell(
                    new TableCellProperties(
                        new TableCellWidth
                        {
                            Type = TableWidthUnitValues.Dxa,
                            Width = widths[j].ToString()
                        }),
                    new Paragraph(run)
                );

                tableRow.Append(cell);
            }

            table.Append(tableRow);
        }

        _body.Append(table);
        return this;
    }


    public void Build()
    {
        using var wordDocument = WordprocessingDocument.Create(
            _filePath,
            WordprocessingDocumentType.Document);

        var mainPart = wordDocument.AddMainDocumentPart();
        mainPart.Document = _document;
    }
}
