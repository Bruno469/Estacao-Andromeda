namespace Content.Server.Genetic
{
    public interface IGeneMutationEffect
    {
        void Apply(EntityUid entity, EntityManager entityManager);
    }
}
