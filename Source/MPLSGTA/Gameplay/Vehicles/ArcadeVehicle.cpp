#include "Gameplay/Vehicles/ArcadeVehicle.h"

AArcadeVehicle::AArcadeVehicle()
{
	PrimaryActorTick.bCanEverTick = false;
}

void AArcadeVehicle::SetSurfaceGripMultiplier(float Multiplier)
{
	SurfaceGripMultiplier = FMath::Clamp(Multiplier, 0.1f, 1.5f);
}
