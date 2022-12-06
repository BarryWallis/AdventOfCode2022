namespace Day5A;
internal interface IInputParser
{
    public IList<CrateStack> ParseCrateStacks();
    public ICollection<MoveCommand> ParseMoveCommands();
}
