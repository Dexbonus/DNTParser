using DNT.Types;
using System.IO;
using System.Text;

namespace DNT
{
    public class DNTParser
    {
        public Table Parse(string dntPath)
        {
            var table = new Table();
            table.Columns.Add(new Column("id", ColumnType.Int));

            using (var fs = new FileStream(dntPath, FileMode.Open))
            {
                fs.Position = 4L;                

                using (var reader = new BinaryReader(fs))
                {
                    int columnCount = reader.ReadUInt16();
                    uint rowCount = reader.ReadUInt32();

                    for (int i = 0; i < columnCount; i++)
                    {
                        uint length = reader.ReadUInt16();
                        var name = new string(reader.ReadChars((int)length));
                        byte type = reader.ReadByte();

                        table.Columns.Add(new Column(name, (int)type));
                    }

                    for (int i = 0; (ulong)i < (ulong)rowCount; i++)
                    {
                        var r = new Row(i + 1);
                        uint num4 = reader.ReadUInt32();
                        object value = null;

                        for (int j = 1; j <= columnCount; j++)
                        {
                            switch (table.Columns[j].Type)
                            {
                                case ColumnType.Text:
                                    int length = reader.ReadInt16();
                                    value = length > 0 ? Encoding.ASCII.GetString(reader.ReadBytes(length)) : "";
                                    break;
                                case ColumnType.Boolean:
                                    value = reader.ReadInt32();
                                    break;
                                case ColumnType.Int:
                                    value = reader.ReadInt32();
                                    break;
                                case ColumnType.Float:
                                    value = reader.ReadSingle();
                                    break;
                                case ColumnType.Double:
                                    value = reader.ReadSingle();
                                    break;
                            }

                            r.Cells.Add(new Cell(table.Columns[j], r, value));
                        }

                        table.Rows.Add(r);
                    }
                }
            }

            return table;
        }        
    }
}
