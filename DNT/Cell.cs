
namespace DNT
{
    public class Cell
    {
        public Column Column { get; set; }
        public Row Row { get; set; }
        public object Value { get; set; }

        public Cell(Column column, Row row, object value)
        {
            this.Column = column;
            this.Row = row;
            this.Value = value;
        }
    }
}
