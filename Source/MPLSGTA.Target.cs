using UnrealBuildTool;
using System.Collections.Generic;

public class MPLSGTATarget : TargetRules
{
	public MPLSGTATarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Game;
		DefaultBuildSettings = BuildSettingsVersion.V5;
		IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_4;
		ExtraModuleNames.Add("MPLSGTA");
	}
}
