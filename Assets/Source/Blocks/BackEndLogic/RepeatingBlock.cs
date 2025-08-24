using UnityEngine;

public class RepeatingBlock : BaseBlock
{
    private int _repeatCount;
    public BaseBlock ChildBlock;

    public RepeatingBlock(int repeatCount)
    {
        _repeatCount = repeatCount;
    }

    public override void Execute(BlockContext context)
    {
        for (int i = 0; i < _repeatCount; i++)
        {
            Debug.Log($"Executing RepeatingBlock: {i + 1}/{_repeatCount}");
            ChildBlock?.Execute(context);
        }
        NextBlock?.Execute(context);
    }
}
