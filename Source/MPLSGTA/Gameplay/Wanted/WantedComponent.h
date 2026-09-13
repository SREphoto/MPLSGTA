#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "WantedComponent.generated.h"

UENUM(BlueprintType)
enum class EWantedZone : uint8
{
	Street UMETA(DisplayName = "Street"),
	Skyway UMETA(DisplayName = "Skyway Heat Dump"),
	SoftTheft UMETA(DisplayName = "Crystal Court Soft Theft"),
	None UMETA(DisplayName = "None")
};

/**
 * Arcade wanted / heat for the IDS slice.
 * Street = full chase rules; Skyway = LOS break + slower chase; SoftTheft = quiet crime before Nicollet exit.
 */
UCLASS(ClassGroup = (MPLSGTA), meta = (BlueprintSpawnableComponent))
class MPLSGTA_API UWantedComponent : public UActorComponent
{
	GENERATED_BODY()

public:
	UWantedComponent();

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Wanted", meta = (ClampMin = "0", ClampMax = "5"))
	int32 HeatLevel = 0;

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Wanted")
	EWantedZone ActiveZone = EWantedZone::None;

	/** Multiplier applied to chase aggression / cop speed while in skyway (heat dump). */
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Wanted")
	float SkywayChaseSlowFactor = 0.55f;

	UFUNCTION(BlueprintCallable, Category = "Wanted")
	void SetActiveZone(EWantedZone NewZone);

	UFUNCTION(BlueprintCallable, Category = "Wanted")
	void AddHeat(int32 Delta);

	UFUNCTION(BlueprintCallable, Category = "Wanted")
	void ClearHeat();

	UFUNCTION(BlueprintPure, Category = "Wanted")
	float GetEffectiveChaseSpeedFactor() const;
};
