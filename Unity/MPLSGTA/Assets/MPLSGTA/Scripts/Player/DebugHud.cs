using UnityEngine;

namespace MPLSGTA
{
    // Top-left readout so playtesters can check the locked numbers while walking the slice.
    public class DebugHud : MonoBehaviour
    {
        public MPLSPlayer player;
        public WantedSystem wanted;
        GUIStyle style;

        void OnGUI()
        {
            if (player == null || wanted == null) return;
            if (style == null) style = new GUIStyle(GUI.skin.label) { fontSize = 16 };
            string zone = wanted.CurrentZone.HasValue ? wanted.CurrentZone.Value.ToString() : "None";
            string text =
                "Grip: " + player.GripName + " " + player.Grip.ToString("0.00") + "\n" +
                "Heat zone: " + zone + "\n" +
                "Heat: " + wanted.Heat.ToString("0.0") + "   Stars: " + wanted.Stars + "\n" +
                "Health: " + player.Health.ToString("0") + "\n" +
                "Vault zone: " + (player.currentVault != null ? "yes (E)" : "no") + "\n" +
                "Last: " + player.LastEvent + "\n\n" +
                "WASD move, Shift sprint, Space jump, E vault, F steal (court), R respawn";
            GUI.Box(new Rect(8, 8, 470, 190), GUIContent.none);
            GUI.Label(new Rect(16, 12, 460, 185), text, style);
        }
    }
}
