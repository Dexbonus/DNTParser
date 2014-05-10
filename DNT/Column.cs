
namespace DNT
{
    public class Column
    {
        public string Name { get; set; }
        public ColumnType Type { get; set; }

        public Column(string name, ColumnType type)
        {
            this.Type = type;
            this.Name = name;
        }

        public Column(string name, int type)
        {
            this.Type = (ColumnType)type;
            this.Name = name;            
        }
    }
}
