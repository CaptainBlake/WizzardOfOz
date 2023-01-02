using Mirror;

namespace Wizzard
{
    /// <summary>
    /// Notification struct contains solution values and sheet number.
    /// sheet number: [INT] 1-3
    /// solution values:
    /// [INT] 0 = EMPTY
    /// [INT] 1 = TRUE
    /// [INT] 2 = FALSE
    /// </summary>
    public struct Notification : NetworkMessage
    {
        public int sheet;
        public int[] solutions;
    }
}

