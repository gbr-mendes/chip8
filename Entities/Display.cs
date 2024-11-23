namespace chip8.Entities;

public class Display
{
    public int Lines { get; set; }
    public int Columns { get; set; }
    public int[,] Matrix { get; }

    public Display(int lines, int columns)
    {
        Lines = lines;
        Columns = columns;
        Matrix = new int[lines, columns];
    }

    public void WriteSprite(int xPoint, int yPoint, byte[] sprite)
    {
        if(sprite.Length > 15)
        {
            throw new Exception("Sprite length exceded");
        }
        var column = xPoint;
        var line = yPoint;
        
        foreach(var b in sprite)
        {
            // 00111000
            for(var i = 7; i>=0; i--)
            {
                var mask = (byte) (1 << i);
                var bitOn = (mask & b) != 0;
                if(bitOn)
                {
                    Matrix[line, column] = Matrix[line, column] == 0 ? 1 : 0;
                }

                column++;
            }
            column = xPoint;
            line++;
        }
    }

    public void Test()
    {
        // Console.SetCursorPosition(0, 0);
        for(var i = 0; i < Lines; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                if (Matrix[i,j] == 1)
                {
                    Console.Write("■");
                }else {
                    Console.Write(" ");
                }
                
            }
            Console.WriteLine();
        }
    }
}
