public interface IUnitInput
{
    float ForwardMove { get; }
    float SideMove { get; }
    float SideRotation { get; }
    bool Jump { get; }
    void readInput();
}

public interface ICamInput
{
    void readInput();
    float yCamRotation { get; }
}