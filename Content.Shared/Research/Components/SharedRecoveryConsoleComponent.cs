using Robust.Shared.Serialization;

namespace Content.Shared.Research.Components
{
    [NetSerializable, Serializable]
    public enum RecoveryConsoleUiKey : byte
    {
        Key,
    }

    [Serializable, NetSerializable]
    public sealed class DataRecoveryConfirmMessage : BoundUserInterfaceMessage
    {
    }

    [Serializable, NetSerializable]
    public sealed class DataRecoveryBitToggleMessage : BoundUserInterfaceMessage
    {
        public int Index;

        public DataRecoveryBitToggleMessage(int index)
        {
            Index = index;
        }
    }

    [Serializable, NetSerializable]
    public sealed class DataRecoveryBoundUserInterfaceState : BoundUserInterfaceState
    {
        public bool[] Bytes { get; }
        public bool[] ErrorMask { get; }
        public bool CanConfirm { get; }

        public DataRecoveryBoundUserInterfaceState(bool[] bytes, bool[] errorMask, bool canConfirm)
        {
            Bytes = bytes;
            ErrorMask = errorMask;
            CanConfirm = canConfirm;
        }
    }
}
