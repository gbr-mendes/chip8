namespace chip8.Entities;

public class Stack
{
    private List<byte> Addresses { get; } = new();

    public void Push(byte[] addresses)
    {
        if (addresses.Length != 2)
        {
            throw new Exception("Stack entries should be 16 bits long");
        }

        if (Addresses.Count == 16)
        {
            throw new Exception("Stack overflow");
        }
        
        foreach(var address in addresses)
        {
            Addresses.Add(address);
        }
    }

    public List<byte> Pop()
    {
        if (Addresses.Count < 2)
        {
            throw new Exception("Nothing to pop");
        }

        var elements = Addresses.TakeLast(2).ToList();
        Addresses.RemoveRange(Addresses.Count - 2, 2);
        return elements;
    }
}
