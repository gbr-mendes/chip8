using chip8.Entities;

var memory = new Memory();

var display = new Display(32, 64);

var sprite1 = new byte[]
{
    0X38,
    0X7C,
    0XFE,
    0XFE,
    0X7C,
    0X38,
    0X10,
    0X00
};

Console.Clear();
Console.WriteLine("\x1b[3J");
Console.SetCursorPosition(0,0);

display.WriteSprite(0,0, sprite1);
display.Test();

await Task.Delay(5000);

Console.Clear();
Console.WriteLine("\x1b[3J");
Console.SetCursorPosition(0,0);
display.Test();
