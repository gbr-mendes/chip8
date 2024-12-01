namespace chip8.Entities;

public class Memory
{
    public byte[] Addresses { get; } = new byte[4096];
    public List<byte[]> CharList = new()
    {
        {new byte[] {0xF0, 0x90, 0x90, 0x90, 0xF0}}, //0
        {new byte[] {0x20, 0x60, 0x20, 0x20, 0x70}}, //1
        {new byte[] {0xF0, 0x10, 0xF0, 0x80, 0xF0}}, //2
        {new byte[] {0xF0, 0x10, 0xF0, 0x10, 0xF0}}, //3
        {new byte[] {0x90, 0x90, 0xF0, 0x10, 0x10}}, //4
        {new byte[] {0xF0, 0x80, 0xF0, 0x10, 0xF0}}, //5
        {new byte[] {0xF0, 0x80, 0xF0, 0x90, 0xF0}}, //6
        {new byte[] {0xF0, 0x10, 0x20, 0x40, 0x40}}, //7
        {new byte[] {0xF0, 0x90, 0xF0, 0x90, 0xF0}}, //8
        {new byte[] {0xF0, 0x90, 0xF0, 0x10, 0xF0}}, //9
        {new byte[] {0xF0, 0x90, 0xF0, 0x90, 0x90}}, //A
        {new byte[] {0xE0, 0x90, 0xE0, 0x90, 0xE0}}, //B
        {new byte[] {0xF0, 0x80, 0x80, 0x80, 0xF0}}, //C
        {new byte[] {0xE0, 0x90, 0x90, 0x90, 0xE0}}, //D
        {new byte[] {0xF0, 0x80, 0xF0, 0x80, 0xF0}}, //E
        {new byte[] {0xF0, 0x80, 0xF0, 0x80, 0x80}}, //F
    };

    public Memory()
    {
        ReserveFontAddresses();
    }

    public byte Read(int address)
    {
        if (address < 0 || address > 4095)
        {
            throw new Exception("Invalid memory access");
        }

        return Addresses[address];
    }

    public void Write(int address, byte value)
    {
        if (address < 0 || address > 4095)
        {
            throw new Exception("Invalid memory access");
        }

        Addresses[address] = value;
    }

    public void ReserveFontAddresses()
    {
        // its a convetion fonts to start on 050 and finish on 09F
        var address = 80;
        foreach(var charBytes in CharList)
        {
            foreach(var b in charBytes)
            {
                Write(address, b);
                address++;
            }
        }
    }

    public short ReadInstructionBytes(int pc)
    {
        var highByte = Read(pc);
        var lowByte = Read(pc + 1);
        return (short)(( highByte << 8) | lowByte);
    }

    public void LoadGame(string gamePath)
    {
        var gameBytes = File.ReadAllBytes(gamePath);
        var memoryAddress = 512; // The first 512 bytes are reserverd, so we start to load the game here
        foreach(var gb in gameBytes)
        {
            Write(memoryAddress, gb);
            memoryAddress++;
        }
    }

    public byte[] ReadSprite(int startAddress, int length)
    {
        return Addresses.Skip(startAddress).Take(length).ToArray();
    }
}
