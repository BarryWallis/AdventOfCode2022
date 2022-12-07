/// <summary>
/// A system for elf communicators.
/// </summary>
internal class CommunicationSystem
{
    /// <summary>
    /// Detct start of anything and return the number of characters detected through the start. The 
    /// start is the first position where the most most recently received characters were all 
    /// different. Report the number of characters from the beginning of the buffer to the end of the first such 
    /// marker.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <param name="numberOfCharactersToCheck"
    /// <returns>The number of characters  detected through the start of the packet.</returns>
    internal static int DetectStartOfAnything(string packet, int numberOfCharactersToCheck)
    {
        int result = 0;
        for (int i = numberOfCharactersToCheck - 1; i < packet.Length; i++)
        {
            if (!HasDuplicates(packet[(i - (numberOfCharactersToCheck - 1))..(i + 1)]))
            {
                result = i + 1;
                break;
            }
        }

        return result == 0 ? throw new InvalidDataException("Start not detected!") : result;
    }

    internal static int DetectStartOfPacket(string packet) => DetectStartOfAnything(packet, 4);

    internal static int DetectStartOfMessage(string packet) => DetectStartOfAnything(packet, 14);


    /// <summary>
    /// Determine if the string has any duplicates.
    /// </summary>
    /// <param name="stringToCheck">The string to check for duplicates.</param>
    /// <returns>
    /// <see langword="true"/> if the string contains any duplicate characters; otherwise 
    /// <see langword="false"/>.</returns>
    private static bool HasDuplicates(string stringToCheck)
        => stringToCheck.Length != stringToCheck.Distinct().Count();
}
