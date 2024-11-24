namespace chip8.Entities;

public class Stack
{
    private List<short> Addresses { get; } = new();

    public void Push(short address)
    {
    
        if (Addresses.Count == 16)
        {
            throw new Exception("Stack overflow");
        }
        
        Addresses.Add(address);
    }

    public short Pop()
    {
        if (Addresses.Count < 1)
        {
            throw new Exception("Nothing to pop");
        }

        var element = Addresses.TakeLast(1).First();
        Addresses.RemoveAt(-1);
        return element;
    }
}
