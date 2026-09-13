#include "Gameplay/Zones/VaultVolume.h"
#include "Components/BoxComponent.h"
#include "GameFramework/Pawn.h"
#include "MPLSGTA.h"

AVaultVolume::AVaultVolume()
{
	PrimaryActorTick.bCanEverTick = false;
	InteractionBox = CreateDefaultSubobject<UBoxComponent>(TEXT("InteractionBox"));
	SetRootComponent(InteractionBox);
	InteractionBox->SetCollisionProfileName(TEXT("OverlapAllDynamic"));
}

bool AVaultVolume::TryVault(AActor* InstigatorActor, bool bCommittedJump)
{
	if (!InstigatorActor)
	{
		return false;
	}

	if (bCommittedJump)
	{
		UE_LOG(LogMPLSGTA, Log, TEXT("Vault SUCCESS over %.0f cm rail"), RailHeightCm);
		return true;
	}

	UE_LOG(LogMPLSGTA, Warning, TEXT("Vault FAIL — hard fall %.0f cm, damage %.0f (no soft float)"), FallDropCm, FailDamage);
	// TODO: apply FailDamage + launch pawn downward; Animation binds scrape/fall pose
	return false;
}
