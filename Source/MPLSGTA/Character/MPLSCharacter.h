#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Character.h"
#include "MPLSCharacter.generated.h"

class UWantedComponent;

/** Default player pawn for the IDS slice — walks grip zones and carries wanted/heat. */
UCLASS()
class MPLSGTA_API AMPLSCharacter : public ACharacter
{
	GENERATED_BODY()

public:
	AMPLSCharacter();

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "MPLS")
	TObjectPtr<UWantedComponent> Wanted;

	UPROPERTY(VisibleAnywhere, BlueprintReadOnly, Category = "MPLS")
	float ActiveGripMultiplier = 1.0f;

	UFUNCTION(BlueprintCallable, Category = "MPLS")
	void SetActiveGripMultiplier(float Multiplier);
};
