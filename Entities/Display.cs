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

    public void WriteSprite(int xPoint, int yPoint, byte[] sprite, ref byte vF)
    {
        if(sprite.Length > 15)
        {
            throw new Exception("Sprite length exceded");
        }
        var line = yPoint;
        vF = 0;

        foreach(var b in sprite)
        {
            var column = xPoint;
            for(var i = 7; i>=0; i--)
            {
                var mask = (byte) (1 << i);
                var bitOn = (mask & b) != 0;
                 
                if (Matrix[line, column] == 1 && bitOn)
                {
                    Matrix[line, column] = 0;
                    vF = 1;
                }else if(bitOn) {
                    Matrix[line, column] = 1;
                }
                
                if(column == Columns - 1)
                {
                    break;
                }
                column++;
            }
            if (line == Lines - 1)
            {
                break;
            }
            line++;
        }
        Show();
    }

    public void Show()
    {
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

    public void Clear()
    {
        // Console.Clear();
        // Console.WriteLine("\x1b[3J");
        // Console.SetCursorPosition(0,0);
        for(var i = 0; i < Lines; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                if (Matrix[i,j] == 1)
                {
                    Matrix[i,j] = 0;
                }
            }
            Console.WriteLine();
        }
    }
}
