namespace MyCoin_Desktop.Entities
{
    public struct Position
    {
        public int line;
        public int column;

        public Position(int line, int column)
        {
            this.line = line;
            this.column = column;
        }
    }
}
