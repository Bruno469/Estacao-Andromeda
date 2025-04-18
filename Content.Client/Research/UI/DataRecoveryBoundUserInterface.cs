using Robust.Client.UserInterface;
using Robust.Client.GameObjects;
using Content.Client.Research.UI;
using Content.Shared.Research.DataRecovery;
using Content.Shared.Research.Components;

namespace Content.Client.Research.UI
{
    public sealed class DataRecoveryBoundUserInterface : BoundUserInterface
    {
        [ViewVariables]
        private DataRecoveryMenu? _menu;

        public DataRecoveryBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
        {
        }

        protected override void Open()
        {
            base.Open();

            _menu = new DataRecoveryMenu();

            _menu.OnConfirmPressed += () =>
            {
                SendMessage(new DataRecoveryConfirmMessage());
            };

            _menu.OnBitToggled += index =>
            {
                SendMessage(new DataRecoveryBitToggleMessage(index));
            };

            _menu.OpenCentered();
        }

        protected override void UpdateState(BoundUserInterfaceState state)
        {
            base.UpdateState(state);

            if (state is not DataRecoveryBoundUserInterfaceState msg)
                return;

            _menu?.UpdateUI(msg);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!disposing)
                return;

            if (_menu != null)
            {
                _menu.OnConfirmPressed -= null;
                _menu.OnBitToggled -= null;
                _menu.Dispose();
                _menu = null;
            }
        }
    }
}
