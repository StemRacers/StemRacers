using System;
using UnityEngine;

public class UIBlockBase : MonoBehaviour
{
    public BlockType type;

    public virtual BaseBlock CreateLogicBlock(BlockContext blockContext) { return null; }
}
