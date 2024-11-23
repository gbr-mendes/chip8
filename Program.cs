using chip8.Entities;

var memory = new Memory();

var display = new Display(32, 64);

// for(var i = 0; i < 32; i++)
// {
//     for(var j = 0; j < 64; j++)
//     {
//         Console.WriteLine(display.Matrix[i,j]);
//     }
// }

// Row 1:  00111000
// Row 2:  01111100
// Row 3:  11111110
// Row 4:  11111110
// Row 5:  01111100
// Row 6:  00111000
// Row 7:  00010000
// Row 8:  00000000

var sprite = new byte[]
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

display.WriteSprite(0,0, sprite);

display.Test();
