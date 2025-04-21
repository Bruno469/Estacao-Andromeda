using Robust.Shared.GameObjects;

namespace Content.Server.Genetic
{
    [DataDefinition]
    public sealed partial class AddComponentEffect : IGeneMutationEffect
    {
        [DataField("component")]
        public string Component = string.Empty;

        public void Apply(EntityUid entity, EntityManager entityManager)
        {
            if (string.IsNullOrEmpty(Component))
                return;

            var type = Type.GetType(Component);
            if (type == null)
                return;

            if (!entityManager.HasComponent(entity, type))
                entityManager.AddComponent(entity, type);
        }
    }

    [DataDefinition]
    public sealed partial class EditValueEffect : IGeneMutationEffect
    {
        [DataField("component")]
        public string Component = string.Empty;

        [DataField("field")]
        public string Field = string.Empty;

        [DataField("value")]
        public object? Value = null;

        public void Apply(EntityUid entity, EntityManager entityManager)
        {
            if (string.IsNullOrEmpty(Component) || string.IsNullOrEmpty(Field))
                return;

            var type = Type.GetType(Component);
            if (type == null || !entityManager.TryGetComponent(entity, type, out var comp))
                return;

            var field = type.GetField(Field);
            if (field != null)
            {
                var converted = Convert.ChangeType(Value, field.FieldType);
                field.SetValue(comp, converted);
                return;
            }

            var prop = type.GetProperty(Field);
            if (prop != null && prop.CanWrite)
            {
                var converted = Convert.ChangeType(Value, prop.PropertyType);
                prop.SetValue(comp, converted);
            }
        }
    }
}
