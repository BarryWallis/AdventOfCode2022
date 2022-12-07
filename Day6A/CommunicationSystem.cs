/// <summary>
/// A system for elf communicators.
/// </summary>
internal class CommunicationSystem
{
    /// <summary>
    /// Detct start of packet and return the number of characters detected through the start of the packet. The 
    /// start of the packet is the first position where the four most recently received characters were all 
    /// different. Report the number of characters from the beginning of the buffer to the end of the first such 
    /// four-character marker.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns>The number of characters  detected through the start of the packet.</returns>
    internal static int DetectStartOfPacket(string packet)
    {
        int result = 0;
        for (int i = 3; i < packet.Length; i++)
        {
            if (!HasDuplicates(packet[(i - 3)..(i + 1)]))
            {
                result = i + 1;
                break;
            }
        }

        return result == 0 ? throw new InvalidDataException("Start of packet not detected!") : result;
    }

    private static bool HasDuplicates(string stringToCheck)
        => stringToCheck.Length != stringToCheck.Distinct().Count();
}
