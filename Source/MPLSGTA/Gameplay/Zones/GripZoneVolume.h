#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "GripZoneVolume.generated.h"

UENUM(BlueprintType)
enum class EGripSurface : uint8
{
	AtriumPolished UMETA(DisplayName = "Atrium Polished (Low)"),
	SkywayDeck UMETA(DisplayName = "Skyway Deck (Mid)"),
	StreetAsphalt UMETA(DisplayName = "Street Asphalt (Full)"),
	Wet UMETA(DisplayName = "Wet (Hook)"),
	Ice UMETA(DisplayName = "Ice (Hook)"),
	Snow UMETA(DisplayName = "Snow (Hook)")
};

/**
 * Overlap volume that sets locomotion / vehicle grip multipliers.
 * IDS slice: Crystal Court = AtriumPolished, skyways = SkywayDeck, Nicollet = StreetAsphalt.
 */
UCLASS()
class MPLSGTA_API AGripZoneVolume : public AActor
{
	GENERATED_BODY()

public:
	AGripZoneVolume();

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Grip")
	TObjectPtr<class UBoxComponent> Zone;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Grip")
	EGripSurface Surface = EGripSurface::StreetAsphalt;

	/** 1.0 = full street grip. Atrium ~0.55, skyway ~0.75 (tunable). */
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Grip", meta = (ClampMin = "0.1", ClampMax = "1.5"))
	float GripMultiplier = 1.0f;

	virtual void OnConstruction(const FTransform& Transform) override;

protected:
	UFUNCTION()
	void OnZoneBeginOverlap(UPrimitiveComponent* OverlappedComp, AActor* Other,
		UPrimitiveComponent* OtherComp, int32 OtherBodyIndex, bool bFromSweep, const FHitResult& SweepResult);

	UFUNCTION()
	void OnZoneEndOverlap(UPrimitiveComponent* OverlappedComp, AActor* Other,
		UPrimitiveComponent* OtherComp, int32 OtherBodyIndex);
};
