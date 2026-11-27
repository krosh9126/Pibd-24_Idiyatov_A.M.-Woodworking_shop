using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Font = DocumentFormat.OpenXml.Spreadsheet.Font;

namespace Woodworking_shop.Reports.Builders;

internal class ExcelBuilder
{
    private readonly string _filePath;
    private readonly SheetData _sheetData;
    private readonly MergeCells _mergeCells;
    private readonly Columns _columns;
    private uint _rowIndex = 1;

    public ExcelBuilder(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentNullException(nameof(filePath));

        if (File.Exists(filePath))
            File.Delete(filePath);

        _filePath = filePath;
        _sheetData = new SheetData();
        _mergeCells = new MergeCells();
        _columns = new Columns();
    }

    public ExcelBuilder AddHeader(string header, int startIndex, int count)
    {
        CreateCell(startIndex, _rowIndex, header, StyleIndex.Bold);

        for (int i = startIndex + 1; i < startIndex + count; i++)
            CreateCell(i, _rowIndex, "", StyleIndex.Simple);

        _mergeCells.Append(new MergeCell
        {
            Reference = $"{GetExcelColumnName(startIndex)}{_rowIndex}:{GetExcelColumnName(startIndex + count - 1)}{_rowIndex}"
        });

        _rowIndex++;
        return this;
    }

    public ExcelBuilder AddParagraph(string text, int columnIndex)
    {
        CreateCell(columnIndex, _rowIndex++, text, StyleIndex.Simple);
        return this;
    }

    public ExcelBuilder AddTable(int[] columnsWidths, List<string[]> data)
    {
        if (columnsWidths == null || columnsWidths.Length == 0)
            throw new ArgumentNullException(nameof(columnsWidths));

        if (data == null || data.Count == 0)
            throw new ArgumentNullException(nameof(data));

        if (data.Any(x => x.Length != columnsWidths.Length))
            throw new InvalidOperationException("Количество колонок не соответствует данным.");

        for (int i = 0; i < columnsWidths.Length; i++)
        {
            _columns.Append(new Column
            {
                Min = (uint)(i + 1),
                Max = (uint)(i + 1),
                Width = columnsWidths[i],
                CustomWidth = true
            });
        }

        for (int j = 0; j < data.First().Length; j++)
            CreateCell(j, _rowIndex, data.First()[j], StyleIndex.Bold);

        _rowIndex++;

        foreach (var row in data.Skip(1).SkipLast(1))
        {
            for (int j = 0; j < row.Length; j++)
                CreateCell(j, _rowIndex, row[j], StyleIndex.Simple);

            _rowIndex++;
        }

        var total = data.Last();

        for (int j = 0; j < total.Length; j++)
            CreateCell(j, _rowIndex, total[j], StyleIndex.Bold);

        _rowIndex++;
        return this;
    }

    public void Build()
    {
        using var spreadsheetDocument = SpreadsheetDocument.Create(
            _filePath,
            SpreadsheetDocumentType.Workbook);

        var workbookPart = spreadsheetDocument.AddWorkbookPart();
        workbookPart.Workbook = new Workbook();

        GenerateStyle(workbookPart);

        var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        worksheetPart.Worksheet = new Worksheet();

        if (_columns.HasChildren)
            worksheetPart.Worksheet.Append(_columns);

        worksheetPart.Worksheet.Append(_sheetData);

        var sheets = workbookPart.Workbook.AppendChild(new Sheets());

        sheets.Append(new Sheet
        {
            Id = workbookPart.GetIdOfPart(worksheetPart),
            SheetId = 1,
            Name = "Лист 1"
        });

        if (_mergeCells.HasChildren)
            worksheetPart.Worksheet.InsertAfter(
                _mergeCells,
                worksheetPart.Worksheet.Elements<SheetData>().First());
    }

    private static void GenerateStyle(WorkbookPart workbookPart)
    {
        var stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
        var stylesheet = new Stylesheet();

        var fonts = new Fonts { Count = 2 };
        fonts.Append(
            new Font(
                new FontSize { Val = 11 },
                new FontName { Val = "Calibri" }),
            new Font(
                new Bold(),
                new FontSize { Val = 11 },
                new FontName { Val = "Calibri" }));

        stylesheet.Append(fonts);

        var fills = new Fills { Count = 2 };
        fills.Append(new Fill(new PatternFill { PatternType = PatternValues.None }));
        fills.Append(new Fill(new PatternFill { PatternType = PatternValues.Gray125 }));
        stylesheet.Append(fills);

        var borders = new Borders { Count = 2 };
        borders.Append(new Border());
        borders.Append(new Border(
            new LeftBorder { Style = BorderStyleValues.Thin },
            new RightBorder { Style = BorderStyleValues.Thin },
            new TopBorder { Style = BorderStyleValues.Thin },
            new BottomBorder { Style = BorderStyleValues.Thin }));
        stylesheet.Append(borders);

        var cellFormats = new CellFormats { Count = 2 };
        cellFormats.Append(new CellFormat
        {
            FontId = 0,
            FillId = 0,
            BorderId = 1,
            Alignment = new Alignment
            {
                Horizontal = HorizontalAlignmentValues.Left,
                Vertical = VerticalAlignmentValues.Center,
                WrapText = true
            }
        });
        cellFormats.Append(new CellFormat
        {
            FontId = 1,
            FillId = 0,
            BorderId = 1,
            Alignment = new Alignment
            {
                Horizontal = HorizontalAlignmentValues.Left,
                Vertical = VerticalAlignmentValues.Center,
                WrapText = true
            }
        });

        stylesheet.Append(cellFormats);
        stylesPart.Stylesheet = stylesheet;
    }

    private enum StyleIndex
    {
        Simple = 0,
        Bold = 1
    }

    private void CreateCell(int columnIndex, uint rowIndex, string text, StyleIndex styleIndex)
    {
        var columnName = GetExcelColumnName(columnIndex);
        var cellReference = $"{columnName}{rowIndex}";

        var row = _sheetData.Elements<Row>()
            .FirstOrDefault(x => x.RowIndex == rowIndex);

        if (row == null)
        {
            row = new Row { RowIndex = rowIndex };
            _sheetData.Append(row);
        }

        var cell = row.Elements<Cell>()
            .FirstOrDefault(x => x.CellReference?.Value == cellReference);

        if (cell == null)
        {
            cell = new Cell { CellReference = cellReference };
            row.Append(cell);
        }

        cell.CellValue = new CellValue(text);
        cell.DataType = CellValues.String;
        cell.StyleIndex = (uint)styleIndex;
    }

    private static string GetExcelColumnName(int columnNumber)
    {
        columnNumber++;

        var result = string.Empty;

        while (columnNumber > 0)
        {
            var modulo = (columnNumber - 1) % 26;
            result = Convert.ToChar(65 + modulo) + result;
            columnNumber = (columnNumber - modulo) / 26;
        }

        return result;
    }
}
