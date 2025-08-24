



/// <summary>
/// Represents the abstract base class for all block types in the system.
/// Provides a mechanism for chaining blocks and executing block-specific logic.
/// </summary>
/// <remarks>
/// Derived classes must implement the <see cref="Execute"/> method to define their behavior.
/// </remarks>
/// <property name="NextBlock">
/// Gets or sets the next block in the execution chain.
/// </property>
/// <param name="context">
/// The context in which the block is executed.
/// </param>
public abstract class BaseBlock
{

    public BaseBlock NextBlock;

    public abstract void Execute(BlockContext context);
}

