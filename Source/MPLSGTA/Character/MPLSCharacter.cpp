#include "Character/MPLSCharacter.h"
#include "Gameplay/Wanted/WantedComponent.h"
#include "GameFramework/CharacterMovementComponent.h"

AMPLSCharacter::AMPLSCharacter()
{
	Wanted = CreateDefaultSubobject<UWantedComponent>(TEXT("Wanted"));
}

void AMPLSCharacter::SetActiveGripMultiplier(float Multiplier)
{
	ActiveGripMultiplier = FMath::Clamp(Multiplier, 0.1f, 1.5f);
	if (UCharacterMovementComponent* Move = GetCharacterMovement())
	{
		// Arcade-plus: scale ground friction / braking with surface (tunable).
		Move->GroundFriction = 8.f * ActiveGripMultiplier;
		Move->BrakingDecelerationWalking = 2048.f * ActiveGripMultiplier;
	}
}
