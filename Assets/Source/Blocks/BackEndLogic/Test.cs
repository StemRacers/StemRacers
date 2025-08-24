using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        // Create context
        BlockContext context = new BlockContext();

        // Create blocks
        DebugPrintBlock block1 = new DebugPrintBlock("ProgramStart");
        RepeatingBlock repeatingBlock = new RepeatingBlock(3);
        DebugPrintBlock block2 = new DebugPrintBlock("Block 2");
        DebugPrintBlock block3 = new DebugPrintBlock("Block 3");
        DebugPrintBlock block4 = new DebugPrintBlock("ProgramEnd");

        // Chain blocks
        block1.NextBlock = repeatingBlock;
        repeatingBlock.ChildBlock = block2;
        block2.NextBlock = block3;
        repeatingBlock.NextBlock = block4;
        // Execute chain
        block1.Execute(context);
    }

}