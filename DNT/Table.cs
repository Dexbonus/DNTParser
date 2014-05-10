using System.Collections.Generic;

namespace DNT
{
    public class Table
    {
        public List<Column> Columns { get; set; }
        public List<Row> Rows { get; set; }        

        public Table()
        {
            this.Columns = new List<Column>();
            this.Rows = new List<Row>();
        }
    }
}
