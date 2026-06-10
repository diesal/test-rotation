using ImGuiNET;
using SVector2 = System.Numerics.Vector2;
using SColor = System.Drawing.Color;

namespace SkillFlow;

public class TestRotation : BaseRotation 
{
    public TestRotation(Plugin plugin) : base(plugin) { }

    public override string Name => "Test Rotation";
    public override string Author => "Diesel";
    public override string Description => "A simple test rotation to verify repo installation and rendering.";

    public TestSettings Settings = new TestSettings();
    public class TestSettings {
        public bool EnableVisuals = true;
        public float Opacity = 1.0f;
    }

    public override void Initialize() { }

    public override void DrawSettings() {
        ImGui.TextColored(new System.Numerics.Vector4(1.0f, 1.0f, 0.0f, 1.0f), "TEST ROTATION SETTINGS");
        ImGui.Spacing();

        ImGui.Checkbox("Enable Debug Visuals", ref Settings.EnableVisuals);
        ImGui.SliderFloat("Visual Opacity", ref Settings.Opacity, 0.1f, 1.0f);
    }

    public override void Render() {
        if (!Settings.EnableVisuals) return;

        var player = GameController?.Player;
        if (player == null || !player.IsValid) return;

        var screenPos = GameController.IngameState.Camera.WorldToScreen(player.Pos);
        if (screenPos != SVector2.Zero) {
            Graphics.DrawText($"Test Rotation Active", new SVector2(screenPos.X, screenPos.Y - 50), SColor.Yellow);
            Graphics.DrawText($"Opacity: {Settings.Opacity:F2}", new SVector2(screenPos.X, screenPos.Y - 35), SColor.White);
        }
    }

    public override RotationAction GetNextAction() {
        // Logic for actions would go here
        return null;
    }
}
