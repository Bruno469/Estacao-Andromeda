using System;
using System.Runtime.CompilerServices;
using Content.Server.Atmos.EntitySystems;
using Content.Shared.Atmos;
using Content.Shared.Atmos.Reactions;
using Content.Shared.Genetic;
using Robust.Shared.Prototypes;

namespace Content.Server.Genetic
{
    [Prototype("geneMutation")]
    public sealed partial class GeneMutationPrototype : IPrototype
    {
        [ViewVariables]
        [IdDataField]
        public string ID { get; private set; } = default!;
        public string DNASequence => GeneSystem.GetMutationSequence(ID);

        [DataField("mutatename")]
        public string MutateName = string.Empty;

        [DataField("instability")]
        public int Instability { get; set; } = 0;

        [DataField("effects")]
        private List<IGeneMutationEffect> _effects = new();

        public void ApplyEffects(EntityUid target, EntityManager entMan)
        {
            foreach (var effect in _effects)
            {
                effect.Apply(target, entMan);
            }
        }
    }
}
