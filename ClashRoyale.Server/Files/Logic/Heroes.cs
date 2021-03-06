using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Heroes : Data
    {
        public Heroes(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string Rarity { get; set; }

        public int SightRange { get; set; }

        public int DeployTime { get; set; }

        public int ChargeRange { get; set; }

        public int Speed { get; set; }

        public int Hitpoints { get; set; }

        public int HitSpeed { get; set; }

        public int LoadTime { get; set; }

        public int Damage { get; set; }

        public int DamageSpecial { get; set; }

        public int CrownTowerDamagePercent { get; set; }

        public bool LoadFirstHit { get; set; }

        public int StopTimeAfterAttack { get; set; }

        public int StopTimeAfterSpecialAttack { get; set; }

        public string Projectile { get; set; }

        public string CustomFirstProjectile { get; set; }

        public int MultipleProjectiles { get; set; }

        public int MultipleTargets { get; set; }

        public bool AllTargetsHit { get; set; }

        public int Range { get; set; }

        public int MinimumRange { get; set; }

        public bool AttacksGround { get; set; }

        public bool AttacksAir { get; set; }

        public int DeathDamageRadius { get; set; }

        public int DeathDamage { get; set; }

        public int DeathPushBack { get; set; }

        public int AttackPushBack { get; set; }

        public bool PushbackStaticDir { get; set; }

        public int ReloadAfterHits { get; set; }

        public int ReloadTime { get; set; }

        public int LifeTime { get; set; }

        public string ProjectileSpecial { get; set; }

        public string ProjectileEffect { get; set; }

        public string ProjectileEffectSpecial { get; set; }

        public int AreaDamageRadius { get; set; }

        public bool TargetOnlyBuildings { get; set; }

        public int SpecialAttackInterval { get; set; }

        public int OpponentCardHealthReduction { get; set; }

        public int OwnCardHealthReduction { get; set; }

        public string BuffOnDamage { get; set; }

        public int BuffOnDamageTime { get; set; }

        public bool IgnoreTargetIfImmuneToBuff { get; set; }

        public string StartingBuff { get; set; }

        public int StartingBuffTime { get; set; }

        public string FileName { get; set; }

        public string BlueExportName { get; set; }

        public string BlueTopExportName { get; set; }

        public string RedExportName { get; set; }

        public string RedTopExportName { get; set; }

        public bool UseAnimator { get; set; }

        public string AttachedCharacter { get; set; }

        public int AttachedCharacterHeight { get; set; }

        public string DamageEffect { get; set; }

        public string DamageEffectSpecial { get; set; }

        public string DeathEffect { get; set; }

        public string MoveEffect { get; set; }

        public string SpawnEffect { get; set; }

        public bool CrowdEffects { get; set; }

        public int ShadowScaleX { get; set; }

        public int ShadowScaleY { get; set; }

        public int ShadowX { get; set; }

        public int ShadowY { get; set; }

        public int ShadowSkew { get; set; }

        public int Pushback { get; set; }

        public bool IgnorePushback { get; set; }

        public int Scale { get; set; }

        public int CollisionRadius { get; set; }

        public int Mass { get; set; }

        public int TileSizeOverride { get; set; }

        public string AreaBuff { get; set; }

        public int AreaBuffTime { get; set; }

        public int AreaBuffRadius { get; set; }

        public bool AreaBuffOwnTroops { get; set; }

        public bool AreaBuffEnemies { get; set; }

        public int Gold { get; set; }

        public int ManaOnDeath { get; set; }

        public string HealthBar { get; set; }

        public int HealthBarOffsetY { get; set; }

        public bool ShowHealthNumber { get; set; }

        public int FlyingHeight { get; set; }

        public bool FlyFromGround { get; set; }

        public string DamageExportName { get; set; }

        public int GrowTime { get; set; }

        public int GrowSize { get; set; }

        public string MorphCharacter { get; set; }

        public string MorphEffect { get; set; }

        public bool HealOnMorph { get; set; }

        public string AreaEffectOnMorph { get; set; }

        public string AttackStartEffect { get; set; }

        public string AttackStartEffectSpecial { get; set; }

        public string DashStartEffect { get; set; }

        public string DashEffect { get; set; }

        public int DashCooldown { get; set; }

        public int JumpHeight { get; set; }

        public int DashPushBack { get; set; }

        public int DashRadius { get; set; }

        public int DashDamage { get; set; }

        public string LandingEffect { get; set; }

        public int DashMinRange { get; set; }

        public int DashMaxRange { get; set; }

        public int JumpSpeed { get; set; }

        public string ContinuousEffect { get; set; }

        public int OpponentCardSpawn { get; set; }

        public int OwnCardSpawn { get; set; }

        public int SpawnStartTime { get; set; }

        public int SpawnInterval { get; set; }

        public int SpawnNumber { get; set; }

        public int SpawnLimit { get; set; }

        public int SpawnPauseTime { get; set; }

        public int SpawnCharacterLevelIndex { get; set; }

        public string SpawnCharacter { get; set; }

        public string SpawnCharacterEffect { get; set; }

        public string SpawnDeployBaseAnim { get; set; }

        public int SpawnRadius { get; set; }

        public int DeathSpawnCount { get; set; }

        public string DeathSpawnCharacter { get; set; }

        public int DeathSpawnRadius { get; set; }

        public int DeathSpawnAngleShift { get; set; }

        public int DeathSpawnDeployTime { get; set; }

        public bool DeathSpawnPushback { get; set; }

        public string DeathAreaEffect { get; set; }

        public bool Kamikaze { get; set; }

        public string KamikazeEffect { get; set; }

        public int SpawnPathfindSpeed { get; set; }

        public string SpawnPathfindEffect { get; set; }

        public string SpawnPathfindMorph { get; set; }

        public int SpawnPushback { get; set; }

        public int SpawnPushbackRadius { get; set; }

        public string SpawnAreaObject { get; set; }

        public int SpawnAreaObjectLevelIndex { get; set; }

        public string ChargeEffect { get; set; }

        public string TakeDamageEffect { get; set; }

        public int ProjectileStartRadius { get; set; }

        public int ProjectileStartZ { get; set; }

        public int StopMovementAfterMS { get; set; }

        public int WaitMS { get; set; }

        public bool DontStopMoveAnim { get; set; }

        public bool IsSummonerTower { get; set; }

        public int NoDeploySizeW { get; set; }

        public int NoDeploySizeH { get; set; }

        public string TID { get; set; }

        public int VariableDamage2 { get; set; }

        public int VariableDamageTime1 { get; set; }

        public int VariableDamage3 { get; set; }

        public int VariableDamageTime2 { get; set; }

        public string TargettedDamageEffect1 { get; set; }

        public string TargettedDamageEffect2 { get; set; }

        public string TargettedDamageEffect3 { get; set; }

        public string DamageLevelTransitionEffect12 { get; set; }

        public string DamageLevelTransitionEffect23 { get; set; }

        public string FlameEffect1 { get; set; }

        public string FlameEffect2 { get; set; }

        public string FlameEffect3 { get; set; }

        public int TargetEffectY { get; set; }

        public bool SelfAsAoeCenter { get; set; }

        public bool HidesWhenNotAttacking { get; set; }

        public int HideTimeMs { get; set; }

        public bool HideBeforeFirstHit { get; set; }

        public bool SpecialAttackWhenHidden { get; set; }

        public string TargetedHitEffect { get; set; }

        public string TargetedHitEffectSpecial { get; set; }

        public int UpTimeMs { get; set; }

        public string HideEffect { get; set; }

        public string AppearEffect { get; set; }

        public int AppearPushbackRadius { get; set; }

        public int AppearPushback { get; set; }

        public string AppearAreaObject { get; set; }

        public int ManaCollectAmount { get; set; }

        public int ManaGenerateTimeMs { get; set; }

        public int ManaGenerateLimit { get; set; }

        public bool HasRotationOnTimeline { get; set; }

        public int TurretMovement { get; set; }

        public int ProjectileYOffset { get; set; }

        public int ChargeSpeedMultiplier { get; set; }

        public int DeployDelay { get; set; }

        public string DeployBaseAnimExportName { get; set; }

        public bool JumpEnabled { get; set; }

        public int SightClip { get; set; }

        public string AreaEffectOnDash { get; set; }

        public int SightClipSide { get; set; }

        public int WalkingSpeedTweakPercentage { get; set; }

        public int ShieldHitpoints { get; set; }

        public int ShieldDiePushback { get; set; }

        public string ShieldLostEffect { get; set; }

        public string BlueShieldExportName { get; set; }

        public string RedShieldExportName { get; set; }

        public string LoadAttackEffect1 { get; set; }

        public string LoadAttackEffect2 { get; set; }

        public string LoadAttackEffect3 { get; set; }

        public string LoadAttackEffectReady { get; set; }

        public int RotateAngleSpeed { get; set; }

        public bool EnableAttackOnDamage { get; set; }

        public int SecondaryHitDelay { get; set; }

        public int DeployTimerDelay { get; set; }

        public bool RetargetAfterAttack { get; set; }

        public int AttackShakeTime { get; set; }

        public int VisualHitSpeed { get; set; }

        public string Ability { get; set; }

        public int Burst { get; set; }

        public int BurstDelay { get; set; }

        public bool BurstKeepTarget { get; set; }

        public int ActivationTime { get; set; }
    }
}