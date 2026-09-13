#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "VaultVolume.generated.h"

/**
 * Skyway railing vault / fail.
 * Success rail ~3–3.5 ft; fail = hard fall from deck (≥16.5 ft street drop) — no soft float.
 */
UCLASS()
class MPLSGTA_API AVaultVolume : public AActor
{
	GENERATED_BODY()

public:
	AVaultVolume();

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "Vault")
	TObjectPtr<class UBoxComponent> InteractionBox;

	/** Successful vault height in cm (~3–3.5 ft ≈ 91–107 cm). */
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Vault")
	float RailHeightCm = 100.f;

	/** Street drop on fail in cm (≥16.5 ft ≈ 503 cm). */
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Vault")
	float FallDropCm = 503.f;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Vault")
	float FailDamage = 100.f;

	UFUNCTION(BlueprintCallable, Category = "Vault")
	bool TryVault(AActor* InstigatorActor, bool bCommittedJump);
};
