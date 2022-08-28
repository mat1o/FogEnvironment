namespace FogEnvironment.Domain.Enum
{
    public enum TaskState : byte
    {
        AwaitForFreeNode,
        Assigned,
        InProgress,
        Canceld,
        Done,
    }
}
