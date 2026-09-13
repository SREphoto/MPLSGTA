#include "Gameplay/Zones/GripZoneVolume.h"
#include "Components/BoxComponent.h"
#include "MPLSGTA.h"

AGripZoneVolume::AGripZoneVolume()
{
	PrimaryActorTick.bCanEverTick = false;
	Zone = CreateDefaultSubobject<UBoxComponent>(TEXT("Zone"));
	SetRootComponent(Zone);
	Zone->SetCollisionProfileName(TEXT("OverlapAllDynamic"));
	Zone->SetBoxExtent(FVector(200.f, 200.f, 100.f));
	Zone->OnComponentBeginOverlap.AddDynamic(this, &AGripZoneVolume::OnZoneBeginOverlap);
	Zone->OnComponentEndOverlap.AddDynamic(this, &AGripZoneVolume::OnZoneEndOverlap);
}

void AGripZoneVolume::OnConstruction(const FTransform& Transform)
{
	Super::OnConstruction(Transform);
	switch (Surface)
	{
	case EGripSurface::AtriumPolished: GripMultiplier = 0.55f; break;
	case EGripSurface::SkywayDeck: GripMultiplier = 0.75f; break;
	case EGripSurface::StreetAsphalt: GripMultiplier = 1.0f; break;
	case EGripSurface::Wet: GripMultiplier = 0.7f; break;
	case EGripSurface::Ice: GripMultiplier = 0.35f; break;
	case EGripSurface::Snow: GripMultiplier = 0.5f; break;
	}
}

void AGripZoneVolume::OnZoneBeginOverlap(UPrimitiveComponent* OverlappedComp, AActor* Other,
	UPrimitiveComponent* OtherComp, int32 OtherBodyIndex, bool bFromSweep, const FHitResult& SweepResult)
{
	UE_LOG(LogMPLSGTA, Verbose, TEXT("%s entered grip zone %s (x%.2f)"),
		*GetNameSafe(Other), *UEnum::GetValueAsString(Surface), GripMultiplier);
	// TODO: push GripMultiplier to character movement / arcade vehicle
}

void AGripZoneVolume::OnZoneEndOverlap(UPrimitiveComponent* OverlappedComp, AActor* Other,
	UPrimitiveComponent* OtherComp, int32 OtherBodyIndex)
{
	UE_LOG(LogMPLSGTA, Verbose, TEXT("%s left grip zone %s"), *GetNameSafe(Other), *UEnum::GetValueAsString(Surface));
}
