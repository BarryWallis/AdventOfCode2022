namespace Day5B;
internal interface IInputParser
{
    public IList<CrateStack> ParseCrateStacks();
    public ICollection<MoveCommand> ParseMoveCommands();
}
