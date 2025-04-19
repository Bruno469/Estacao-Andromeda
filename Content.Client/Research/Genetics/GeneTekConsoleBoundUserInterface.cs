using Content.Shared.Research.Genetics;
using Content.Shared.Research.Components;
using Robust.Client.GameObjects;
using Robust.Client.UserInterface;

namespace Content.Client.Research.Genetics
{
    public sealed class GeneTekConsoleBoundUserInterface : BoundUserInterface
    {
        [ViewVariables]
        private GeneTekConsoleMenu? _menu;

        public GeneTekConsoleBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
        {
        }

        protected override void Open()
        {
            base.Open();

            if (_menu == null)
            {
                _menu = new GeneTekConsoleMenu();
                _menu.OnClose += Close;
            }

            _menu.OpenCentered();
        }

        protected override void UpdateState(BoundUserInterfaceState state)
        {
            base.UpdateState(state);

            if (state is not GeneTekConsoleBoundUserInterfaceState msg)
                return;

            _menu?.Update(msg);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!disposing)
                return;

            _menu?.Dispose();
        }
    }
}
