using chip8.Entities;

var memory = new Memory();
memory.LoadGame("./roms/ibm_logo.ch8");

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

// Console.Clear();
// Console.WriteLine("\x1b[3J");
// Console.SetCursorPosition(0,0);

// display.WriteSprite(20,5, sprite1);
// display.Show();

// await Task.Delay(5000);
// display.WriteSprite(0,0, sprite2);
// display.Show();

var pc = 512;
// REGISTERS
short I = 0;
byte v0 = 0;
byte v1 = 0;
byte v2 = 0;
byte v3 = 0;
byte v4 = 0;
byte v5 = 0;
byte v6 = 0;
byte v7 = 0;
byte v8 = 0;
byte v9 = 0;
byte vA = 0;
byte vB = 0;
byte vC = 0;
byte vD = 0;
byte vE = 0;
byte vF = 0;

while(true)
{
    // fetch
    var instructionBytes = memory.ReadInstructionBytes(pc);
    pc += 2;

    // decode
    var opcode = (byte) (instructionBytes >> 12 )& 0XF;
    var X = (byte) ((instructionBytes >> 8) & 0XF);
    var Y = (byte) ((instructionBytes >> 4) & 0XF);
    var N = (byte) (instructionBytes & 0XF);
    var NN = (byte) (instructionBytes & 0XFF);
    var NNN = (byte) (instructionBytes & 0XFFF);

    //execute
    switch(opcode)
    {
        case 0x00E0:
            display.Clear();
            break;
        case 0x1:
            pc = NNN;
            break;
        case 0x6:
            switch(X)
            {
                case 0x0:
                    v0 = NN;
                    break;
                case 0x1:
                    v1 = NN;
                    break;
                case 0x2:
                    v2 = NN;
                    break;
                case 0x3:
                    v3 = NN;
                    break;
                case 0x4:
                    v4 = NN;
                    break;
                case 0x5:
                    v5 = NN;
                    break;
                case 0x6:
                    v6 = NN;
                    break;
                case 0x7:
                    v7 = NN;
                    break;
                case 0x8:
                    v8 = NN;
                    break;
                case 0x9:
                    v9 = NN;
                    break;
                case 0xA:
                    vA = NN;
                    break;
                case 0xB:
                    vB = NN;
                    break;
                case 0xC:
                    vC = NN;
                    break;
                case 0xD:
                    vD = NN;
                    break;
                case 0xE:
                    vE = NN;
                    break;
                case 0xF:
                    vF = NN;
                    break;
            }
            break;
        case 0x7:
            switch(X)
            {
                case 0x0:
                    v0 += NN;
                    break;
                case 0x1:
                    v1 += NN;
                    break;
                case 0x2:
                    v2 += NN;
                    break;
                case 0x3:
                    v3 += NN;
                    break;
                case 0x4:
                    v4 += NN;
                    break;
                case 0x5:
                    v5 += NN;
                    break;
                case 0x6:
                    v6 += NN;
                    break;
                case 0x7:
                    v7 += NN;
                    break;
                case 0x8:
                    v8 += NN;
                    break;
                case 0x9:
                    v9 += NN;
                    break;
                case 0xA:
                    vA += NN;
                    break;
                case 0xB:
                    vB += NN;
                    break;
                case 0xC:
                    vC += NN;
                    break;
                case 0xD:
                    vD += NN;
                    break;
                case 0xE:
                    vE += NN;
                    break;
                case 0xF:
                    vF += NN;
                    break;
            }
            break;
        case 0xA:
            I = NNN;
            break;
        case 0xD:
            Console.WriteLine("Here man");
            break;
    }

    // await Task.Delay(100);
}
