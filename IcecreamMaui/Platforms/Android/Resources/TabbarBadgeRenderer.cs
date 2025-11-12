using Google.Android.Material.Badge;
using Google.Android.Material.BottomNavigation;
using IcecreamMaui.ViewModels;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;

namespace IcecreamMaui
{
    public class TabbarBadgeRenderer : ShellRenderer
    {
        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(Microsoft.Maui.Controls.ShellItem shellItem)
        {
            return new BadgeShellBottomNavViewAppearanceTracker(this, shellItem);
        }
    }

    class BadgeShellBottomNavViewAppearanceTracker : ShellBottomNavViewAppearanceTracker
    {
        private BadgeDrawable _BadgeDrawable;
        public BadgeShellBottomNavViewAppearanceTracker(IShellContext shellContext, Microsoft.Maui.Controls.ShellItem shellItem) : base(shellContext, shellItem)
        {
        }

        public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            base.SetAppearance(bottomView, appearance);

            if (_BadgeDrawable is null)
            {
                const int CartTabbarItemIndex = 1;
                _BadgeDrawable = bottomView.GetOrCreateBadge(CartTabbarItemIndex);
                UpdateBadge(CartViewModel.TotalCartCount);
                CartViewModel.TotalCartCountChanged += CartViewModel_TotalCartCountChanged;

            }
        }

        private void CartViewModel_TotalCartCountChanged(object? sender, int newCount) =>
            UpdateBadge(newCount);



        private void UpdateBadge(int count)
        {
            if (count <= 0)
            {
                _BadgeDrawable.SetVisible(false);
            }
            else
            {
                _BadgeDrawable.Number = count;
                _BadgeDrawable.BackgroundColor = Colors.Wheat.ToPlatform();
                _BadgeDrawable.BadgeTextColor = Colors.Black.ToPlatform();
                _BadgeDrawable.SetVisible(true);
            }

        }

        protected override void Dispose(bool disposing)
        {
            CartViewModel.TotalCartCountChanged -= CartViewModel_TotalCartCountChanged;
            base.Dispose(disposing);
        }
    }
}
