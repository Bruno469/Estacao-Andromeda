using System.Collections;
using Content.Server.Genetic;

namespace Content.Server.Forensics;

/// <summary>
/// This component is for mobs that have DNA.
/// </summary>
[RegisterComponent]
public sealed partial class DnaComponent : Component
{
    [DataField("dna"), ViewVariables(VVAccess.ReadWrite)]
    public string DNA = String.Empty;

    [DataField("instability"), ViewVariables(VVAccess.ReadWrite)]
    public int Instability = 0;

    [DataField("activemutations"), ViewVariables(VVAccess.ReadWrite)]
    public IEnumerable<GeneMutationPrototype> ActiveMutations;
    public List<string> InactiveMutations = new();
}
