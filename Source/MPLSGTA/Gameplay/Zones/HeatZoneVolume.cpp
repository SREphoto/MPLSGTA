#include "Gameplay/Zones/HeatZoneVolume.h"
#include "Components/BoxComponent.h"
#include "Gameplay/Wanted/WantedComponent.h"

AHeatZoneVolume::AHeatZoneVolume()
{
	PrimaryActorTick.bCanEverTick = false;
	Zone = CreateDefaultSubobject<UBoxComponent>(TEXT("Zone"));
	SetRootComponent(Zone);
	Zone->SetCollisionProfileName(TEXT("OverlapAllDynamic"));
	Zone->SetBoxExtent(FVector(200.f, 200.f, 100.f));
	Zone->OnComponentBeginOverlap.AddDynamic(this, &AHeatZoneVolume::OnZoneBeginOverlap);
}

void AHeatZoneVolume::OnZoneBeginOverlap(UPrimitiveComponent* OverlappedComp, AActor* Other,
	UPrimitiveComponent* OtherComp, int32 OtherBodyIndex, bool bFromSweep, const FHitResult& SweepResult)
{
	if (UWantedComponent* Wanted = Other ? Other->FindComponentByClass<UWantedComponent>() : nullptr)
	{
		Wanted->SetActiveZone(ZoneType);
	}
}
