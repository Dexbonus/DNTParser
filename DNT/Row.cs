using System.Collections.Generic;

namespace DNT
{
    public class Row
    {
        public List<Cell> Cells { get; set; }
        public int ID { get; set; }

        public Row(int id)
        {
            this.ID = id;
            this.Cells = new List<Cell>();
        }
    }
}
