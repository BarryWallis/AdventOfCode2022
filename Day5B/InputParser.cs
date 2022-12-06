using System.Collections.ObjectModel;

using CommunityToolkit.Diagnostics;

namespace Day5B;
internal class InputParser : IInputParser
{
    private const int CrateStringWidth = 4;
    private const int CrateStringOffset = 1;
    private const int MinimumMoveLineLength = 18;
    private readonly TextReader _textReader;

    /// <summary>
    /// Create a new InputParser to parse all the program input.
    /// </summary>
    /// <param name="textReader">The object to read input from.</param>
    public InputParser(TextReader textReader) => _textReader = textReader;

    /// <summary>
    /// Parse the input from the _<see cref="textReader"/> to create the crate stacks.
    /// </summary>
    /// <returns>The crate stacks.</returns>
    public IList<CrateStack> ParseCrateStacks()
    {
        /*
               [D]    
           [N] [C]    
           [Z] [M] [P]
            1   2   3 
        */

        string? line;
        int numberOfCrates = 0;
        List<CrateStack> crateStacks = new();
        while (((line = _textReader.ReadLine()) ?? " ").TrimStart().First() == '[')
        {
            line += ' ';
            Guard.IsEqualTo(line.Length % CrateStringWidth, 0);
            if (numberOfCrates == 0)
            {
                numberOfCrates = line.Length / CrateStringWidth;
                crateStacks = new List<CrateStack>(numberOfCrates);
                for (int i = 0; i < numberOfCrates; i++)
                {
                    CrateStack crateStack = new();
                    crateStacks.Add(crateStack);
                }
            }
            else
            {
                Guard.IsEqualTo(line.Length / CrateStringWidth, numberOfCrates);
            }

            for (int i = 0; i < numberOfCrates; i++)
            {
                char crate = line[i * CrateStringWidth + CrateStringOffset];
                if (crate != ' ')
                {
                    crateStacks[i].Push(new Crate(crate));
                }
            }
        }

        for (int i = 0; i < numberOfCrates; i++)
        {
            crateStacks[i].Reverse();
        }
        return crateStacks;
    }

    public ICollection<MoveCommand> ParseMoveCommands()
    {
        /*
          move 1 from 2 to 1
          move 3 from 1 to 3
          move 2 from 2 to 1
          move 1 from 1 to 2
        */

        Collection<MoveCommand> moveCommands = new();
        string? line;
        while ((line = _textReader.ReadLine() ?? " ").Length < MinimumMoveLineLength || line[0..4] != "move")
        {
            // This line intentionally left blank
        }

        do
        {
            string[] moveParts = line.Split(' ');
            if (moveParts.Length != 6 || moveParts[0] != "move" || moveParts[2] != "from" || moveParts[4] != "to")
            {
                throw new FormatException($"Input not in correct format: {line}");
            }
            int cratesToMove = int.Parse(moveParts[1]);
            int from = int.Parse(moveParts[3]);
            int to = int.Parse(moveParts[5]);
            moveCommands.Add(new MoveCommand(cratesToMove, from, to));
        } while ((line = _textReader.ReadLine() ?? string.Empty).Length >= MinimumMoveLineLength && line[0..4] == "move");

        return moveCommands;
    }
}
