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

var sprite2 = new byte[]
{
    0xF8,
    0xF8,
    0xF8,
    0xF8,
    0xF8,
    0xF8,
    0xF8,
    0xF8
};

Console.Clear();
Console.WriteLine("\x1b[3J");
Console.SetCursorPosition(0,0);

// display.WriteSprite(0,0, sprite1);
// display.Show();

// await Task.Delay(5000);
// display.WriteSprite(0,0, sprite2);
// display.Show();

var t1 = new SoundTimer
{
    Count = 255
};

while (true)
{
    if(t1.Count > 0)
    {
        Console.Beep();
        t1.Count--;   
    }
    await Task.Delay(17);
}
