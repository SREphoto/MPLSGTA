#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Pawn.h"
#include "ArcadeVehicle.generated.h"

UENUM(BlueprintType)
enum class EArcadeVehicleClass : uint8
{
	Compact,
	Sedan,
	SUV,
	Sport
};

/**
 * Arcade-plus vehicle stub: shared chassis classes + material grip multipliers (not sim tires).
 * Subclass or Blueprint this; swap to Chaos wheeled pawn when vehicle art lands.
 */
UCLASS()
class MPLSGTA_API AArcadeVehicle : public APawn
{
	GENERATED_BODY()

public:
	AArcadeVehicle();

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Arcade")
	EArcadeVehicleClass VehicleClass = EArcadeVehicleClass::Sedan;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Arcade")
	float BaseGrip = 1.0f;

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Arcade")
	float SurfaceGripMultiplier = 1.0f;

	UFUNCTION(BlueprintCallable, Category = "Arcade")
	void SetSurfaceGripMultiplier(float Multiplier);

	UFUNCTION(BlueprintPure, Category = "Arcade")
	float GetEffectiveGrip() const { return BaseGrip * SurfaceGripMultiplier; }
};
