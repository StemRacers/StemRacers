using UnityEngine;

public class DebugPrintBlock : BaseBlock
{

    private string _message;

    public DebugPrintBlock(string message)
    {
        _message = message;
    }

    public override void Execute(BlockContext context)
    {
        Debug.Log(_message);
        NextBlock?.Execute(context);
    }
}
