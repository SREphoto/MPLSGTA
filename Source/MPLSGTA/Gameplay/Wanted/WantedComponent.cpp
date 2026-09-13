#include "Gameplay/Wanted/WantedComponent.h"
#include "MPLSGTA.h"

UWantedComponent::UWantedComponent()
{
	PrimaryComponentTick.bCanEverTick = false;
}

void UWantedComponent::SetActiveZone(EWantedZone NewZone)
{
	ActiveZone = NewZone;
	UE_LOG(LogMPLSGTA, Log, TEXT("Wanted zone -> %d (heat %d)"), static_cast<int32>(ActiveZone), HeatLevel);
}

void UWantedComponent::AddHeat(int32 Delta)
{
	HeatLevel = FMath::Clamp(HeatLevel + Delta, 0, 5);
}

void UWantedComponent::ClearHeat()
{
	HeatLevel = 0;
}

float UWantedComponent::GetEffectiveChaseSpeedFactor() const
{
	if (ActiveZone == EWantedZone::Skyway)
	{
		return SkywayChaseSlowFactor;
	}
	if (ActiveZone == EWantedZone::SoftTheft)
	{
		return 0.35f;
	}
	return 1.0f;
}
