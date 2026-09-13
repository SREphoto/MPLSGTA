#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Gameplay/Wanted/WantedComponent.h"
#include "HeatZoneVolume.generated.h"

/**
 * Overlap that sets the player's wanted zone (street / skyway dump / soft-theft).
 * Place on CrystalCourt, Skyway_*, NicolletExit volumes in L_IDS_Slice.
 */
UCLASS()
class MPLSGTA_API AHeatZoneVolume : public AActor
{
	GENERATED_BODY()

public:
	AHeatZoneVolume();

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Heat")
	TObjectPtr<class UBoxComponent> Zone;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Heat")
	EWantedZone ZoneType = EWantedZone::Street;

protected:
	UFUNCTION()
	void OnZoneBeginOverlap(UPrimitiveComponent* OverlappedComp, AActor* Other,
		UPrimitiveComponent* OtherComp, int32 OtherBodyIndex, bool bFromSweep, const FHitResult& SweepResult);
};
