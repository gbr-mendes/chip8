using chip8.Entities;

var memory = new Memory();
memory.LoadGame("./roms/ibm_logo.ch8");

var display = new Display(32, 64);

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

    if (instructionBytes == 0x00E0)
    {
        display.Clear();
        continue;
    }

    var opcode = (byte) ((instructionBytes >> 12) & 0xF);
    var X = (byte) ((instructionBytes >> 8) & 0xF);
    var Y = (byte) ((instructionBytes >> 4) & 0xF);
    var N = (byte) (instructionBytes & 0xF);
    var NN = (byte) (instructionBytes & 0xFF);
    var NNN = (short) (instructionBytes & 0xFFF);
    //execute
    switch(opcode)
    {
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
            byte _x = 0;
            byte _y = 0;
            switch(X)
            {
                case 0x0:
                    _x = v0;
                    break;
                case 0x1:
                    _x = v1;
                    break;
                case 0x2:
                    _x = v2;
                    break;
                case 0x3:
                    _x = v3;
                    break;
                case 0x4:
                    _x = v4;
                    break;
                case 0x5:
                    _x = v5;
                    break;
                case 0x6:
                    _x = v6;
                    break;
                case 0x7:
                    _x = v7;
                    break;
                case 0x8:
                    _x = v8;
                    break;
                case 0x9:
                    _x = v9;
                    break;
                case 0xA:
                    _x = vA;
                    break;
                case 0xB:
                    _x = vB;
                    break;
                case 0xC:
                    _x = vC;
                    break;
                case 0xD:
                    _x = vD;
                    break;
                case 0xE:
                    _x = vE;
                    break;
                case 0xF:
                    _x = vF;
                    break;
            }

            switch(Y)
            {
                case 0x0:
                    _y = v0;
                    break;
                case 0x1:
                    _y = v1;
                    break;
                case 0x2:
                    _y = v2;
                    break;
                case 0x3:
                    _y = v3;
                    break;
                case 0x4:
                    _y = v4;
                    break;
                case 0x5:
                    _y = v5;
                    break;
                case 0x6:
                    _y = v6;
                    break;
                case 0x7:
                    _y = v7;
                    break;
                case 0x8:
                    _y = v8;
                    break;
                case 0x9:
                    _y = v9;
                    break;
                case 0xA:
                    _y = vA;
                    break;
                case 0xB:
                    _y = vB;
                    break;
                case 0xC:
                    _y = vC;
                    break;
                case 0xD:
                    _y = vD;
                    break;
                case 0xE:
                    _y = vE;
                    break;
                case 0xF:
                    _y = vF;
                    break;
            }
            // read sprit from length N
            var sprite = memory.ReadSprite(I, N);
            display.WriteSprite(_x & 63, _y & 31, sprite, ref vF);
            break;
    }
}
