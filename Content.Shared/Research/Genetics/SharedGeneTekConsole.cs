using Robust.Shared.Serialization;

namespace Content.Shared.Research.Genetics;

[Serializable, NetSerializable]
public enum GeneTekConsoleUiKey : byte
{
    Key
}

[Serializable, NetSerializable]
public sealed class GeneTekConsoleBoundUserInterfaceState : BoundUserInterfaceState
{
    // Dados do paciente
    public string? OccupantName { get; }
    public float Health { get; }
    public float Stability { get; }
    public bool InjectorsReady { get; }
    public bool EmitterReady { get; }

    // Estatísticas gerais
    public int MaterialsCurrent { get; }
    public int MaterialsMax { get; }
    public int Budget { get; }
    public int MutationsResearched { get; }
    public int AutoDecryptors { get; }

    // Lista de pesquisas disponíveis
    public List<AvailableResearchEntry> AvailableResearch { get; }

    public GeneTekConsoleBoundUserInterfaceState(
        string? occupantName,
        float health,
        float stability,
        bool injectorsReady,
        bool emitterReady,
        int materialsCurrent,
        int materialsMax,
        int budget,
        int mutationsResearched,
        int autoDecryptors,
        List<AvailableResearchEntry> availableResearch)
    {
        OccupantName = occupantName;
        Health = health;
        Stability = stability;
        InjectorsReady = injectorsReady;
        EmitterReady = emitterReady;
        MaterialsCurrent = materialsCurrent;
        MaterialsMax = materialsMax;
        Budget = budget;
        MutationsResearched = mutationsResearched;
        AutoDecryptors = autoDecryptors;
        AvailableResearch = availableResearch;
    }
}

[Serializable, NetSerializable]
public sealed class AvailableResearchEntry
{
    public string Name { get; }
    public int Cost { get; }
    public int Duration { get; }

    public AvailableResearchEntry(string name, int cost, int duration)
    {
        Name = name;
        Cost = cost;
        Duration = duration;
    }
}
