namespace Content.Shared.Genetic
{
    public sealed class GeneSystem : EntitySystem
    {
        private static Dictionary<string, string> _roundMutationSequences = new();

        public override void Initialize()
        {
            base.Initialize();
            GenerateRoundMutationSequences();
        }
        public void AddRandomMutations(EntityUid entity, EntityManager entMan)
        {
            if (!entMan.TryGetComponent(entity, out GeneticComponent? genes))
                return;

            var allMutations = PrototypeManager.EnumeratePrototypes<GeneMutationPrototype>().ToList();
            var selected = new HashSet<string>();

            var rand = new Random();
            while (selected.Count < 8)
            {
                var mut = allMutations[rand.Next(allMutations.Count)];
                selected.Add(mut.ID); // evita duplicatas
            }

            genes.InactiveMutations.AddRange(selected);
        }


        private void GenerateRoundMutationSequences()
        {
            _roundMutationSequences.Clear();

            foreach (var proto in PrototypeManager.EnumeratePrototypes<GeneMutationPrototype>())
            {
                _roundMutationSequences[proto.ID] = GenerateRandomSequence();
            }
        }

        public static string GetMutationSequence(string mutationId)
        {
            return _roundMutationSequences.TryGetValue(mutationId, out var seq) ? seq : "ERRORSEQ";
        }

        private string GenerateRandomSequence()
        {
            var rand = new Random();
            var validPairs = new[] { "AT", "TA", "GC", "CG" };
            var sb = new StringBuilder();

            for (int i = 0; i < 6; i++) // 6 pares = 12 letras
            {
                sb.Append(validPairs[rand.Next(validPairs.Length)]);
            }

            return sb.ToString();
        }
    }
}
