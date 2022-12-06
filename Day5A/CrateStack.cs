namespace Day5A;

/// <summary>
/// A stack of crates.
/// </summary>
internal class CrateStack
{
    private Stack<Crate> _crates = new();

    /// <summary>
    /// Returns the <see cref="Crate"/> at the top of the stack without removing it.
    /// </summary>
    /// <returns>The <see cref="Crate"/> at top of the stack.</returns>
    public Crate Peek() => _crates.Peek();

    /// <summary>
    /// Removes and returns the <see cref="Crate"/> at the top of the stack.
    /// </summary>
    /// <returns>The <see cref="Crate"/> at top of the stack.</returns>
    public Crate Pop() => _crates.Pop();

    /// <summary>
    /// Inserts a <see cref="Crate"/> at the top of the Stack.
    /// </summary>
    /// <param name="crate">The </param>
    public void Push(Crate crate) => _crates.Push(crate);

    public void Reverse() => _crates = new(_crates);
}
